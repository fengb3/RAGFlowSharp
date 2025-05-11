using System.Collections.Generic;
using RAGFlowSharp.Dtos.ChatAssistant;

namespace RAGFlowSharp.Dtos.ChatAssistant
{
    /// <summary>
    /// DTOs for creating chat assistants
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#create-chat-assistant">API Reference</see>
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Represents the request body for creating a chat assistant.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The name of the assistant
            /// </summary>
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// Base64 encoded avatar
            /// </summary>
            public string? Avatar { get; set; }

            /// <summary>
            /// The IDs of the datasets to associate with this assistant
            /// </summary>
            public List<string>? DatasetIds { get; set; }

            /// <summary>
            /// The LLM model to use
            /// </summary>
            public LlmDto? Llm { get; set; }

            /// <summary>
            /// The system prompt for the assistant
            /// </summary>
            public PromptDto? Prompt { get; set; }
        }

        /// <summary>
        /// Represents the response body for the create chat assistant operation.
        /// </summary>
        public class ResponseBody : BaseResponse<ChatAssistant>
        {
        }
    }
} 