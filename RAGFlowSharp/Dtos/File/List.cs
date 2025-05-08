namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// DTOs for listing files
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-files">API Reference</see>
    /// </summary>
    public class List
    {
        /// <summary>
        /// Response body containing an array of file data
        /// </summary>
        public class ResponseBody : BaseResponse<Data[]>
        {
        }
    }
} 