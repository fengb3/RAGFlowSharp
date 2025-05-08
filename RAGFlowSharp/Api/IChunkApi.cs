using System.Threading.Tasks;
using RAGFlowSharp.Dtos.Chunk;
using WebApiClientCore.Attributes;

namespace RAGFlowSharp.Api
{
    /// <summary>
    /// Chunk management API interface
    /// </summary>
    public interface IChunkApi
    {
        /// <summary>
        /// List chunks in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 30)</param>
        /// <param name="orderBy">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <param name="name">Filter by chunk name</param>
        /// <param name="id">Filter by chunk ID</param>
        /// <returns>The list response containing chunk data</returns>
        [HttpGet("/api/v1/datasets/{datasetId}/chunks")]
        Task<List.ResponseBody> ListChunksAsync(
            [PathQuery] string datasetId,
             int? page = null,
             int? pageSize = null,
             string? orderBy = null,
             bool? desc = null,
             string? name = null,
             string? id = null);

        /// <summary>
        /// Update a chunk in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="chunkId">The ID of the chunk to update</param>
        /// <param name="request">The update request containing chunk data</param>
        /// <returns>The update response</returns>
        [HttpPut("/api/v1/datasets/{datasetId}/chunks/{chunkId}")]
        Task<Update.ResponseBody> UpdateChunkAsync(
            [PathQuery] string datasetId,
            [PathQuery] string chunkId,
            [JsonContent] Update.RequestBody request);

        /// <summary>
        /// Delete chunks from a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="request">The delete request containing chunk IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/datasets/{datasetId}/chunks")]
        Task<Delete.ResponseBody> DeleteChunksAsync(
            [PathQuery] string datasetId,
            [JsonContent] Delete.RequestBody request);
    }
} 