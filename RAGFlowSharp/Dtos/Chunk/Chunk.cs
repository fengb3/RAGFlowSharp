namespace RAGFlowSharp.Dtos.Chunk
{
    /// <summary>
    /// Represents a chunk in a dataset
    /// </summary>
    public class Chunk
    {
        /// <summary>
        /// The unique identifier of the chunk
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The name of the chunk
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The content of the chunk
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the dataset this chunk belongs to
        /// </summary>
        public string DatasetId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the file this chunk belongs to
        /// </summary>
        public string FileId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the document this chunk belongs to
        /// </summary>
        public string DocumentId { get; set; } = string.Empty;

        /// <summary>
        /// The position of the chunk in the document
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// The number of tokens in the chunk
        /// </summary>
        public int TokenCount { get; set; }

        /// <summary>
        /// The embedding vector of the chunk
        /// </summary>
        public float[]? Embedding { get; set; }

        /// <summary>
        /// The creation date of the chunk in GMT format
        /// </summary>
        public string CreateDate { get; set; } = string.Empty;

        /// <summary>
        /// The creation timestamp of the chunk
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// The last update date of the chunk in GMT format
        /// </summary>
        public string UpdateDate { get; set; } = string.Empty;

        /// <summary>
        /// The last update timestamp of the chunk
        /// </summary>
        public long UpdateTime { get; set; }
    }
} 