using System.Threading.Tasks;
using RAGFlowSharp.Dtos.Conversation.RelatedQuestions;
using RAGFlowSharp.Dtos.Session;
using WebApiClientCore.Attributes;

namespace RAGFlowSharp.Api
{
    /// <summary>
    /// Session management API interface
    /// </summary>
    public interface ISessionApi
    {
        /// <summary>
        /// Create a new chat session
        /// </summary>
        /// <param name="assistantId">The ID of the assistant to create a session with</param>
        /// <param name="request">The create request containing session configuration</param>
        /// <returns>The create response</returns>
        [HttpPost("/api/v1/chat_assistants/{assistantId}/sessions")]
        Task<Create.ResponseBody> CreateSessionAsync(
            [PathQuery] string assistantId,
            [JsonContent] Create.RequestBody request);

        /// <summary>
        /// List chat sessions
        /// </summary>
        /// <param name="assistantId">The ID of the assistant</param>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 30)</param>
        /// <param name="orderBy">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <param name="name">Filter by session name</param>
        /// <param name="id">Filter by session ID</param>
        /// <returns>The list response containing session data</returns>
        [HttpGet("/api/v1/chat_assistants/{assistantId}/sessions")]
        Task<List.ResponseBody> ListSessionsAsync(
            [PathQuery] string assistantId,
             int? page = null,
             int? pageSize = null,
             string? orderBy = null,
             bool? desc = null,
             string? name = null,
             string? id = null);

        /// <summary>
        /// Update a chat session
        /// </summary>
        /// <param name="assistantId">The ID of the assistant</param>
        /// <param name="sessionId">The ID of the session to update</param>
        /// <param name="request">The update request containing session data</param>
        /// <returns>The update response</returns>
        [HttpPut("/api/v1/chat_assistants/{assistantId}/sessions/{sessionId}")]
        Task<Update.ResponseBody> UpdateSessionAsync(
            [PathQuery] string assistantId,
            [PathQuery] string sessionId,
            [JsonContent] Update.RequestBody request);

        /// <summary>
        /// Delete chat sessions
        /// </summary>
        /// <param name="assistantId">The ID of the assistant</param>
        /// <param name="request">The delete request containing session IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/chat_assistants/{assistantId}/sessions")]
        Task<Delete.ResponseBody> DeleteSessionsAsync(
            [PathQuery] string assistantId,
            [JsonContent] Delete.RequestBody request);

        /// <summary>
        /// Converse with a chat assistant in a session
        /// </summary>
        /// <param name="assistantId">The ID of the assistant</param>
        /// <param name="sessionId">The ID of the session</param>
        /// <param name="request">The conversation request containing the message</param>
        /// <returns>The conversation response</returns>
        [HttpPost("/api/v1/chat_assistants/{assistantId}/sessions/{sessionId}/converse")]
        Task<Converse.ResponseBody> ConverseAsync(
            [PathQuery] string assistantId,
            [PathQuery] string sessionId,
            [JsonContent] Converse.RequestBody request);

        /// <summary>
        /// List messages in a chat session
        /// </summary>
        /// <param name="assistantId">The ID of the assistant</param>
        /// <param name="sessionId">The ID of the session</param>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 30)</param>
        /// <param name="orderBy">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <returns>The list response containing message data</returns>
        [HttpGet("/api/v1/chat_assistants/{assistantId}/sessions/{sessionId}/messages")]
        Task<ListMessages.ResponseBody> ListMessagesAsync(
            [PathQuery] string assistantId,
            [PathQuery] string sessionId,
             int? page = null,
             int? pageSize = null,
             string? orderBy = null,
             bool? desc = null);

        /// <summary>
        /// Delete messages from a chat session
        /// </summary>
        /// <param name="assistantId">The ID of the assistant</param>
        /// <param name="sessionId">The ID of the session</param>
        /// <param name="request">The delete request containing message IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/chat_assistants/{assistantId}/sessions/{sessionId}/messages")]
        Task<DeleteMessages.ResponseBody> DeleteMessagesAsync(
            [PathQuery] string assistantId,
            [PathQuery] string sessionId,
            [JsonContent] DeleteMessages.RequestBody request);

        /// <summary>
        /// Generate related questions for a given user query (OpenAI compatible)
        /// </summary>
        /// <param name="request">The request body containing the original question</param>
        /// <returns>The response body containing related questions</returns>
        [HttpPost("/api/v1/conversation/related_questions")]
        Task<ResponseBody> RelatedQuestionsAsync(
            [JsonContent] RequestBody request
        );
    }
} 