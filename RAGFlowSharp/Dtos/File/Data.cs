using System;
using System.Collections.Generic;

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

        /// <summary>
        /// The chunking method used for this file
        /// </summary>
        public string ChunkMethod { get; set; } = string.Empty;

        /// <summary>
        /// The location of the file
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// The thumbnail of the file (if any)
        /// </summary>
        public string? Thumbnail { get; set; }

        /// <summary>
        /// The type of the file
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The source type of the file
        /// </summary>
        public string SourceType { get; set; } = string.Empty;

        /// <summary>
        /// The number of chunks in the file
        /// </summary>
        public int ChunkCount { get; set; }

        /// <summary>
        /// The number of tokens in the file
        /// </summary>
        public int TokenCount { get; set; }

        /// <summary>
        /// The progress of file processing (0-100)
        /// </summary>
        public double Progress { get; set; }

        /// <summary>
        /// The progress message
        /// </summary>
        public string ProgressMsg { get; set; } = string.Empty;

        /// <summary>
        /// The time when processing began
        /// </summary>
        public string? ProcessBeginAt { get; set; }

        /// <summary>
        /// The duration of processing in seconds
        /// </summary>
        public double ProcessDuration { get; set; }

        /// <summary>
        /// The parser configuration for this file
        /// </summary>
        public ParserConfig? ParserConfig { get; set; }
    }
} 