namespace RAGFlowSharp.Dtos.ChatAssistant
{
    /// <summary>
    /// DTOs for listing chat assistants
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-chat-assistants">API Reference</see>
    /// </summary>
    public class List
    {
        /// <summary>
        /// Response body containing an array of chat assistant data
        /// </summary>
        public class ResponseBody : BaseResponse<Data[]>
        {
        }
    }
} 