# RAGFlowSharp

RAGFlowSharp is a .NET-based RAG (Retrieval-Augmented Generation) workflow management library that provides a comprehensive set of APIs to manage various components in RAG applications.

## Key Features

- Dataset Management
- File Processing
- Text Chunking
- Session Management
- Intelligent Agent
- Chat Assistant

## Quick Start

### Installation

```bash
dotnet add package RAGFlowSharp
```

### Configuration

```csharp
// Configure services in Program.cs or Startup.cs
services.AddRAGFlowSharp(options =>
{
    // Configuration options
    options.StoragePath = "path/to/storage";
    options.ModelProvider = "OpenAI"; // or other supported model providers
    options.ApiKey = "your-api-key";
});
```

### Usage Example

```csharp
public class MyRAGService
{
    private readonly IRagflowApi _ragflowApi;

    public MyRAGService(IRagflowApi ragflowApi)
    {
        _ragflowApi = ragflowApi;
    }

    public async Task ProcessDocument()
    {
        // Create dataset
        var dataset = await _ragflowApi.DatasetApi.CreateDatasetAsync(new CreateDatasetRequest
        {
            Name = "MyDataset",
            Description = "Sample Dataset"
        });

        // Upload file
        var file = await _ragflowApi.FileApi.UploadFileAsync(new UploadFileRequest
        {
            DatasetId = dataset.Id,
            FileName = "example.pdf",
            FileContent = File.ReadAllBytes("path/to/file.pdf")
        });

        // Process text chunks
        var chunks = await _ragflowApi.ChunkApi.ProcessFileAsync(new ProcessFileRequest
        {
            FileId = file.Id
        });

        // Create session
        var session = await _ragflowApi.SessionApi.CreateSessionAsync(new CreateSessionRequest
        {
            DatasetId = dataset.Id
        });

        // Use chat assistant
        var response = await _ragflowApi.ChatAssistantApi.ChatAsync(new ChatRequest
        {
            SessionId = session.Id,
            Message = "Please analyze the main content of this document"
        });
    }
}
```

## API Interfaces

### Dataset Management (IDatasetApi)
- Create dataset
- Get dataset list
- Update dataset information
- Delete dataset

### File Processing (IFileApi)
- Upload file
- Get file list
- Delete file
- Get file content

### Text Chunking (IChunkApi)
- Process file chunks
- Get chunk list
- Update chunk information
- Delete chunk

### Session Management (ISessionApi)
- Create session
- Get session history
- Update session status
- Delete session

### Intelligent Agent (IAgentApi)
- Create agent
- Configure agent behavior
- Execute agent tasks
- Manage agent status

### Chat Assistant (IChatAssistantApi)
- Send message
- Get response
- Manage conversation context
- Configure assistant parameters

## Contributing

Issues and Pull Requests are welcome!

## License

MIT License 