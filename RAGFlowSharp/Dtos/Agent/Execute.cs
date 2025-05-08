using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Agent
{
    /// <summary>
    /// DTOs for executing agents
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#execute-agent">API Reference</see>
    /// </summary>
    public class Execute
    {
        public class RequestBody
        {
            /// <summary>
            /// The input parameters for the agent execution
            /// </summary>
            public IDictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        }

        public class ResponseBody : BaseResponse<IDictionary<string, object>>
        {
        }
    }
} 