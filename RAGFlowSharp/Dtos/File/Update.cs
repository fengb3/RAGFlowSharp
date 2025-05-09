using System.Collections.Generic;
using RAGFlowSharp.Dtos;

namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// DTOs for document update operations
    /// </summary>
    public class Update
    {
        /// <summary>
        /// Represents the request body for updating a document.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The new name of the document
            /// </summary>
            public string? Name { get; set; }

            /// <summary>
            /// The meta fields of the document
            /// </summary>
            public Dictionary<string, object>? MetaFields { get; set; }

            /// <summary>
            /// The chunking method to apply to the document
            /// </summary>
            public string? ChunkMethod { get; set; }

            /// <summary>
            /// The configuration settings for the document parser
            /// </summary>
            public ParserConfig? ParserConfig { get; set; }
        }

        /// <summary>
        /// Represents the response body for the document update operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 