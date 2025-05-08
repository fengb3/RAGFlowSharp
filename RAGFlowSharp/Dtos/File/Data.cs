namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// Represents a file in a dataset
    /// </summary>
    public class Data
    {
        /// <summary>
        /// The unique identifier of the file
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The size of the file in bytes
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The MIME type of the file
        /// </summary>
        public string MimeType { get; set; } = string.Empty;

        /// <summary>
        /// The status of the file processing
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the dataset this file belongs to
        /// </summary>
        public string DatasetId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the user who uploaded the file
        /// </summary>
        public string UploadedBy { get; set; } = string.Empty;

        /// <summary>
        /// The creation date of the file in GMT format
        /// </summary>
        public string CreateDate { get; set; } = string.Empty;

        /// <summary>
        /// The creation timestamp of the file
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// The last update date of the file in GMT format
        /// </summary>
        public string UpdateDate { get; set; } = string.Empty;

        /// <summary>
        /// The last update timestamp of the file
        /// </summary>
        public long UpdateTime { get; set; }
    }
} 