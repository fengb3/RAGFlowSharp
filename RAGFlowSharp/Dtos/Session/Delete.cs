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
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the sessions to delete. If not specified, all sessions will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
} 