namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// Represents a chat message
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The unique identifier of the message
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The role of the message sender (user or assistant)
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// The content of the message
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the session this message belongs to
        /// </summary>
        public string SessionId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the assistant this message belongs to
        /// </summary>
        public string AssistantId { get; set; } = string.Empty;

        /// <summary>
        /// The creation date of the message in GMT format
        /// </summary>
        public string CreateDate { get; set; } = string.Empty;

        /// <summary>
        /// The creation timestamp of the message
        /// </summary>
        public long CreateTime { get; set; }
    }
} 