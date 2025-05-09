using System;
using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.ChatAssistant
{
    /// <summary>
    /// DTOs for deleting chat assistants
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-chat-assistants">API Reference</see>
    /// </summary>
    public class Delete
    {
        /// <summary>
        /// Represents the request body for deleting chat assistants.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the assistants to delete. If not specified, all assistants will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        /// <summary>
        /// Represents the response body for the delete chat assistants operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 