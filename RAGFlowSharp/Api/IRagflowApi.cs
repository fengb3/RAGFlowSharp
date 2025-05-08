using WebApiClientCore.Attributes;

namespace RAGFlowSharp.Api
{
    /// <summary>
    /// Main RAGFlow API interface
    /// </summary>
    [OAuthToken]
    public interface IRagflowApi : IDatasetApi, IFileApi, IChunkApi, IChatAssistantApi, ISessionApi, IAgentApi
    {
    }
} 