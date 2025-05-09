using System;
using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// DTOs for deleting files
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-files">API Reference</see>
    /// </summary>
    public class Delete
    {
        /// <summary>
        /// Represents the request body for deleting files.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the files to delete. If not specified, all files in the dataset will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        /// <summary>
        /// Represents the response body for the delete files operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 