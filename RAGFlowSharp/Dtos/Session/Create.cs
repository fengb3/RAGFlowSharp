namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for creating chat sessions
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#create-chat-session">API Reference</see>
    /// </summary>
    public class Create
    {
        public class RequestBody
        {
            /// <summary>
            /// The name of the session
            /// </summary>
            public string Name { get; set; } = string.Empty;
        }

        public class ResponseBody : BaseResponse<Data>
        {
        }
    }
}