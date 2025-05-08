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
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the chunks to delete. If not specified, all chunks in the dataset will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
} 