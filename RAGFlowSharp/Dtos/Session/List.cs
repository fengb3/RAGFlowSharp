namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for listing chat sessions
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-chat-sessions">API Reference</see>
    /// </summary>
    public class List
    {
        /// <summary>
        /// Response body containing an array of chat session data
        /// </summary>
        public class ResponseBody : BaseResponse<Data[]>
        {
        }
    }
} 