using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.ChatAssistant
{
    public class PromptDto
    {
        public double? SimilarityThreshold { get; set; }
        public double? KeywordsSimilarityWeight { get; set; }
        public int? TopN { get; set; }
        public List<VariableDto>? Variables { get; set; }
        public string? RerankModel { get; set; }
        public int? TopK { get; set; }
        public string? EmptyResponse { get; set; }
        public string? Opener { get; set; }
        public bool? ShowQuote { get; set; }
        public string? Prompt { get; set; }
    }

    public class VariableDto
    {
        public string Key { get; set; } = string.Empty;
        public bool? Optional { get; set; }
    }
} 