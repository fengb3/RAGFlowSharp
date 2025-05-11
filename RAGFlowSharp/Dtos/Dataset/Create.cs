using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Dataset
{
    /// <summary>
    /// DTOs for create dataset
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#create-dataset">API Reference</see>
    /// </summary>
    public class Create
    {
        public class RequestBody
        {
            /// <summary>
            /// The unique name of the dataset to create.
            /// Must begin with an English letter or underscore.
            /// Only English letters (a-z, A-Z), digits (0-9), and underscores allowed.
            /// Maximum 65,535 characters. Case-insensitive.
            /// </summary>
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// Base64 encoding of the avatar.
            /// </summary>
            public string? Avatar { get; set; }

            /// <summary>
            /// A brief description of the dataset to create.
            /// </summary>
            public string? Description { get; set; }

            /// <summary>
            /// The name of the embedding model to use, e.g., "BAAI/bge-zh-v1.5"
            /// </summary>
            public string? EmbeddingModel { get; set; }

            /// <summary>
            /// Specifies who can access the dataset. Options:
            /// "me": (Default) Only you can manage the dataset.
            /// "team": All team members can manage the dataset.
            /// </summary>
            public string? Permission { get; set; } = "me";

            /// <summary>
            /// The chunking method for the dataset. Available options:
            /// <list type="bullet">
            ///   <item><description>"naive": General</description></item>
            ///   <item><description>"manual": Manual</description></item>
            ///   <item><description>"qa": Q and A</description></item>
            ///   <item><description>"table": Table</description></item>
            ///   <item><description>"paper": Paper</description></item>
            ///   <item><description>"book": Book</description></item>
            ///   <item><description>"laws": Laws</description></item>
            ///   <item><description>"presentation": Presentation</description></item>
            ///   <item><description>"picture": Picture</description></item>
            ///   <item><description>"one": One</description></item>
            ///   <item><description>"email": Email</description></item>
            /// </list>
            /// </summary>
            public string? ChunkMethod { get; set; } = "naive";

            /// <summary>
            /// The configuration settings for the dataset parser.
            /// Attributes vary based on the selected chunk_method.
            /// </summary>
            public ParserConfig? ParserConfig { get; set; }
        }

        /// <summary>
        /// Configuration for the dataset parser, varying based on the chunking method
        /// </summary>
        public class ParserConfig
        {
            /// <summary>
            /// Number of automatically generated keywords.
            /// Default is 0. Minimum: 0, Maximum: 32. Used with "naive" chunk method.
            /// </summary>
            public int? AutoKeywords { get; set; }

            /// <summary>
            /// Number of automatically generated questions.
            /// Default is 0. Minimum: 0, Maximum: 10. Used with "naive" chunk method.
            /// </summary>
            public int? AutoQuestions { get; set; }

            /// <summary>
            /// Token count for chunks. Default is 128. Minimum: 1, Maximum: 2048.
            /// Used with "naive" chunk method.
            /// </summary>
            public int? ChunkTokenCount { get; set; }

            /// <summary>
            /// Delimiter for text chunking. Default is "\n". Used with "naive" chunk method.
            /// </summary>
            public string? Delimiter { get; set; }

            /// <summary>
            /// Whether to convert Excel documents into HTML format. Default is false.
            /// Used with "naive" chunk method.
            /// </summary>
            public bool? Html4Excel { get; set; }

            /// <summary>
            /// Layout recognition method. Default is "DeepDOC".
            /// Used with "naive" chunk method.
            /// </summary>
            public string? LayoutRecognize { get; set; }

            /// <summary>
            /// List of dataset IDs parsed using the Tag Chunk Method.
            /// Used with "naive" chunk method.
            /// </summary>
            public ICollection<string>? TagKbIds { get; set; }

            /// <summary>
            /// Page size for tasks. Default is 12. For PDF only. Used with "naive" chunk method.
            /// Minimum: 1
            /// </summary>
            public int? TaskPageSize { get; set; }

            /// <summary>
            /// Raptor-specific settings. Default is {"use_raptor": false}.
            /// Used with multiple chunk methods including "naive", "qa", "manuel", "paper", "book", "laws", and "presentation".
            /// </summary>
            public RaptorConfig? Raptor { get; set; }

            /// <summary>
            /// GraphRAG-specific settings. Default is {"use_graphrag": false}.
            /// Used with "naive" chunk method.
            /// </summary>
            public GraphRagConfig? GraphRag { get; set; }
        }

        /// <summary>
        /// Configuration for GraphRAG processing
        /// </summary>
        public class GraphRagConfig
        {
            /// <summary>
            /// Whether to use GraphRAG. Default is false.
            /// </summary>
            public bool UseGraphRag { get; set; } = false;
        }

        /// <summary>
        /// Configuration for Raptor processing
        /// </summary>
        public class RaptorConfig
        {
            /// <summary>
            /// Whether to use Raptor. Default is false.
            /// </summary>
            public bool UseRaptor { get; set; } = false;
        }

        public class ResponseBody : BaseResponse<Dataset>
        {
        }
    }
}