namespace RAGFlowSharp.Dtos.Dataset
{
    /// <summary>
    /// DTOs for listing datasets
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-datasets">API Reference</see>
    /// </summary>
    public class List
    {
        /// <summary>
        /// Response body containing an array of dataset data
        /// </summary>
        public class ResponseBody : BaseResponse<Data[]>
        {
        }
    }
}