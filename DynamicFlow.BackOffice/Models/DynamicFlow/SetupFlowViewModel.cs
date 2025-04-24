using DynamicFlow.BackOffice.Models.Generic;
using System.Reflection.Metadata;

namespace DynamicFlow.BackOffice.Models.DynamicFlow
{
    public class GetSetupFlowViewModel
    {
        public List<KeyValueGeneric>? flow { get; set; }
        public List<KeyValueGeneric>? property { get; set; }
    }

    public class SaveFlowViewModel
    {
        public int? FlowId { get; set; }
        public List<FlowPropertyViewModel>? Properties { get; set; }
    }
    public class FlowPropertyViewModel
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
}
