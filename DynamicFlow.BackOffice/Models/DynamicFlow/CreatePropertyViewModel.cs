using DynamicFlow.BackOffice.Models.Generic;

namespace DynamicFlow.BackOffice.Models.DynamicFlow
{
    public class GetProcedureViewModel
    {
        public int? Id { get; set; }
    }
    public class GetAllProcedureViewModel
    {
        public int? Id { get; set; }
    }

    public class GetFlowPropertyViewModel
    {
        public List<KeyValueStringGeneric>? parameters { get; set; }
        public List<KeyValueGeneric>? propertyType { get; set; }
        public List<KeyValueStringGeneric>? dbScript { get; set; }
        public List<GetExistingPropertyViewModel>? currentProperty { get; set; }
    }
    public class GetExistingPropertyViewModel
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

}
