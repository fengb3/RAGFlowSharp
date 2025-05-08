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
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the assistants to delete. If not specified, all assistants will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
} 