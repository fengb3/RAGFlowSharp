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
            /// A brief description of the assistant
            /// </summary>
            public string? Description { get; set; }

            /// <summary>
            /// Base64 encoded avatar
            /// </summary>
            public string? Avatar { get; set; }

            /// <summary>
            /// The ID of the dataset to associate with this assistant
            /// </summary>
            public string? DatasetId { get; set; }

            /// <summary>
            /// The ID of the LLM model to use
            /// </summary>
            public string? LlmId { get; set; }

            /// <summary>
            /// The system prompt for the assistant
            /// </summary>
            public string? SystemPrompt { get; set; }

            /// <summary>
            /// The temperature setting for the assistant (0.0 to 1.0)
            /// </summary>
            public double? Temperature { get; set; }

            /// <summary>
            /// The top-p setting for the assistant (0.0 to 1.0)
            /// </summary>
            public double? TopP { get; set; }

            /// <summary>
            /// The maximum number of tokens in the response
            /// </summary>
            public int? MaxTokens { get; set; }

            /// <summary>
            /// The frequency penalty setting for the assistant (-2.0 to 2.0)
            /// </summary>
            public double? FrequencyPenalty { get; set; }

            /// <summary>
            /// The presence penalty setting for the assistant (-2.0 to 2.0)
            /// </summary>
            public double? PresencePenalty { get; set; }

            /// <summary>
            /// The number of messages to keep in the conversation history
            /// </summary>
            public int? MessageHistoryWindowSize { get; set; }

            /// <summary>
            /// The vector similarity weight for the assistant (0.0 to 1.0)
            /// </summary>
            public double? VectorSimilarityWeight { get; set; }

            /// <summary>
            /// The similarity threshold for the assistant (0.0 to 1.0)
            /// </summary>
            public double? SimilarityThreshold { get; set; }
        }

        /// <summary>
        /// Represents the response body for the update chat assistant operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 