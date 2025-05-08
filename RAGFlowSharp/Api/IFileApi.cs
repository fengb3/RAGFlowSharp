using System.Threading.Tasks;
using RAGFlowSharp.Dtos.File;
using WebApiClientCore.Attributes;

namespace RAGFlowSharp.Api
{
    /// <summary>
    /// File management API interface
    /// </summary>
    public interface IFileApi
    {
        /// <summary>
        /// Upload a file to a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="request">The upload request containing file data and metadata</param>
        /// <returns>The upload response</returns>
        [HttpPost("/api/v1/datasets/{datasetId}/files")]
        Task<Upload.ResponseBody> UploadFileAsync(
            [PathQuery] string datasetId,
            [JsonContent] Upload.RequestBody request
        );

        /// <summary>
        /// List files in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 30)</param>
        /// <param name="orderBy">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <param name="name">Filter by file name</param>
        /// <param name="id">Filter by file ID</param>
        /// <returns>The list response containing file data</returns>
        [HttpGet("/api/v1/datasets/{datasetId}/files")]
        Task<List.ResponseBody> ListFilesAsync(
            string datasetId,
            int? page = null,
            int? pageSize = null,
            string? orderBy = null,
            bool? desc = null,
            string? name = null,
            string? id = null
        );

        /// <summary>
        /// Delete files from a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="request">The delete request containing file IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/datasets/{datasetId}/files")]
        Task<Delete.ResponseBody> DeleteFilesAsync(
            [PathQuery] string datasetId,
            [JsonContent] Delete.RequestBody request
        );
    }
}