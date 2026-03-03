using System.Net.Http;
using System.Threading.Tasks;
using RAGFlowSharp.Dtos.Dataset;
using WebApiClientCore;
using WebApiClientCore.Attributes;

namespace RAGFlowSharp.Api
{
    /// <summary>
    /// Dataset Management API <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#dataset-management">Api Reference</see>
    /// </summary>
    public interface IDatasetApi
    {
        /// <summary>
        /// Creates a new dataset.
        /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#create-dataset">API Reference</see>
        /// </summary>
        /// <param name="requestBody">The request body containing dataset configuration.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response body with the created dataset details.</returns>
        [HttpPost("/api/v1/datasets")]
        Task<Create.ResponseBody> CreateDataset(
            [JsonContent] Create.RequestBody requestBody
        );

        /// <summary>
        /// Deletes one or more datasets by their IDs.
        /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#delete-datasets">API Reference</see>
        /// </summary>
        /// <param name="requestBody">The request body containing the IDs of datasets to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response body indicating success or failure.</returns>
        [HttpDelete("/api/v1/datasets")]
        Task<Delete.ResponseBody> DeleteDataset(
            [JsonContent] Delete.RequestBody requestBody
        );

        /// <summary>
        /// Updates the configuration of an existing dataset.
        /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#update-dataset">API Reference</see>
        /// </summary>
        /// <param name="datasetId">the id of dataset to be updated</param>
        /// <param name="requestBody">The request body containing the updated dataset configuration.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response body indicating success or failure.</returns>
        [HttpPut("/api/v1/datasets/{datasetId}")]
        Task<Update.ResponseBody> UpdateDataset(
            string datasetId,
            [JsonContent] Update.RequestBody requestBody
        );

        /// <summary>
        /// Lists datasets with optional filtering and pagination.
        /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-datasets">API Reference</see>
        /// </summary>
        /// <param name="page">The page number to retrieve (default: 1).</param>
        /// <param name="pageSize">The number of datasets per page (default: 30).</param>
        /// <param name="orderby">The field to sort by ("create_time" or "update_time").</param>
        /// <param name="desc">Whether to sort in descending order (default: true).</param>
        /// <param name="name">Filter by dataset name.</param>
        /// <param name="id">Filter by dataset ID.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response body with the list of datasets.</returns>
        [HttpGet("/api/v1/datasets")]
        ITask<List.ResponseBody> ListDatasets(
            // ITask<HttpResponseMessage> ListDatasets(
            string? page = null,
            [AliasAs("page_size")] string? pageSize = null,
            string? orderby = null,
            bool? desc = null,
            string? name = null,
            string? id = null
        );
    }
}