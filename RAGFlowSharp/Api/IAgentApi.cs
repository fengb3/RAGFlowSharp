using System.Threading.Tasks;
using RAGFlowSharp.Dtos.Agent;
using WebApiClientCore.Attributes;

namespace RAGFlowSharp.Api
{
    /// <summary>
    /// Agent management API interface
    /// </summary>
    public interface IAgentApi
    {
        /// <summary>
        /// Create a new agent
        /// </summary>
        /// <param name="request">The create request containing agent configuration</param>
        /// <returns>The create response</returns>
        [HttpPost("/api/v1/agents")]
        Task<Create.ResponseBody> CreateAgentAsync([JsonContent] Create.RequestBody request);

        /// <summary>
        /// List agents
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 30)</param>
        /// <param name="orderBy">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <param name="name">Filter by agent name</param>
        /// <param name="id">Filter by agent ID</param>
        /// <returns>The list response containing agent data</returns>
        [HttpGet("/api/v1/agents")]
        Task<List.ResponseBody> ListAgentsAsync(
             int? page = null,
             int? pageSize = null,
             string? orderBy = null,
             bool? desc = null,
             string? name = null,
             string? id = null);

        /// <summary>
        /// Update an agent
        /// </summary>
        /// <param name="agentId">The ID of the agent to update</param>
        /// <param name="request">The update request containing agent data</param>
        /// <returns>The update response</returns>
        [HttpPut("/api/v1/agents/{agentId}")]
        Task<Update.ResponseBody> UpdateAgentAsync(
            [PathQuery] string agentId,
            [JsonContent] Update.RequestBody request);

        /// <summary>
        /// Delete agents
        /// </summary>
        /// <param name="request">The delete request containing agent IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/agents")]
        Task<Delete.ResponseBody> DeleteAgentsAsync([JsonContent] Delete.RequestBody request);

        /// <summary>
        /// Execute an agent
        /// </summary>
        /// <param name="agentId">The ID of the agent to execute</param>
        /// <param name="request">The execution request containing input parameters</param>
        /// <returns>The execution response</returns>
        [HttpPost("/api/v1/agents/{agentId}/execute")]
        Task<Execute.ResponseBody> ExecuteAgentAsync(
            [PathQuery] string agentId,
            [JsonContent] Execute.RequestBody request);
    }
} 