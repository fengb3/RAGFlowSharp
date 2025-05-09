namespace RAGFlowSharp.Dtos
{
    /// <summary>
    /// Represents a base response structure for API responses.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Gets or sets the response status code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        public string? Message { get; set; }
    }

    /// <summary>
    /// Represents a generic base response structure for API responses that include data.
    /// </summary>
    /// <typeparam name="T">The type of data included in the response.</typeparam>
    public class BaseResponse<T> : BaseResponse where T : class
    {
        /// <summary>
        /// Gets or sets the response data.
        /// </summary>
        public T? Data { get; set; }
    }
}