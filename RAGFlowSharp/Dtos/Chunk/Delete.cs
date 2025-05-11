using System;
using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Chunk
{
    /// <summary>
    /// DTOs for deleting chunks
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-chunks">API Reference</see>
    /// </summary>
    public class Delete
    {
        /// <summary>
        /// Represents the request body for deleting chunks.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the chunks to delete. If not specified, all chunks in the dataset will be deleted.
            /// </summary>
            public ICollection<string> ChunkIds { get; set; } = Array.Empty<string>();
        }

        /// <summary>
        /// Represents the response body for the delete chunks operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 