using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using RAGFlowSharp.Api;
using WebApiClientCore;

namespace RAGFlowSharp.Test.Api;

[TestSubject(typeof(IDatasetApi))]
public class DatasetApiTest(IRagflowApi ragflowApi) : IDisposable
{
    private readonly List<string> _shouldDeleteDatasetIds = [];
    
    public void Dispose()
    {
        if (_shouldDeleteDatasetIds.Count <= 0) return;
        
        var deleteRequest = new RAGFlowSharp.Dtos.Dataset.Delete.RequestBody
        {
            Ids = _shouldDeleteDatasetIds
        };
        
        ragflowApi.DeleteDataset(deleteRequest).Wait();
    }

    [Fact]
    public async Task TestGetDatasetList()
    {
        var result = await ragflowApi.ListDatasets();
        // var json = await result.Content.ReadAsStringAsync();
        // logger.LogInformation(json);
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task TestCreateDataset()
    {
        var request = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name = $"test_dataset_{System.Guid.NewGuid().ToString("N")[..8]}",
            Description = "Test dataset",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod = "naive"
        };
        var result = await ragflowApi.CreateDataset(request);
        Assert.NotNull(result);
        Assert.Equal(0, result.Code);
        Assert.NotNull(result.Data);
        Assert.Equal(request.Name, result.Data.Name);
        
        _shouldDeleteDatasetIds.Add(result.Data.Id);
    }

    [Fact]
    public async Task TestUpdateDataset()
    {
        // First, create a dataset to update
        var createRequest = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name = $"update_dataset_{System.Guid.NewGuid().ToString("N")[..8]}",
            Description = "To be updated",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod = "naive"
        };
        var createResult = await ragflowApi.CreateDataset(createRequest);
        var datasetId = createResult.Data?.Id;
        Assert.NotNull(datasetId);

        var updateRequest = new RAGFlowSharp.Dtos.Dataset.Update.RequestBody
        {
            Name = createRequest.Name,
            Description = "Updated description"
        };
        var updateResult = await ragflowApi.UpdateDataset(datasetId, updateRequest);
        Assert.NotNull(updateResult);
        Assert.Equal(0, updateResult.Code);
        
        // Verify the update
        var getResult = await ragflowApi.ListDatasets(id: datasetId);
        Assert.NotNull(getResult);
        Assert.NotNull(getResult.Data);
        Assert.Single(getResult.Data);
        Assert.Equal("Updated description", getResult.Data[0].Description);
        Assert.Equal(datasetId, getResult.Data[0].Id);
        Assert.Equal(createRequest.Name, getResult.Data[0].Name);
        
        _shouldDeleteDatasetIds.Add(datasetId);
    }

    [Fact]
    public async Task TestDeleteDataset()
    {
        // First, create a dataset to delete
        var createRequest = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name = $"delete_dataset_{System.Guid.NewGuid().ToString("N")[..8]}",
            Description = "To be deleted",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod = "naive"
        };
        var createResult = await ragflowApi.CreateDataset(createRequest);
        Assert.NotNull(createResult?.Data?.Id);

        var deleteRequest = new RAGFlowSharp.Dtos.Dataset.Delete.RequestBody
        {
            Ids = new[] { createResult.Data.Id }
        };
        var deleteResult = await ragflowApi.DeleteDataset(deleteRequest);
        Assert.NotNull(deleteResult);
        Assert.Equal(0, deleteResult.Code);
    }
}