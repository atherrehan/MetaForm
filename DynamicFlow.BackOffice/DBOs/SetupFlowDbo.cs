using DynamicFlow.BackOffice.Models.Generic;
using MediatR;

namespace DynamicFlow.BackOffice.DBOs
{
    public class GetSetupFlowRequestDbo : IRequest<List<KeyValueGeneric>>
    {
    }
    public class SetupFlowRequestDbo : IRequest<GenericResponse>
    {
        public int? FlowId { get; set; }
        public List<SetupFlowPropertyDbo>? Properties { get; set; }
    }
    public class SetupFlowPropertyDbo
    {
        public string Parameter { get; set; } = string.Empty;
        public int? PropertyTypeId { get; set; }
        public string Script { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public bool? IsHidden { get; set; }
        public bool? IsPreproperty { get; set; }
        public bool? IsRequired { get; set; }
    }

    public class SetupFlowDbAndScriptDbo
    {
        public int? FlowId { get; set; }
        public string ConnectionString { get; set; } = string.Empty;
        public string Procedure { get; set; } = string.Empty;
    }
    public class DeleteFlowRequestDbo : IRequest<GenericResponse>
    {
        public int? Id { get; set; }
    }

}
