using System;
using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Session
{
    /// <summary>
    /// DTOs for deleting chat messages
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-messages">API Reference</see>
    /// </summary>
    public class DeleteMessages
    {
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the messages to delete. If not specified, all messages in the session will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
} 