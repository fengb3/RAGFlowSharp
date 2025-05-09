using System.Collections.Generic;
using RAGFlowSharp.Dtos;

namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// DTOs for document parsing operations
    /// </summary>
    public class Parse
    {
        /// <summary>
        /// Represents the request body for parsing documents.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the documents to parse
            /// </summary>
            public List<string> DocumentIds { get; set; } = new List<string>();
        }

        /// <summary>
        /// Represents the response body for the document parsing operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 