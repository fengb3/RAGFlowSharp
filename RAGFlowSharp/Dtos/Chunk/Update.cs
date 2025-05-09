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
            /// The name of the chunk
            /// </summary>
            public string? Name { get; set; }

            /// <summary>
            /// The content of the chunk
            /// </summary>
            public string? Content { get; set; }

            /// <summary>
            /// The position of the chunk in the document
            /// </summary>
            public int? Position { get; set; }
        }

        /// <summary>
        /// Represents the response body for the update chunk operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 