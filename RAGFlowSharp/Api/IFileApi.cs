using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
        /// Upload file to a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="file">List of file to upload</param>
        /// <returns>The upload response</returns>
        [HttpPost("/api/v1/datasets/{datasetId}/documents")]
        Task<Upload.ResponseBody> UploadFilesAsync(
            [PathQuery] string datasetId,
            FileInfo file
        );

        /// <summary>
        /// Update document configuration
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="documentId">The ID of the document</param>
        /// <param name="request">The update request containing new configuration</param>
        /// <returns>The update response</returns>
        [HttpPut("/api/v1/datasets/{datasetId}/documents/{documentId}")]
        Task<Update.ResponseBody> UpdateDocumentAsync(
            [PathQuery] string datasetId,
            [PathQuery] string documentId,
            [JsonContent] Update.RequestBody request
        );

        /// <summary>
        /// Download a document from a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="documentId">The ID of the document</param>
        /// <returns>The document content as a stream</returns>
        [HttpGet("/api/v1/datasets/{datasetId}/documents/{documentId}")]
        Task<Stream> DownloadDocumentAsync(
            [PathQuery] string datasetId,
            [PathQuery] string documentId
        );

        /// <summary>
        /// List files in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 30)</param>
        /// <param name="orderBy">Sort field (default: create_time)</param>
        /// <param name="desc">Sort in descending order (default: true)</param>
        /// <param name="keywords">Keywords to search in document titles</param>
        /// <param name="id">Filter by file ID</param>
        /// <param name="name">Filter by file name</param>
        /// <returns>The list response containing file data</returns>
        [HttpGet("/api/v1/datasets/{datasetId}/documents")]
        Task<List.ResponseBody> ListFilesAsync(
            [PathQuery] string datasetId,
            [PathQuery] int? page = null,
            [PathQuery] int? pageSize = null,
            [PathQuery] string? orderBy = null,
            [PathQuery] bool? desc = null,
            [PathQuery] string? keywords = null,
            [PathQuery] string? id = null,
            [PathQuery] string? name = null
        );

        /// <summary>
        /// Delete files from a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="request">The delete request containing file IDs</param>
        /// <returns>The delete response</returns>
        [HttpDelete("/api/v1/datasets/{datasetId}/documents")]
        Task<Delete.ResponseBody> DeleteFilesAsync(
            [PathQuery] string datasetId,
            [JsonContent] Delete.RequestBody request
        );

        /// <summary>
        /// Parse documents in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="request">The parse request containing document IDs</param>
        /// <returns>The parse response</returns>
        [HttpPost("/api/v1/datasets/{datasetId}/chunks")]
        Task<Parse.ResponseBody> ParseDocumentsAsync(
            [PathQuery] string datasetId,
            [JsonContent] Parse.RequestBody request
        );

        /// <summary>
        /// Stop parsing documents in a dataset
        /// </summary>
        /// <param name="datasetId">The ID of the dataset</param>
        /// <param name="request">The stop request containing document IDs</param>
        /// <returns>The stop response</returns>
        [HttpDelete("/api/v1/datasets/{datasetId}/chunks")]
        Task<StopParse.ResponseBody> StopParsingDocumentsAsync(
            [PathQuery] string datasetId,
            [JsonContent] StopParse.RequestBody request
        );
    }
}