using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RAGFlowSharp.Api;
using RAGFlowSharp.Dtos.ChatAssistant;
using Xunit;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using RAGFlowSharp.Dtos.File;
using Delete = RAGFlowSharp.Dtos.ChatAssistant.Delete;
using Update = RAGFlowSharp.Dtos.ChatAssistant.Update;

namespace RAGFlowSharp.Test.Api;

[TestSubject(typeof(IChatAssistantApi))]
public class ChatAssistantApiTest : IDisposable
{
    private readonly List<string> _shouldDeleteChatIds = new();
    private readonly List<string> _shouldDeleteDatasetIds = new();
    
    private readonly IRagflowApi _ragflowApi;
    private readonly ILogger<ChatAssistantApiTest> _logger;

    public ChatAssistantApiTest(IRagflowApi ragflowApi, ILogger<ChatAssistantApiTest> logger)
    {
        _ragflowApi = ragflowApi;
        _logger = logger;
    }

    public void Dispose()
    {
        if (_shouldDeleteChatIds.Count > 0)
        {
            var deleteRequest = new Delete.RequestBody { Ids = _shouldDeleteChatIds };
            _ragflowApi.DeleteChatAssistantsAsync(deleteRequest).Wait();
        }
        if (_shouldDeleteDatasetIds.Count > 0)
        {
            var deleteRequest = new RAGFlowSharp.Dtos.Dataset.Delete.RequestBody { Ids = _shouldDeleteDatasetIds };
            _ragflowApi.DeleteDataset(deleteRequest).Wait();
        }
    }

    /// <summary>
    /// create a dataset for test
    /// </summary>
    /// <returns></returns>
    private async Task<string> CreateDataset()
    {
        var datasetRequest = new RAGFlowSharp.Dtos.Dataset.Create.RequestBody
        {
            Name = $"test_dataset_{Guid.NewGuid():N}",
            Description = "Test dataset",
            EmbeddingModel = "BAAI/bge-large-zh-v1.5",
            ChunkMethod = "naive"
        };
        var datasetResult = await _ragflowApi.CreateDataset(datasetRequest);
        Assert.NotNull(datasetResult);
        _logger.LogInformation("Dataset created: {DatasetId}", datasetResult?.Data?.Id);
        Assert.NotNull(datasetResult?.Data?.Id);
        var datasetId = datasetResult.Data.Id;
        _shouldDeleteDatasetIds.Add(datasetId);
        
        // prepare test file
        var uploadFile = new FileInfo( $"test_{Guid.NewGuid().ToString("N")[..6]}.txt");
        if (!uploadFile.Exists)
        {
            var fileContent =$"This is a test file for RAGFlowSharp. {Guid.NewGuid():N}";;
            await File.WriteAllTextAsync(uploadFile.FullName, fileContent, Encoding.UTF8);
        }
        
        var uploadFileResult = await _ragflowApi.UploadFilesAsync(datasetId, uploadFile);
        _logger.LogInformation("Upload file response: {Response}", JsonSerializer.Serialize(uploadFileResult));
        
        Assert.NotNull(uploadFileResult);
        Assert.Equal(0, uploadFileResult.Code);
        Assert.NotNull(uploadFileResult.Data);
        
        // parse the file 
        var parseResult = await _ragflowApi.ParseDocumentsAsync(datasetId, new Parse.RequestBody
        {
            DocumentIds = [uploadFileResult.Data.First().Id]
        });
        _logger.LogInformation("Parse file response: {Response}", JsonSerializer.Serialize(parseResult));
        Assert.NotNull(parseResult);
        Assert.Equal(0, parseResult.Code);
        
        await Task.Delay(5000); // wait for the parsed files to be processed
        
        return datasetId;
    }

    [Fact]
    public async Task TestCreateChatAssistant()
    {
        var datasetId = await CreateDataset();
        var createRequest = new Create.RequestBody
        {
            Name = $"test_chat_{Guid.NewGuid():N}",
            DatasetIds = [datasetId],
            Llm = new LlmDto { ModelName = "moonshot-v1-8k" },
            Prompt = new PromptDto { Prompt = "Test prompt" }
        };
        var result = await _ragflowApi.CreateChatAssistantAsync(createRequest);
        
        Assert.NotNull(result);
        _logger.LogInformation("Chat assistant created: {result}", JsonSerializer.Serialize(result));
        Assert.Equal(0, result.Code);
        Assert.NotNull(result.Data);
        Assert.Equal(createRequest.Name, result.Data.Name);
        _shouldDeleteChatIds.Add(result.Data.Id);
    }

    [Fact]
    public async Task TestListChatAssistants()
    {
        var result = await _ragflowApi.ListChatAssistantsAsync();
        Assert.NotNull(result);
        Assert.Equal(0, result.Code);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task TestUpdateChatAssistant()
    {
        var datasetId = await CreateDataset();
        var createRequest = new Create.RequestBody
        {
            Name = $"update_chat_{Guid.NewGuid():N}",
            DatasetIds = new List<string> { datasetId },
            Llm = new LlmDto { ModelName = "test-model" },
            Prompt = new PromptDto { Prompt = "Test prompt" }
        };
        var createResult = await _ragflowApi.CreateChatAssistantAsync(createRequest);
        var chatId = createResult.Data?.Id;
        Assert.NotNull(chatId);
        _shouldDeleteChatIds.Add(chatId);

        var updateRequest = new Update.RequestBody
        {
            Name = createRequest.Name + "_updated"
        };
        var updateResult = await _ragflowApi.UpdateChatAssistantAsync(chatId, updateRequest);
        Assert.NotNull(updateResult);
        Assert.Equal(0, updateResult.Code);
    }

    [Fact]
    public async Task TestDeleteChatAssistant()
    {
        var datasetId = await CreateDataset();
        var createRequest = new Create.RequestBody
        {
            Name = $"delete_chat_{Guid.NewGuid():N}",
            DatasetIds = new List<string> { datasetId },
            Llm = new LlmDto { ModelName = "test-model" },
            Prompt = new PromptDto { Prompt = "Test prompt" }
        };
        var createResult = await _ragflowApi.CreateChatAssistantAsync(createRequest);
        var chatId = createResult.Data?.Id;
        Assert.NotNull(chatId);

        var deleteRequest = new Delete.RequestBody { Ids = new List<string> { chatId } };
        var deleteResult = await _ragflowApi.DeleteChatAssistantsAsync(deleteRequest);
        Assert.NotNull(deleteResult);
        Assert.Equal(0, deleteResult.Code);
    }
} 