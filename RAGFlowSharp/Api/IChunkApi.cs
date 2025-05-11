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
        /// Add a chunk to a specified document in a specified dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="documentId">The ID of the document</param>
        /// <param name="request">The add chunk request</param>
        /// <returns>The response containing the created chunk</returns>
        [HttpPost("/api/v1/datasets/{datasetId}/documents/{documentId}/chunks")]
        Task<Add.ResponseBody> AddChunkAsync(
            [PathQuery] string datasetId,
            [PathQuery] string documentId,
            [JsonContent] Add.RequestBody request);

        /// <summary>
        /// List chunks in a specified document
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="documentId">The ID of the document</param>
        /// <param name="keywords">Keywords to match chunk content</param>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 1024)</param>
        /// <param name="id">Filter by chunk ID</param>
        /// <returns>The list response containing chunk data</returns>
        [HttpGet("/api/v1/datasets/{datasetId}/documents/{documentId}/chunks")]
        Task<List.ResponseBody> ListChunksAsync(
            [PathQuery] string datasetId,
            [PathQuery] string documentId,
            [PathQuery] string? keywords = null,
            [PathQuery] int? page = null,
            [PathQuery] int? pageSize = null,
            [PathQuery] string? id = null);

        /// <summary>
        /// Delete chunks by ID from a specified document in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="documentId">The ID of the document</param>
        /// <param name="request">The delete request containing chunk IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/datasets/{datasetId}/documents/{documentId}/chunks")]
        Task<Delete.ResponseBody> DeleteChunksAsync(
            [PathQuery] string datasetId,
            [PathQuery] string documentId,
            [JsonContent] Delete.RequestBody request);

        /// <summary>
        /// Update a chunk in a specified document in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="documentId">The ID of the document</param>
        /// <param name="chunkId">The ID of the chunk to update</param>
        /// <param name="request">The update request containing chunk data</param>
        /// <returns>The update response</returns>
        [HttpPut("/api/v1/datasets/{datasetId}/documents/{documentId}/chunks/{chunkId}")]
        Task<Update.ResponseBody> UpdateChunkAsync(
            [PathQuery] string datasetId,
            [PathQuery] string documentId,
            [PathQuery] string chunkId,
            [JsonContent] Update.RequestBody request);

        /// <summary>
        /// Retrieve chunks from specified datasets or documents
        /// </summary>
        /// <param name="request">The retrieval request</param>
        /// <returns>The retrieval response</returns>
        [HttpPost("/api/v1/retrieval")]
        Task<Retrieval.ResponseBody> RetrieveChunksAsync(
            [JsonContent] Retrieval.RequestBody request);
    }
} 