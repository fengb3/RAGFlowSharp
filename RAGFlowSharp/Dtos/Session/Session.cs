namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// Represents a chat session
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The unique identifier of the session
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The name of the session
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the assistant this session belongs to
        /// </summary>
        public string AssistantId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the user who created this session
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// The status of the session
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The creation date of the session in GMT format
        /// </summary>
        public string CreateDate { get; set; } = string.Empty;

        /// <summary>
        /// The creation timestamp of the session
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// The last update date of the session in GMT format
        /// </summary>
        public string UpdateDate { get; set; } = string.Empty;

        /// <summary>
        /// The last update timestamp of the session
        /// </summary>
        public long UpdateTime { get; set; }
    }
} 