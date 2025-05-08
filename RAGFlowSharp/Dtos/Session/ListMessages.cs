namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for listing chat messages
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-messages">API Reference</see>
    /// </summary>
    public class ListMessages
    {
        /// <summary>
        /// Response body containing an array of chat message data
        /// </summary>
        public class ResponseBody : BaseResponse<Message[]>
        {
        }
    }
} 