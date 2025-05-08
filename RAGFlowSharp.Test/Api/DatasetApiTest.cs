using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using RAGFlowSharp.Api;
using WebApiClientCore;

namespace RAGFlowSharp.Test.Api;

[TestSubject(typeof(IDatasetApi))]
public class DatasetApiTest(IRagflowApi ragflowApi, ILogger<DatasetApiTest> logger)
{
    [Fact]
    public void TestRagflowApi()
    {
        Assert.NotNull(ragflowApi);
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
            Name = $"test_dataset_{System.Guid.NewGuid().ToString("N").Substring(0, 8)}",
            Description = "Test dataset",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod = "naive"
        };
        var result = await ragflowApi.CreateDataset(request);
        Assert.NotNull(result);
        Assert.Equal(0, result.Code);
        Assert.NotNull(result.Data);
        Assert.Equal(request.Name, result.Data.Name);
    }

    [Fact]
    public async Task TestUpdateDataset()
    {
        // First, create a dataset to update
        var createRequest = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name = $"update_dataset_{System.Guid.NewGuid().ToString("N").Substring(0, 8)}",
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
    }

    [Fact]
    public async Task TestDeleteDataset()
    {
        // First, create a dataset to delete
        var createRequest = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name = $"delete_dataset_{System.Guid.NewGuid().ToString("N").Substring(0, 8)}",
            Description = "To be deleted",
            EmbeddingModel = "BAAI/bge-zh-v1.5",
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