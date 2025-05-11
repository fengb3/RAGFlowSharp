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
        [HttpPost("/api/v1/chats")]
        Task<Create.ResponseBody> CreateChatAssistantAsync([JsonContent] Create.RequestBody request);

        /// <summary>
        /// List chat assistants
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="page_size">Number of items per page (default: 30)</param>
        /// <param name="orderby">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <param name="name">Filter by assistant name</param>
        /// <param name="id">Filter by assistant ID</param>
        /// <returns>The list response containing assistant data</returns>
        [HttpGet("/api/v1/chats")]
        Task<List.ResponseBody> ListChatAssistantsAsync(
             int? page = null,
             int? page_size = null,
             string? orderby = null,
             bool? desc = null,
             string? name = null,
             string? id = null);

        /// <summary>
        /// Update a chat assistant
        /// </summary>
        /// <param name="chatId">The ID of the assistant to update</param>
        /// <param name="request">The update request containing assistant data</param>
        /// <returns>The update response</returns>
        [HttpPut("/api/v1/chats/{chatId}")]
        Task<Update.ResponseBody> UpdateChatAssistantAsync(
            [PathQuery] string chatId,
            [JsonContent] Update.RequestBody request);

        /// <summary>
        /// Delete chat assistants
        /// </summary>
        /// <param name="request">The delete request containing assistant IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/chats")]
        Task<Delete.ResponseBody> DeleteChatAssistantsAsync([JsonContent] Delete.RequestBody request);
    }
} 