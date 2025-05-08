namespace RAGFlowSharp.Dtos.Agent
{
    /// <summary>
    /// DTOs for listing agents
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-agents">API Reference</see>
    /// </summary>
    public class List
    {
        /// <summary>
        /// Response body containing an array of agent data
        /// </summary>
        public class ResponseBody : BaseResponse<Data[]>
        {
        }
    }
} 