using MediatR;

namespace DynamicFlow.API.Core.DBO
{
    public class ApiUrlRequestDbo : IRequest<List<ApiUrlResponseDbo>>
    {
    }
    public class ApiUrlResponseDbo
    {
        public string Key { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
