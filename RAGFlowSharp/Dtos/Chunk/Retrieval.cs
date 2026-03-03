using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Chunk
{
    /// <summary>
    /// DTOs for chunk retrieval
    /// </summary>
    public class Retrieval
    {
        /// <summary>
        /// Represents the request body for retrieving chunks.
        /// </summary>
        public class RequestBody
        {
            public string Question { get; set; } = string.Empty;
            public List<string>? DatasetIds { get; set; }
            public List<string>? DocumentIds { get; set; }
            public int? Page { get; set; }
            public int? PageSize { get; set; }
            public double? SimilarityThreshold { get; set; }
            public double? VectorSimilarityWeight { get; set; }
            public int? TopK { get; set; }
            public string? RerankId { get; set; }
            public bool? Keyword { get; set; }
            public bool? Highlight { get; set; }
        }

        /// <summary>
        /// Represents a retrieved chunk in the response.
        /// </summary>
        public class RetrievedChunk
        {
            public string Content { get; set; } = string.Empty;
            public string? ContentLtks { get; set; }
            public string DatasetId { get; set; } = string.Empty;
            public string DocumentId { get; set; } = string.Empty;
            public string? DocumentKeyword { get; set; }
            public string? Highlight { get; set; }
            public string Id { get; set; } = string.Empty;
            public string? ImageId { get; set; }
            public List<string>? ImportantKeywords { get; set; }
            public string? KbId { get; set; }
            public List<object>? Positions { get; set; }
            public double? Similarity { get; set; }
            public double? TermSimilarity { get; set; }
            public double? VectorSimilarity { get; set; }
        }

        /// <summary>
        /// Represents a document aggregation in the response.
        /// </summary>
        public class DocAgg
        {
            public int Count { get; set; }
            public string DocId { get; set; } = string.Empty;
            public string DocName { get; set; } = string.Empty;
        }

        /// <summary>
        /// Represents the response body for the retrieval operation.
        /// </summary>
        public class ResponseBody : BaseResponse<ResponseData>
        {
        }

        public class ResponseData
        {
            public List<RetrievedChunk> Chunks { get; set; } = new List<RetrievedChunk>();
            public List<DocAgg>? DocAggs { get; set; }
            public int Total { get; set; }
        }
    }
}