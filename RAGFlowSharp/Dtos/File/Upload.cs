namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// DTOs for file upload operations
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#upload-file">API Reference</see>
    /// </summary>
    public class Upload
    {
        /// <summary>
        /// Represents the request body for uploading a file.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The name of the file to upload
            /// </summary>
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// The MIME type of the file
            /// </summary>
            public string MimeType { get; set; } = string.Empty;

            /// <summary>
            /// The base64-encoded content of the file
            /// </summary>
            public string Content { get; set; } = string.Empty;
        }

        /// <summary>
        /// Represents the response body for the file upload operation.
        /// </summary>
        public class ResponseBody : BaseResponse<Document[]>
        {
        }
    }
} 