namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for creating chat sessions
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#create-chat-session">API Reference</see>
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Represents the request body for creating a chat session.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The name of the session
            /// </summary>
            public string Name { get; set; } = string.Empty;
        }

        /// <summary>
        /// Represents the response body for the create chat session operation.
        /// </summary>
        public class ResponseBody : BaseResponse<Data>
        {
        }
    }
}