using System.Text;
using System.Text.Json;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using RAGFlowSharp.Api;
using RAGFlowSharp.Dtos.Chunk;
using RAGFlowSharp.Dtos.Dataset;
using RAGFlowSharp.Dtos.File;

namespace RAGFlowSharp.Test.Api;

[TestSubject(typeof(IChunkApi))]
public class ChunkApiTest : IDisposable
{
    private readonly IRagflowApi _ragflowApi;
    private readonly ILogger<ChunkApiTest> _logger;
    private readonly string _testDatasetId;
    private readonly string _testDocumentId;
    private readonly string _testFileName = $"test_file_{Guid.NewGuid():N}.txt";
    private readonly string _testFileContent = $"This is a chunk test file. {Guid.NewGuid():N}";
    private readonly List<string> _createdChunkIds = [];

    public ChunkApiTest(IRagflowApi ragflowApi, ILogger<ChunkApiTest> logger)
    {
        _ragflowApi = ragflowApi;
        _logger = logger;

        // Create dataset
        var createDatasetRequest = new Create.RequestBody
        {
            Name = $"test_chunk_dataset_{Guid.NewGuid().ToString("N")[..8]}",
            Description = "Test dataset for chunk API",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod = "naive"
        };
        var createDatasetResult = ragflowApi.CreateDataset(createDatasetRequest).GetAwaiter().GetResult();
        Assert.NotNull(createDatasetResult?.Data?.Id);
        _testDatasetId = createDatasetResult.Data.Id;

        // Create file
        var uploadFile = new FileInfo(_testFileName);
        if (!uploadFile.Exists)
            File.WriteAllText(uploadFile.FullName, _testFileContent, Encoding.UTF8);

        var uploadResult = ragflowApi.UploadFilesAsync(_testDatasetId, uploadFile).GetAwaiter().GetResult();
        Assert.NotNull(uploadResult?.Data?.FirstOrDefault()?.Id);
        _testDocumentId = uploadResult.Data.First().Id;

        // start parse document
        var parseRequest = new RAGFlowSharp.Dtos.File.Parse.RequestBody
        {
            DocumentIds = [_testDocumentId],
        };
        var parseResult = _ragflowApi.ParseDocumentsAsync(_testDatasetId, parseRequest).GetAwaiter().GetResult();
        _logger.LogInformation("Parse documents response: {Response}", JsonSerializer.Serialize(parseResult));

        // Wait for parsing to complete
        Task.Delay(5000).GetAwaiter().GetResult();
    }

    public void Dispose()
    {
        // Clean up dataset
        var deleteDatasetRequest = new RAGFlowSharp.Dtos.Dataset.Delete.RequestBody
        {
            Ids = new List<string> { _testDatasetId }
        };
        _ragflowApi.DeleteDataset(deleteDatasetRequest).Wait();

        if (File.Exists(_testFileName))
            File.Delete(_testFileName);
    }

    [Fact]
    public async Task TestListChunks()
    {
        var listResult = await _ragflowApi.ListChunksAsync(_testDatasetId, _testDocumentId);
        _logger.LogInformation("List chunks response: {Response}", JsonSerializer.Serialize(listResult));
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.NotNull(listResult.Data.Chunks);
        Assert.NotEmpty(listResult.Data.Chunks);
    }

    [Fact]
    public async Task TestAddAndListChunk()
    {
        var addRequest = new Add.RequestBody
        {
            Content = $"This is a test chunk. {Guid.NewGuid():N}"
        };
        var addResult = await _ragflowApi.AddChunkAsync(_testDatasetId, _testDocumentId, addRequest);
        _logger.LogInformation("Add chunk response: {Response}", JsonSerializer.Serialize(addResult));
        Assert.NotNull(addResult);
        Assert.Equal(0, addResult.Code);

        // parse document
        var parseResult = await _ragflowApi.ParseDocumentsAsync(_testDatasetId, new Parse.RequestBody
        {
            DocumentIds = [_testDocumentId],
        });
        _logger.LogInformation("Parse documents response: {Response}", JsonSerializer.Serialize(parseResult));
        Assert.NotNull(parseResult);
        Assert.Equal(0, parseResult.Code);
        await Task.Delay(5000); // Wait for parsing to complete

        // List chunks
        var listResult = await _ragflowApi.ListChunksAsync(_testDatasetId, _testDocumentId);
        _logger.LogInformation("List chunks response: {Response}", JsonSerializer.Serialize(listResult));
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.NotNull(listResult.Data.Chunks);
        Assert.Contains(listResult.Data.Chunks, chunk => chunk.Content == addRequest.Content);
    }

    [Fact]
    public async Task TestUpdateChunk()
    {
        // Add a chunk first
        var addRequest = new Add.RequestBody { Content = "Chunk to update." };
        var addResult = await _ragflowApi.AddChunkAsync(_testDatasetId, _testDocumentId, addRequest);
        Assert.NotNull(addResult?.Data?.Id);
        var chunkId = addResult.Data.Id;
        _createdChunkIds.Add(chunkId);

        var updateRequest = new RAGFlowSharp.Dtos.Chunk.Update.RequestBody
        {
            Content = $"Updated chunk content. {Guid.NewGuid():N}",
            ImportantKeywords = ["test", "update"],
            Available = true,
        };
        var updateResult = await _ragflowApi.UpdateChunkAsync(_testDatasetId, _testDocumentId, chunkId, updateRequest); // this returns MethodNotAllowed ?? 
        _logger.LogInformation("Update chunk response: {Response}", JsonSerializer.Serialize(updateResult));
        Assert.NotNull(updateResult);
        Assert.Equal(0, updateResult.Code);
    }

    [Fact]
    public async Task TestDeleteChunk()
    {
        // Add a chunk first
        var addRequest = new Add.RequestBody { Content = "Chunk to delete." };
        var addResult = await _ragflowApi.AddChunkAsync(_testDatasetId, _testDocumentId, addRequest);
        Assert.NotNull(addResult.Data);

        // List Chunks
        var listResult = await _ragflowApi.ListChunksAsync(_testDatasetId, _testDocumentId);
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.NotNull(listResult.Data.Chunks);
        Assert.NotEmpty(listResult.Data.Chunks);

        var chunkId = listResult.Data.Chunks.First().Id;

        // Delete the chunk
        var deleteRequest = new RAGFlowSharp.Dtos.Chunk.Delete.RequestBody { ChunkIds = new List<string> { chunkId } };
        var deleteResult = await _ragflowApi.DeleteChunksAsync(_testDatasetId, _testDocumentId, deleteRequest);
        _logger.LogInformation("Delete chunk response: {Response}", JsonSerializer.Serialize(deleteResult));
        Assert.NotNull(deleteResult);
        Assert.Equal(0, deleteResult.Code);

        // Verify deletion
        var verifyListResult = await _ragflowApi.ListChunksAsync(_testDatasetId, _testDocumentId);
        Assert.NotNull(verifyListResult);
        Assert.Equal(0, verifyListResult.Code);
        Assert.NotNull(verifyListResult.Data);
        Assert.NotNull(verifyListResult.Data.Chunks);
        Assert.DoesNotContain(verifyListResult.Data.Chunks, chunk => chunk.Id == chunkId);
    }

    [Fact]
    public async Task TestRetrieveChunks()
    {
        // Add a chunk for retrieval
        var addRequest = new Add.RequestBody { Content = "RAGFlow retrieval test chunk." };
        var addResult = await _ragflowApi.AddChunkAsync(_testDatasetId, _testDocumentId, addRequest);
        Assert.NotNull(addResult?.Data?.Id);
        _createdChunkIds.Add(addResult.Data.Id);

        var retrievalRequest = new Retrieval.RequestBody
        {
            Question = "What is RAGFlow?",
            DatasetIds = new List<string> { _testDatasetId },
            DocumentIds = new List<string> { _testDocumentId },
            Page = 1,
            PageSize = 10,
            Highlight = true
        };
        var retrievalResult = await _ragflowApi.RetrieveChunksAsync(retrievalRequest);
        _logger.LogInformation("Retrieve chunks response: {Response}", JsonSerializer.Serialize(retrievalResult));
        Assert.NotNull(retrievalResult);
        Assert.Equal(0, retrievalResult.Code);
        Assert.NotNull(retrievalResult.Data);
        Assert.True(retrievalResult.Data.Chunks.Count >= 0);
    }
}