using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SME.DynamicFlow.UI
{
    public class DynamicFlowServices
    {
        private string _apiUrl;
        public DynamicFlowServices(string apiUrl)
        {
            _apiUrl = apiUrl;
        }
        public async Task<List<ApiUrls>> GetUrls(string url)
        {
            var result = new List<ApiUrls>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync(); 
                    result = JsonSerializer.Deserialize<List<ApiUrls>>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                return result ?? new List<ApiUrls>();
            }
        }

        public async Task<DynamicFlowComponentResponseDto> GetFlow(DynamicFlowComponentRequestDto requestDto)
        {
            var result = new DynamicFlowComponentResponseDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonContent = JsonSerializer.Serialize(requestDto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(requestDto.Url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync(); 
                    result = JsonSerializer.Deserialize<DynamicFlowComponentResponseDto>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                return result ?? new DynamicFlowComponentResponseDto();
            }
        }

        public async Task<List<GenericKeyValueResponseDto>> GetKeyValue(GenericKeyValueRequestDto requestDto)
        {
            var result = new List<GenericKeyValueResponseDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonContent = JsonSerializer.Serialize(requestDto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(requestDto.Url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync(); 
                    result = JsonSerializer.Deserialize<List<GenericKeyValueResponseDto>>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                return result ?? new List<GenericKeyValueResponseDto>();
            }
        }

        public async Task<GenericResponseApi> SaveFlow(DynamicFlowComponentSaveRequestDto requestDto)
        {
            var result = new GenericResponseApi();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonContent = JsonSerializer.Serialize(requestDto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(requestDto.Url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<GenericResponseApi>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                return result ?? new GenericResponseApi();
            }
        }
    }
}
