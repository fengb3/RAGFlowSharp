namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for updating chat sessions
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#update-chat-session">API Reference</see>
    /// </summary>
    public class Update
    {
        public class RequestBody
        {
            /// <summary>
            /// The name of the session
            /// </summary>
            public string? Name { get; set; }
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
} 