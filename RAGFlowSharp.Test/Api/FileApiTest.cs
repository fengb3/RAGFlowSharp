using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using RAGFlowSharp.Api;
using System.Text;
using System.Text.Json;

namespace RAGFlowSharp.Test.Api;

[TestSubject(typeof(IFileApi))]
public class FileApiTest : IDisposable
{
    private readonly IRagflowApi          _ragflowApi;
    private readonly ILogger<FileApiTest> _logger;

    private readonly List<string> _fileIds = [];
    private readonly string       _testDatasetId;

    private readonly string _testFileName    = $"test_{Guid.NewGuid().ToString("N")[..6]}.txt";
    private readonly string _testFileContent = $"This is a test file for RAGFlowSharp. {Guid.NewGuid():N}";

    public void Dispose()
    {
        // 删除测试数据集
        var deleteDatasetRequest = new RAGFlowSharp.Dtos.Dataset.Delete.RequestBody
        {
            Ids = new List<string> { _testDatasetId }
        };
        _ragflowApi.DeleteDataset(deleteDatasetRequest).Wait();
    }

    public FileApiTest(IRagflowApi ragflowApi, ILogger<FileApiTest> logger)
    {
        // 这里可以添加一些初始化代码
        // 例如，创建一个测试数据集
        _ragflowApi = ragflowApi;
        _logger     = logger;

        // 首先创建一个测试数据集
        var createDatasetRequest = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name           = $"test_dataset_{System.Guid.NewGuid().ToString("N")[..8]}",
            Description    = "Test dataset for file upload",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod    = "naive"
        };

        var createDatasetResult = ragflowApi.CreateDataset(createDatasetRequest).GetAwaiter().GetResult();
        logger.LogInformation("Create dataset response: {Response}", JsonSerializer.Serialize(createDatasetResult));

        Assert.NotNull(createDatasetResult);
        Assert.Equal(0, createDatasetResult.Code);
        Assert.NotNull(createDatasetResult.Data);
        Assert.NotNull(createDatasetResult.Data.Id);

        _testDatasetId = createDatasetResult.Data.Id;
    }

    [Fact]
    public async Task TestUploadFile()
    {
        // 准备测试文件内容
        var uploadFile = new FileInfo(_testFileName);
        if (!uploadFile.Exists)
        {
            var fileContent = _testFileContent;
            await File.WriteAllTextAsync(uploadFile.FullName, fileContent, Encoding.UTF8);
        }

        await Task.Delay(2000); // 等待数据集创建完成

        var uploadResult = await _ragflowApi.UploadFilesAsync(_testDatasetId, uploadFile);
        _logger.LogInformation("Upload file response: {Response}", JsonSerializer.Serialize(uploadResult));

        Assert.NotNull(uploadResult);
        Assert.Equal(0, uploadResult.Code);
        Assert.NotNull(uploadResult.Data);
        Assert.Single(uploadResult.Data);
        Assert.Equal(uploadFile.Name, uploadResult.Data[0].Name);

        _fileIds.AddRange(uploadResult.Data.Select(f => f.Id));
    }

    [Fact]
    public async Task TestListFiles()
    {
        // 首先创建一个测试数据集并上传文件
        await TestUploadFile();

        Assert.NotNull(_testDatasetId);

        // 列出文件
        var listResult = await _ragflowApi.ListFilesAsync(_testDatasetId);
        _logger.LogInformation("List files response: {Response}", JsonSerializer.Serialize(listResult));

        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.NotEmpty(listResult.Data.Docs);
        Assert.Contains(listResult.Data.Docs, f => f.Name == _testFileName);
    }

    [Fact]
    public async Task TestDeleteFiles()
    {
        // 首先创建一个测试数据集并上传文件
        await TestUploadFile();

        Assert.NotNull(_testDatasetId);

        // 删除文件
        var deleteRequest = new RAGFlowSharp.Dtos.File.Delete.RequestBody
        {
            Ids = _fileIds
        };

        var deleteResult = await _ragflowApi.DeleteFilesAsync(_testDatasetId, deleteRequest);
        _logger.LogInformation("Delete files response: {Response}", JsonSerializer.Serialize(deleteResult));

        Assert.NotNull(deleteResult);
        Assert.Equal(0, deleteResult.Code);

        // 验证文件已被删除
        var listResult = await _ragflowApi.ListFilesAsync(_testDatasetId);
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.Empty(listResult.Data.Docs);
    }

    [Fact]
    public async Task TestUpdateDocument()
    {
        // 首先上传一个文件
        await TestUploadFile();

        Assert.NotNull(_testDatasetId);
        Assert.NotEmpty(_fileIds);

        var updatedFileName = $"updated_test_{Guid.NewGuid().ToString("N")[..6]}.txt";

        // 更新文档配置
        var updateRequest = new RAGFlowSharp.Dtos.File.Update.RequestBody
        {
            Name        = updatedFileName,
            ChunkMethod = "qa",
            ParserConfig = new RAGFlowSharp.Dtos.File.ParserConfig
            {
                ChunkTokenCount = 512,
                LayoutRecognize = false
            }
        };

        var updateResult =
            await _ragflowApi.UpdateDocumentAsync(_testDatasetId, _fileIds[0], updateRequest);
        _logger.LogInformation("Update document response: {Response}", JsonSerializer.Serialize(updateResult));

        Assert.NotNull(updateResult);
        Assert.Equal(0, updateResult.Code);

        // 验证更新是否成功
        var listResult = await _ragflowApi.ListFilesAsync(_testDatasetId);
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.Contains(listResult.Data.Docs, f => f.Name == updatedFileName && f.ChunkMethod == "qa");
    }

    [Fact]
    public async Task TestDownloadDocument()
    {
        // 首先上传一个文件
        await TestUploadFile();

        Assert.NotNull(_testDatasetId);
        Assert.NotEmpty(_fileIds);

        // 下载文档
        var documentStream = await _ragflowApi.DownloadDocumentAsync(_testDatasetId, _fileIds[0]);
        Assert.NotNull(documentStream);

        // 读取流内容并验证
        using var reader  = new StreamReader(documentStream);
        var       content = await reader.ReadToEndAsync();
        Assert.Equal(_testFileContent, content);
    }

    [Fact]
    public async Task TestParseDocument()
    {
        // 首先上传一个文件
        await TestUploadFile();

        Assert.NotNull(_testDatasetId);
        Assert.NotEmpty(_fileIds);

        // 解析文档
        var parseRequest = new RAGFlowSharp.Dtos.File.Parse.RequestBody
        {
            DocumentIds = _fileIds
        };

        var parseResult = await _ragflowApi.ParseDocumentsAsync(_testDatasetId, parseRequest);
        _logger.LogInformation("Parse documents response: {Response}", JsonSerializer.Serialize(parseResult));

        Assert.NotNull(parseResult);
        Assert.Equal(0, parseResult.Code);

        // 等待一段时间让解析开始
        await Task.Delay(2000);

        // 验证文档状态
        var listResult = await _ragflowApi.ListFilesAsync(_testDatasetId);
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.Contains(listResult.Data.Docs, f => f.Id == _fileIds[0] && f.Progress > 0);
    }

    [Fact]
    public async Task TestStopParsingDocument()
    {
        // 首先上传并开始解析文档
        await TestParseDocument();

        Assert.NotNull(_testDatasetId);
        Assert.NotEmpty(_fileIds);

        // 停止解析
        var stopRequest = new RAGFlowSharp.Dtos.File.StopParse.RequestBody
        {
            DocumentIds = _fileIds
        };

        var stopResult = await _ragflowApi.StopParsingDocumentsAsync(_testDatasetId, stopRequest);
        _logger.LogInformation("Stop parsing response: {Response}", JsonSerializer.Serialize(stopResult));

        Assert.NotNull(stopResult);
        Assert.Equal(0, stopResult.Code);

        // 验证文档状态
        var listResult = await _ragflowApi.ListFilesAsync(_testDatasetId);
        Assert.NotNull(listResult);
        Assert.Equal(0, listResult.Code);
        Assert.NotNull(listResult.Data);
        Assert.Contains(listResult.Data.Docs, f => f.Id == _fileIds[0] && f.Progress < 100);
    }
}