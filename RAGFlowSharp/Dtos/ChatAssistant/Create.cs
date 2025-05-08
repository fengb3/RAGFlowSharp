namespace RAGFlowSharp.Dtos.ChatAssistant
{
    /// <summary>
    /// DTOs for creating chat assistants
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#create-chat-assistant">API Reference</see>
    /// </summary>
    public class Create
    {
        public class RequestBody
        {
            /// <summary>
            /// The name of the assistant
            /// </summary>
            public string Name { get; set; } = string.Empty;

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
            public string DatasetId { get; set; } = string.Empty;

            /// <summary>
            /// The ID of the LLM model to use
            /// </summary>
            public string LlmId { get; set; } = string.Empty;

            /// <summary>
            /// The system prompt for the assistant
            /// </summary>
            public string SystemPrompt { get; set; } = string.Empty;

            /// <summary>
            /// The temperature setting for the assistant (0.0 to 1.0)
            /// </summary>
            public double Temperature { get; set; } = 0.7;

            /// <summary>
            /// The top-p setting for the assistant (0.0 to 1.0)
            /// </summary>
            public double TopP { get; set; } = 1.0;

            /// <summary>
            /// The maximum number of tokens in the response
            /// </summary>
            public int MaxTokens { get; set; } = 2048;

            /// <summary>
            /// The frequency penalty setting for the assistant (-2.0 to 2.0)
            /// </summary>
            public double FrequencyPenalty { get; set; } = 0.0;

            /// <summary>
            /// The presence penalty setting for the assistant (-2.0 to 2.0)
            /// </summary>
            public double PresencePenalty { get; set; } = 0.0;

            /// <summary>
            /// The number of messages to keep in the conversation history
            /// </summary>
            public int MessageHistoryWindowSize { get; set; } = 10;

            /// <summary>
            /// The vector similarity weight for the assistant (0.0 to 1.0)
            /// </summary>
            public double VectorSimilarityWeight { get; set; } = 0.5;

            /// <summary>
            /// The similarity threshold for the assistant (0.0 to 1.0)
            /// </summary>
            public double SimilarityThreshold { get; set; } = 0.7;
        }

        public class ResponseBody : BaseResponse<Data>
        {
        }
    }
} 