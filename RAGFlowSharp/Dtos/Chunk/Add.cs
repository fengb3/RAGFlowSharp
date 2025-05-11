using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Chunk
{
    /// <summary>
    /// DTOs for adding a chunk
    /// </summary>
    public class Add
    {
        /// <summary>
        /// Represents the request body for adding a chunk.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The text content of the chunk (required)
            /// </summary>
            public string Content { get; set; } = string.Empty;

            /// <summary>
            /// The key terms or phrases to tag with the chunk (optional)
            /// </summary>
            public List<string>? ImportantKeywords { get; set; }

            /// <summary>
            /// The questions to embed with the chunk (optional)
            /// </summary>
            public List<string>? Questions { get; set; }
        }

        /// <summary>
        /// Represents the response body for the add chunk operation.
        /// </summary>
        public class ResponseBody : BaseResponse<Chunk>
        {
        }
    }
} 