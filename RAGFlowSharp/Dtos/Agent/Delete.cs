using System;
using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Agent
{
    /// <summary>
    /// DTOs for deleting agents
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-agents">API Reference</see>
    /// </summary>
    public class Delete
    {
        /// <summary>
        /// Represents the request body for deleting agents.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the agents to delete. If not specified, all agents will be deleted.
            /// </summary>
            public ICollection<string> Ids { get; set; } = Array.Empty<string>();
        }

        /// <summary>
        /// Represents the response body for the delete agents operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 