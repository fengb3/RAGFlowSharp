using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Chunk
{
    /// <summary>
    /// DTOs for updating chunks
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#update-chunk">API Reference</see>
    /// </summary>
    public class Update
    {
        /// <summary>
        /// Represents the request body for updating a chunk.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The content of the chunk
            /// </summary>
            public string? Content { get; set; }

            /// <summary>
            /// A list of key terms or phrases to tag with the chunk.
            /// </summary>
            public ICollection<string>? ImportantKeywords { get; set; }
            
            /// <summary>
            /// The chunk's availability status in the dataset. Value options:
            /// </summary>
            public bool Available { get; set; } = true;
        }

        /// <summary>
        /// Represents the response body for the update chunk operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 