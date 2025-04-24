using DynamicFlow.Models.Generic;
using MediatR;

namespace Module.Dynamic.Core.DBOs
{
    public class DynaicFlowComponentRequestDbo : IRequest<DynaicFlowComponentResponseDbo>
    {
        public string Title { get; set; } = string.Empty;
    }
    public class DynaicFlowComponentResponseDbo
    {
        public GenericResponseApi? Response { get; set; }
        public DynamicFlowResponseDbo? Flow { get; set; }
        public List<DynamicFlowComponentPropertiesResponseDbo>? Properties { get; set; }
    }
    public class DynamicFlowResponseDbo
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string Script { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonColor { get; set; } = string.Empty;
    }
    public class DynamicFlowComponentPropertiesResponseDbo
    {
        public int? FlowPropertyId { get; set; }
        public int? PropertyTypeId { get; set; }
        public string PropertyType { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public string ControlText { get; set; } = string.Empty;
        public bool? IsRequired { get; set; }
        public bool? IsPreproperty { get; set; }
        public bool? IsPreload { get; set; }
        public string Endpoint { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int? PropertyGroupId { get; set; }
        public string ListScript { get; set; } = string.Empty;
        public int? ParentPropertyId { get; set; }
        public bool? IsEvent { get; set; }
        public string Parameter { get; set; } = string.Empty;
        public bool? IsVisible { get; set; }
        public string AlwaysDefaultValue { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class DynamicFlowComponentSaveRequestDbo : IRequest<DynamicFlowComponentSaveResponseDbo>
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Script { get; set; } = string.Empty;
        public List<DynamicFlowComponentSaveKeyValueRequestDbo>? KeyValue { get; set; }
    }
    public class DynamicFlowComponentSaveKeyValueRequestDbo
    {
        public string Parameter { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public class DynamicFlowComponentSaveResponseDbo
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
    }
}
