namespace RAGFlowSharp.Dtos.Agent
{
    /// <summary>
    /// DTOs for creating agents
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#create-agent">API Reference</see>
    /// </summary>
    public class Create
    {
        /// <summary>
        /// 
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The name of the agent
            /// </summary>
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// A brief description of the agent
            /// </summary>
            public string? Description { get; set; }

            /// <summary>
            /// Base64 encoded avatar
            /// </summary>
            public string? Avatar { get; set; }

            /// <summary>
            /// The ID of the dataset to associate with this agent
            /// </summary>
            public string DatasetId { get; set; } = string.Empty;

            /// <summary>
            /// The ID of the LLM model to use
            /// </summary>
            public string LlmId { get; set; } = string.Empty;

            /// <summary>
            /// The system prompt for the agent
            /// </summary>
            public string SystemPrompt { get; set; } = string.Empty;

            /// <summary>
            /// The temperature setting for the agent (0.0 to 1.0)
            /// </summary>
            public double Temperature { get; set; } = 0.7;

            /// <summary>
            /// The top-p setting for the agent (0.0 to 1.0)
            /// </summary>
            public double TopP { get; set; } = 1.0;

            /// <summary>
            /// The maximum number of tokens in the response
            /// </summary>
            public int MaxTokens { get; set; } = 2048;

            /// <summary>
            /// The frequency penalty setting for the agent (-2.0 to 2.0)
            /// </summary>
            public double FrequencyPenalty { get; set; } = 0.0;

            /// <summary>
            /// The presence penalty setting for the agent (-2.0 to 2.0)
            /// </summary>
            public double PresencePenalty { get; set; } = 0.0;

            /// <summary>
            /// The vector similarity weight for the agent (0.0 to 1.0)
            /// </summary>
            public double VectorSimilarityWeight { get; set; } = 0.5;

            /// <summary>
            /// The similarity threshold for the agent (0.0 to 1.0)
            /// </summary>
            public double SimilarityThreshold { get; set; } = 0.7;
        }

        /// <summary>
        /// 
        /// </summary>
        public class ResponseBody : BaseResponse<Agent>
        {
        }
    }
} 