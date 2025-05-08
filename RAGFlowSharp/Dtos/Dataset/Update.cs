namespace RAGFlowSharp.Dtos.Dataset
{
    public class Update
    {
        public class RequestBody
        {
            /// <summary>
            /// The revised name of the dataset.
            /// Must begin with an English letter or underscore.
            /// Only English letters (a-z, A-Z), digits (0-9), and underscores allowed.
            /// Maximum 65,535 characters. Case-insensitive.
            /// </summary>
            public string? Name { get; set; }

            /// <summary>
            /// The updated embedding model name, e.g., "BAAI/bge-zh-v1.5".
            /// Ensure that "chunk_count" is 0 before updating "embedding_model".
            /// </summary>
            public string? EmbeddingModel { get; set; }

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
            public string? ChunkMethod { get; set; }

            /// <summary>
            /// A brief description of the dataset.
            /// </summary>
            public string? Description { get; set; }

            /// <summary>
            /// Base64 encoding of the avatar.
            /// </summary>
            public string? Avatar { get; set; }
        }

        public class ResponseBody : BaseResponse
        {
        }
    }
}