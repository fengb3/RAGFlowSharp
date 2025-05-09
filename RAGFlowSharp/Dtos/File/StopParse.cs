using System.Collections.Generic;
using RAGFlowSharp.Dtos;

namespace RAGFlowSharp.Dtos.File
{
    /// <summary>
    /// DTOs for stopping document parsing operations
    /// </summary>
    public class StopParse
    {
        /// <summary>
        /// Represents the request body for stopping document parsing.
        /// </summary>
        public class RequestBody
        {
            /// <summary>
            /// The IDs of the documents to stop parsing
            /// </summary>
            public List<string> DocumentIds { get; set; } = new List<string>();
        }

        /// <summary>
        /// Represents the response body for the stop parsing operation.
        /// </summary>
        public class ResponseBody : BaseResponse
        {
        }
    }
} 