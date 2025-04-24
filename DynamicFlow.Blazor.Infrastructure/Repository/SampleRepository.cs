using System.Net.Http;
using DynamicFlow.Blazor.Infrastructure.Repository.Interfaces;
using DynamicFlow.Models.DTOs;

namespace DynamicFlow.Blazor.Infrastructure.Repository
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IHttpClientService _httpClient;
        public SampleRepository(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<(SampleComponentResponseDto? ModelData, int? StatusCode, string? CompleteResponse, bool? IsSuccessStatusCode)> Sample(SampleComponentRequestDto apiRequest, string source, string url)
        {
            var apiResponse = await _httpClient
                            .PostAsync<SampleComponentResponseDto>(
                            apiRequest,
                            url,
                            $"{source}/SampleRepository/Sample"
                            );


            //var apiResponse = await _httpClient.PostAsync<SampleComponentResponseDto>(apiRequest,url,$"{source}/SampleRepository/Sample");
            return apiResponse;
        }
    }
}
