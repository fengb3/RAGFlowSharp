using System.Collections.Generic;

namespace RAGFlowSharp.Dtos.Conversation.RelatedQuestions
{
    /// <summary>
    /// 请求体：生成相关问题
    /// </summary>
    public class RequestBody
    {
        /// <summary>
        /// user's question
        /// </summary>
        public string Question { get; set; } = string.Empty;
    }

    /// <summary>
    /// Response Body: A list of related issues
    /// </summary>
    public class ResponseBody : BaseResponse
    {
        /// <summary>
        /// 相关问题列表
        /// </summary>
        public List<string>? Data { get; set; }
    }
} 