using System.Collections.Generic;
using RAGFlowSharp.Dtos.File;

namespace RAGFlowSharp.Dtos.Chunk
{
    /// <summary>
    /// DTOs for listing chunks
    /// <see href="https://github.com/infiniflow/ragflow/blob/main/docs/references/http_api_reference.md#list-chunks">API Reference</see>
    /// </summary>
    public class List
    {
        /// <summary>
        /// Response body containing an array of chunk data
        /// </summary>
        public class ResponseBody : BaseResponse<Data>
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public ICollection<Chunk>? Chunks { get; set; } 
            
            /// <summary>
            /// 
            /// </summary>
            public Document? Doc { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            public int Total { get; set; }
        }
    }
} 