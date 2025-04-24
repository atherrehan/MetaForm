using DynamicFlow.Models.Generic;
using MediatR;

namespace Module.Flow.Core.DBOs
{
    public class KeyValueRequestDbo : IRequest<List<KeyValueDbo>>
    {
        public string Script { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string LanguageId { get; set; } = string.Empty;
    }
    public class KeyValueDbo
    {
        public int? Key { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
