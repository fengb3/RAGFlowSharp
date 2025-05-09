using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using RAGFlowSharp.Api;
using RAGFlowSharp.Dtos.File;
using System.Text;
using System.Text.Json;

namespace RAGFlowSharp.Test.Api;

[TestSubject(typeof(IFileApi))]
public class FileApiTest(IRagflowApi ragflowApi, ILogger<FileApiTest> logger) : IDisposable
{
    private readonly List<string> _shouldDeleteFileIds = [];
    private string? _testDatasetId;

    public void Dispose()
    {
        if (_shouldDeleteFileIds.Count <= 0) return;
        
        if (string.IsNullOrEmpty(_testDatasetId)) return;
        
        var deleteRequest = new Delete.RequestBody
        {
            Ids = _shouldDeleteFileIds
        };
        
        ragflowApi.DeleteFilesAsync(_testDatasetId, deleteRequest).Wait();
        
        // 删除测试数据集
        var deleteDatasetRequest = new RAGFlowSharp.Dtos.Dataset.Delete.RequestBody
        {
            Ids = [_testDatasetId]
        };
        ragflowApi.DeleteDataset(deleteDatasetRequest).Wait();
    }

    [Fact]
    public async Task TestUploadFile()
    {
        // 首先创建一个测试数据集
        var createDatasetRequest = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name = $"test_dataset_{System.Guid.NewGuid().ToString("N").Substring(0, 8)}",
            Description = "Test dataset for file upload",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod = "naive"
        };
        
        var createDatasetResult = await ragflowApi.CreateDataset(createDatasetRequest);
        logger.LogInformation("Create dataset response: {Response}", JsonSerializer.Serialize(createDatasetResult));
        
        Assert.NotNull(createDatasetResult);
        Assert.Equal(0, createDatasetResult.Code);
        Assert.NotNull(createDatasetResult.Data);
        Assert.NotNull(createDatasetResult.Data.Id);
        
        _testDatasetId = createDatasetResult.Data.Id;

        // 准备测试文件内容
        var content = "This is a test file content";
        var contentBytes = Encoding.UTF8.GetBytes(content);
        var base64Content = Convert.ToBase64String(contentBytes);

        // 上传文件
        var uploadRequest = new Upload.RequestBody
        {
            Name = "test.txt",
            MimeType = "text/plain",
            Content = base64Content
        };

        await Task.Delay(2000); // 等待数据集创建完成

        var uploadResult = await ragflowApi.UploadFileAsync(_testDatasetId, uploadRequest);
        logger.LogInformation("Upload file response: {Response}", JsonSerializer.Serialize(uploadResult));
        
        Assert.NotNull(uploadResult);
        Assert.Equal(0, uploadResult.Code);
        Assert.NotNull(uploadResult.Data);
        Assert.Equal("test.txt", uploadResult.Data.Name);
        
        _shouldDeleteFileIds.Add(uploadResult.Data.Id);
    }

    [Fact]
    public async Task TestListFiles()
    {
        // 首先创建一个测试数据集并上传文件
        await TestUploadFile();
        
        Assert.NotNull(_testDatasetId);

        // 列出文件
        var listResult = await ragflowApi.ListFilesAsync(_testDatasetId);
        logger.LogInformation("List files response: {Response}", JsonSerializer.Serialize(listResult));
        
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.NotEmpty(listResult.Data);
        Assert.Contains(listResult.Data, f => f.Name == "test.txt");
    }

    [Fact]
    public async Task TestDeleteFiles()
    {
        // 首先创建一个测试数据集并上传文件
        await TestUploadFile();
        
        Assert.NotNull(_testDatasetId);

        // 删除文件
        var deleteRequest = new Delete.RequestBody
        {
            Ids = _shouldDeleteFileIds
        };

        var deleteResult = await ragflowApi.DeleteFilesAsync(_testDatasetId, deleteRequest);
        logger.LogInformation("Delete files response: {Response}", JsonSerializer.Serialize(deleteResult));
        
        Assert.NotNull(deleteResult);
        Assert.Equal(0, deleteResult.Code);

        // 验证文件已被删除
        var listResult = await ragflowApi.ListFilesAsync(_testDatasetId);
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.Empty(listResult.Data);
    }
} 