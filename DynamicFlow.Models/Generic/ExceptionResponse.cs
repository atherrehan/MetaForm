namespace DynamicFlow.Models.Generic
{
    public class ExceptionResponse<T> where T : class
    {
        public string responseCode { get; set; } = "404";
        public string responseMessage { get; set; } = "Not found";
        public T? body { get; set; } = default;
    }
}
