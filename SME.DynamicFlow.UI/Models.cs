namespace SME.DynamicFlow.UI
{
    public class DynamicFlowComponentRequestDto
    {
        public int? Id { get; set; }
        public string Url { get; set; } = string.Empty;
    }
    public class DynamicFlowComponentResponseDto
    {
        public DynamicFlowResponseDto? Flow { get; set; }
        public List<DynamicFlowComponentPropertiesResponseDto>? Properties { get; set; }

    }
    public class DynamicFlowResponseDto
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string Script { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonColor { get; set; } = string.Empty;
    }
    public class DynamicFlowComponentPropertiesResponseDto
    {
        public int? FlowPropertyId { get; set; }
        public int? PropertyGroupId { get; set; }
        public int? PropertyTypeId { get; set; }
        public string PropertyType { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public string ControlText { get; set; } = string.Empty;
        public bool? IsRequired { get; set; }
        public bool? IsPreproperty { get; set; }
        public bool? IsPreload { get; set; }
        public bool? IsEvent { get; set; }
        public string Endpoint { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ListScript { get; set; } = string.Empty;
        public int? ParentPropertyId { get; set; }
        public string Parameter { get; set; } = string.Empty;
        public bool? IsVisible { get; set; }
        public string AlwaysDefaultValue { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class DynamicFlowComponentSaveRequestDto
    {
        public string UserId { get; set; } = string.Empty;
        public string LanguageId { get; set; } = string.Empty;
        public string Script { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public List<GenericParameterValueResponseDto>? parameterValue { get; set; }
    }
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
