using System;

namespace RAGFlowSharp.Dtos.Dataset
{
    /// <summary>
    /// Represents detailed information about a dataset.
    /// </summary>
    public class Dataset
    {
        /// <summary>
        /// Gets or sets the unique identifier of the dataset.
        /// </summary>
        public string Id { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the name of the dataset.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the description of the dataset.
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Gets or sets the avatar (image) of the dataset.
        /// </summary>
        public string Avatar { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the total number of chunks in the dataset.
        /// </summary>
        public int ChunkCount { get; set; }
        
        /// <summary>
        /// Gets or sets the total number of documents in the dataset.
        /// </summary>
        public int DocumentCount { get; set; }
        
        /// <summary>
        /// Gets or sets the embedding model used for the dataset.
        /// </summary>
        public string EmbeddingModel { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the language of the dataset content.
        /// </summary>
        public string Language { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the method used for chunking the dataset content.
        /// </summary>
        public string ChunkMethod { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the parser configuration for the dataset.
        /// </summary>
        public ParserConfig ParserConfig { get; set; } = new ParserConfig();
        
        /// <summary>
        /// Gets or sets the permission level for the dataset.
        /// </summary>
        public string Permission { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the similarity threshold for vector search.
        /// </summary>
        public double SimilarityThreshold { get; set; }
        
        /// <summary>
        /// Gets or sets the current status of the dataset.
        /// </summary>
        public string Status { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the tenant ID associated with the dataset.
        /// </summary>
        public string TenantId { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the ID of the user who created the dataset.
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the total number of tokens in the dataset.
        /// </summary>
        public int TokenNum { get; set; }
        
        /// <summary>
        /// Gets or sets the creation date of the dataset.
        /// </summary>
        public string CreateDate { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the creation timestamp of the dataset.
        /// </summary>
        public long CreateTime { get; set; }
        
        /// <summary>
        /// Gets or sets the last update date of the dataset.
        /// </summary>
        public string UpdateDate { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the last update timestamp of the dataset.
        /// </summary>
        public long UpdateTime { get; set; }
        
        /// <summary>
        /// Gets or sets the weight for vector similarity in search results.
        /// </summary>
        public double VectorSimilarityWeight { get; set; }
    }
    
    /// <summary>
    /// Configuration for dataset content parsing.
    /// </summary>
    public class ParserConfig
    {
        /// <summary>
        /// Gets or sets the number of tokens per chunk.
        /// </summary>
        public int ChunkTokenNum { get; set; }
        
        /// <summary>
        /// Gets or sets the delimiter used for text splitting.
        /// </summary>
        public string Delimiter { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the types of entities to extract.
        /// </summary>
        public string[] EntityTypes { get; set; } = Array.Empty<string>();
    }
}