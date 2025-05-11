namespace RAGFlowSharp.Dtos.Agent
{
    /// <summary>
    /// Represents an agent
    /// </summary>
    public class Agent
    {
        /// <summary>
        /// The unique identifier of the agent
        /// </summary>
        public string Id { get; set; } = string.Empty;

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
        /// The ID of the dataset associated with this agent
        /// </summary>
        public string DatasetId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the LLM model used by this agent
        /// </summary>
        public string LlmId { get; set; } = string.Empty;

        /// <summary>
        /// The system prompt for the agent
        /// </summary>
        public string SystemPrompt { get; set; } = string.Empty;

        /// <summary>
        /// The temperature setting for the agent (0.0 to 1.0)
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// The top-p setting for the agent (0.0 to 1.0)
        /// </summary>
        public double TopP { get; set; }

        /// <summary>
        /// The maximum number of tokens in the response
        /// </summary>
        public int MaxTokens { get; set; }

        /// <summary>
        /// The frequency penalty setting for the agent (-2.0 to 2.0)
        /// </summary>
        public double FrequencyPenalty { get; set; }

        /// <summary>
        /// The presence penalty setting for the agent (-2.0 to 2.0)
        /// </summary>
        public double PresencePenalty { get; set; }

        /// <summary>
        /// The vector similarity weight for the agent (0.0 to 1.0)
        /// </summary>
        public double VectorSimilarityWeight { get; set; }

        /// <summary>
        /// The similarity threshold for the agent (0.0 to 1.0)
        /// </summary>
        public double SimilarityThreshold { get; set; }

        /// <summary>
        /// The status of the agent
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The creation date of the agent in GMT format
        /// </summary>
        public string CreateDate { get; set; } = string.Empty;

        /// <summary>
        /// The creation timestamp of the agent
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// The last update date of the agent in GMT format
        /// </summary>
        public string UpdateDate { get; set; } = string.Empty;

        /// <summary>
        /// The last update timestamp of the agent
        /// </summary>
        public long UpdateTime { get; set; }
    }
} 