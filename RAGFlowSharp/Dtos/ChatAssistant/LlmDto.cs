namespace RAGFlowSharp.Dtos.ChatAssistant
{
    public class LlmDto
    {
        public string? ModelName { get; set; }
        public double? Temperature { get; set; }
        public double? TopP { get; set; }
        public double? PresencePenalty { get; set; }
        public double? FrequencyPenalty { get; set; }
    }
} 