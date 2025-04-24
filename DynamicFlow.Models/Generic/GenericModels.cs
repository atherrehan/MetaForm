namespace DynamicFlow.Models.Generic
{
    public class GenericResponseApi
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
    }
    public class GenericKeyValueRequestDto
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Script { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string LanguageId { get; set; } = string.Empty;
    }
    public class GenericKeyValueResponseDto
    {
        public int? Key { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class GenericGroups
    {
        public int? Id { get; set; }
    }

    public class GenericParameterValueResponseDto
    {
        public string Parameter { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public class FlowParameter
    {
        public string Title { get; set; } = string.Empty;
        public object? Value { get; set; }
    }
    public class ApiUrls
    {
        public string Key { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
