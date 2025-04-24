using DynamicFlow.Models.DTOs;

namespace DynamicFlow.Blazor.Infrastructure.Repository.Interfaces
{
    public interface ISampleRepository
    {
        Task<(SampleComponentResponseDto? ModelData, int? StatusCode, string? CompleteResponse, bool? IsSuccessStatusCode)> Sample(SampleComponentRequestDto apiRequest, string source, string url);

    }
}
