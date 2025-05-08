using System;

namespace RAGFlowSharp.Dtos.Dataset
{
    /// <summary>
    /// 表示数据集的详细信息。
    /// </summary>
    public class Data
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public string Avatar { get; set; } = string.Empty;
        
        public int ChunkCount { get; set; }
        
        public int DocumentCount { get; set; }
        
        public string EmbeddingModel { get; set; } = string.Empty;
        
        public string Language { get; set; } = string.Empty;
        
        public string ChunkMethod { get; set; } = string.Empty;
        
        public ParserConfig ParserConfig { get; set; } = new ParserConfig();
        
        public string Permission { get; set; } = string.Empty;
        
        public double SimilarityThreshold { get; set; }
        
        public string Status { get; set; } = string.Empty;
        
        public string TenantId { get; set; } = string.Empty;
        
        public string CreatedBy { get; set; } = string.Empty;
        
        public int TokenNum { get; set; }
        
        public string CreateDate { get; set; } = string.Empty;
        
        public long CreateTime { get; set; }
        
        public string UpdateDate { get; set; } = string.Empty;
        
        public long UpdateTime { get; set; }
        
        public double VectorSimilarityWeight { get; set; }
    }
    
    /// <summary>
    /// 数据集解析配置。
    /// </summary>
    public class ParserConfig
    {
        public int ChunkTokenNum { get; set; }
        
        public string Delimiter { get; set; } = string.Empty;
        
        public string[] EntityTypes { get; set; } = Array.Empty<string>();
    }
}