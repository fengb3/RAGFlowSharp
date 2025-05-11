using System.Collections.Generic;
using RAGFlowSharp.Dtos.ChatAssistant;

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
        public List<string>? DatasetIds { get; set; }

        /// <summary>
        /// The ID of the LLM model used by this assistant
        /// </summary>
        public LlmDto? Llm { get; set; }

        /// <summary>
        /// The system prompt for the assistant
        /// </summary>
        public PromptDto? Prompt { get; set; }

        /// <summary>
        /// The language of the assistant
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// The status of the assistant
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// The type of the assistant
        /// </summary>
        public string? PromptType { get; set; }

        /// <summary>
        /// The tenant ID of the assistant
        /// </summary>
        public string? TenantId { get; set; }

        /// <summary>
        /// The creation date of the assistant in GMT format
        /// </summary>
        public string? CreateDate { get; set; }

        /// <summary>
        /// The creation timestamp of the assistant
        /// </summary>
        public long? CreateTime { get; set; }

        /// <summary>
        /// The last update date of the assistant in GMT format
        /// </summary>
        public string? UpdateDate { get; set; }

        /// <summary>
        /// The last update timestamp of the assistant
        /// </summary>
        public long? UpdateTime { get; set; }

        /// <summary>
        /// The top-k setting for the assistant
        /// </summary>
        public int? TopK { get; set; }

        /// <summary>
        /// The do-refer setting for the assistant
        /// </summary>
        public string? DoRefer { get; set; }
    }
} 