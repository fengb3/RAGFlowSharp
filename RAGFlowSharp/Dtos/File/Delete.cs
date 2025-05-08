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
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the files to delete. If not specified, all files in the dataset will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
} 