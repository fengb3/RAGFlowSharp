namespace RAGFlowSharp.Dtos.ChatAssistant
{
    /// <summary>
    /// Represents a chat assistant
    /// </summary>
    public class ChatAssistant
    {
        /// <summary>
        /// The unique identifier of the assistant
        /// </summary>
        public string Id { get; set; } = string.Empty;

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
        /// The ID of the dataset associated with this assistant
        /// </summary>
        public string DatasetId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the LLM model used by this assistant
        /// </summary>
        public string LlmId { get; set; } = string.Empty;

        /// <summary>
        /// The system prompt for the assistant
        /// </summary>
        public string SystemPrompt { get; set; } = string.Empty;

        /// <summary>
        /// The temperature setting for the assistant (0.0 to 1.0)
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// The top-p setting for the assistant (0.0 to 1.0)
        /// </summary>
        public double TopP { get; set; }

        /// <summary>
        /// The maximum number of tokens in the response
        /// </summary>
        public int MaxTokens { get; set; }

        /// <summary>
        /// The frequency penalty setting for the assistant (-2.0 to 2.0)
        /// </summary>
        public double FrequencyPenalty { get; set; }

        /// <summary>
        /// The presence penalty setting for the assistant (-2.0 to 2.0)
        /// </summary>
        public double PresencePenalty { get; set; }

        /// <summary>
        /// The number of messages to keep in the conversation history
        /// </summary>
        public int MessageHistoryWindowSize { get; set; }

        /// <summary>
        /// The vector similarity weight for the assistant (0.0 to 1.0)
        /// </summary>
        public double VectorSimilarityWeight { get; set; }

        /// <summary>
        /// The similarity threshold for the assistant (0.0 to 1.0)
        /// </summary>
        public double SimilarityThreshold { get; set; }

        /// <summary>
        /// The status of the assistant
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The creation date of the assistant in GMT format
        /// </summary>
        public string CreateDate { get; set; } = string.Empty;

        /// <summary>
        /// The creation timestamp of the assistant
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// The last update date of the assistant in GMT format
        /// </summary>
        public string UpdateDate { get; set; } = string.Empty;

        /// <summary>
        /// The last update timestamp of the assistant
        /// </summary>
        public long UpdateTime { get; set; }
    }
} 