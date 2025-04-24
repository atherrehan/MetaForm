namespace DynamicFlow.Models.Generic
{
    public class LogApiRequestResponse
    {
        public string UserId { get; set; } = string.Empty;
        public string ProcessingCode { get; set; } = string.Empty;
        public string HttpStatusCode { get; set; } = string.Empty;
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
        public string Guid { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string RequestDateTime { get; set; } = string.Empty;
        public string ResponseDateTime { get; set; } = string.Empty;
        public string Request { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public string PublicIp { get; set; } = string.Empty;

    }
}
