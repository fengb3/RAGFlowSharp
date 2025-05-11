using System.Collections.Generic;
using RAGFlowSharp.Dtos.ChatAssistant;

namespace RAGFlowSharp.Dtos.ChatAssistant
{
    /// <summary>
    /// DTOs for updating chat assistants
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#update-chat-assistant">API Reference</see>
    /// </summary>
    public class Update
    {
        /// <summary>
        /// Represents the request body for updating a chat assistant.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The name of the assistant
            /// </summary>
            public string? Name { get; set; }

            /// <summary>
            /// Base64 encoded avatar
            /// </summary>
            public string? Avatar { get; set; }

            /// <summary>
            /// The IDs of the datasets to associate with this assistant
            /// </summary>
            public List<string>? DatasetIds { get; set; }

            /// <summary>
            /// The ID of the LLM model to use
            /// </summary>
            public LlmDto? Llm { get; set; }

            /// <summary>
            /// The system prompt for the assistant
            /// </summary>
            public PromptDto? Prompt { get; set; }
        }

        /// <summary>
        /// Represents the response body for the update chat assistant operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 