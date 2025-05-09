using System;
using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for deleting chat sessions
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-chat-sessions">API Reference</see>
    /// </summary>
    public class Delete
    {
        /// <summary>
        /// Represents the request body for deleting chat sessions.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the sessions to delete. If not specified, all sessions will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        /// <summary>
        /// Represents the response body for the delete chat sessions operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 