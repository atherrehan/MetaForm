using DynamicFlow.BackOffice.Models.Generic;
using MediatR;
using System.Reflection.Metadata;

namespace DynamicFlow.BackOffice.DBOs
{
    public class GetCreatePropertyRequestDbo : IRequest<GetCreatePropertyResponseDbo>
    {
    }
    public class GetCreatePropertyResponseDbo
    {
        public List<KeyValueGeneric>? propertyType { get; set; }
        public List<KeyValueGeneric>? dbScript { get; set; }
        public List<GetExistingProperty>? currentProperty { get; set; }
    }
    public class GetExistingProperty
    {
        public int? FlowId { get; set; }
        public int? PropertyTypeId { get; set; }
        public string Script { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Parameter { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public bool? IsVisible { get; set; }
        public bool? IsPreproperty { get; set; }
        public bool? IsRequired { get; set; }
    }

    public class GetPropertyProcedureRequestDbo : IRequest<GetPropertyProcedureResponseDbo>
    {
        public int? Id { get; set; }
    }
    public class GetPropertyProcedureResponseDbo
    {
        public KeyValueStringGeneric? Connection { get; set; }
        public List<KeyValueGeneric>? FlowScript { get; set; }
    }

    public class GetParameterRequestDbo : IRequest<GetParameterResponseDbo>
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Procedure { get; set; } = string.Empty;
    }
    public class GetParameterResponseDbo
    {
        public List<KeyValueStringGeneric>? Parameter { get; set; }
        public List<KeyValueStringGeneric>? Procedure { get; set; }
    }
}
