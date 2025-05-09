namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for conversing with a chat assistant
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#converse-with-chat-assistant">API Reference</see>
    /// </summary>
    public class Converse
    {
        /// <summary>
        /// Represents the request body for sending a message to a chat assistant.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The message content to send to the assistant
            /// </summary>
            public string Message { get; set; } = string.Empty;
        }

        /// <summary>
        /// Represents the response body containing the assistant's reply message.
        /// </summary>
        public class ResponseBody : BaseResponse<Message>
        {
        }
    }
} 