namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// Represents the configuration settings for document parsing
    /// </summary>
    public class ParserConfig
    {
        /// <summary>
        /// The number of tokens per chunk
        /// </summary>
        public int ChunkTokenCount { get; set; } = 256;

        /// <summary>
        /// Whether to recognize layout
        /// </summary>
        public object LayoutRecognize { get; set; } = true;

        /// <summary>
        /// Whether to convert Excel to HTML
        /// </summary>
        public bool Html4Excel { get; set; } = false;

        /// <summary>
        /// The delimiter for text splitting
        /// </summary>
        public string Delimiter { get; set; } = "\n";

        /// <summary>
        /// The page size for PDF processing
        /// </summary>
        public int TaskPageSize { get; set; } = 12;

        /// <summary>
        /// RAPTOR-specific settings
        /// </summary>
        public RaptorConfig Raptor { get; set; } = new RaptorConfig();
    }

    /// <summary>
    /// Represents RAPTOR-specific configuration settings
    /// </summary>
    public class RaptorConfig
    {
        /// <summary>
        /// Whether to use RAPTOR
        /// </summary>
        public bool UseRaptor { get; set; } = false;
    }
} 