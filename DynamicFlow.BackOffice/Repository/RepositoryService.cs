using DynamicFlow.BackOffice.Models;
using DynamicFlow.BackOffice.Repository.Interfaces;

namespace DynamicFlow.BackOffice.Repository
{
    public class RepositoryService(IHttpClientService _httpClient) : IRepositoryService
    {
        public async Task<List<KeyValueResponseDto>> GetKeyValue(KeyValueRequestDto requestDto)
        {
            var apiResponse = await _httpClient
                         .PostAsync<List<KeyValueResponseDto>>(
                           RequestType.POST,
                         requestDto,
                         requestDto.Url,
                         $"/FlowRepository/GetKeyValue"
                         );
            if (apiResponse.ModelData is null || !apiResponse.IsSuccessStatusCode.Equals(true))
            {
                throw new Exception("Error while fetching data from API");
            }
            var responseApi = apiResponse.ModelData;
            return responseApi;
        }
    }
}
