using DynamicFlow.BackOffice.Models.Generic;

namespace DynamicFlow.BackOffice.Models.DynamicFlow
{
    public class GetCreateFlowViewModel
    {
        public List<KeyValueGeneric>? dbConnection { get; set; }
        public List<KeyValueGeneric>? button { get; set; }
    }
    public class CreateFlowViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ConnectionId { get; set; }
        public string Procedure { get; set; } = string.Empty;
        public int? ButtonId { get; set; }
    }
}
