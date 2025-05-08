using System;
using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Dataset
{
    /// <summary>
    /// DTOs for delete dataset
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-datasets">API Reference</see>
    /// </summary>
    public class Delete
    {
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the datasets to delete. If it is not specified, all datasets will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
}