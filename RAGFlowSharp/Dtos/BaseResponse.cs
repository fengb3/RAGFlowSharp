namespace RAGFlowSharp.Dtos
{
    public class BaseResponse
    {
        public int Code { get; set; }

        public string? Message { get; set; }
    }

    public class BaseResponse<T> : BaseResponse where T : class
    {
        public T? Data { get; set; }
    }
}