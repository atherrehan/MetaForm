namespace DynamicFlow.Models.Generic
{
    public class ApiResponse<T>
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseMessage { get; set; } = string.Empty;
        public T? body { get; set; }
       
    }
}
