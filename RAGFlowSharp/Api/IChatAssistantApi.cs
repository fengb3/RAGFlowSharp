using System.Threading.Tasks;
using RAGFlowSharp.Dtos.ChatAssistant;
using WebApiClientCore.Attributes;

namespace RAGFlowSharp.Api
{
    /// <summary>
    /// Chat Assistant management API interface
    /// </summary>
    public interface IChatAssistantApi
    {
        /// <summary>
        /// Create a new chat assistant
        /// </summary>
        /// <param name="request">The create request containing assistant configuration</param>
        /// <returns>The create response</returns>
        [HttpPost("/api/v1/chat_assistants")]
        Task<Create.ResponseBody> CreateChatAssistantAsync([JsonContent] Create.RequestBody request);

        /// <summary>
        /// List chat assistants
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 30)</param>
        /// <param name="orderBy">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <param name="name">Filter by assistant name</param>
        /// <param name="id">Filter by assistant ID</param>
        /// <returns>The list response containing assistant data</returns>
        [HttpGet("/api/v1/chat_assistants")]
        Task<List.ResponseBody> ListChatAssistantsAsync(
             int? page = null,
             int? pageSize = null,
             string? orderBy = null,
             bool? desc = null,
             string? name = null,
             string? id = null);

        /// <summary>
        /// Update a chat assistant
        /// </summary>
        /// <param name="assistantId">The ID of the assistant to update</param>
        /// <param name="request">The update request containing assistant data</param>
        /// <returns>The update response</returns>
        [HttpPut("/api/v1/chat_assistants/{assistantId}")]
        Task<Update.ResponseBody> UpdateChatAssistantAsync(
            [PathQuery] string assistantId,
            [JsonContent] Update.RequestBody request);

        /// <summary>
        /// Delete chat assistants
        /// </summary>
        /// <param name="request">The delete request containing assistant IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/chat_assistants")]
        Task<Delete.ResponseBody> DeleteChatAssistantsAsync([JsonContent] Delete.RequestBody request);
    }
} 