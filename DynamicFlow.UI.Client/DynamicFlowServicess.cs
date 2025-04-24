using DynamicFlow.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DynamicFlow.UI.Client
{
    public class DynamicFlowServicess
    {
        private string _apiUrl;
        public DynamicFlowServicess(string apiUrl)
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

                HttpResponseMessage response = await client.GetAsync(url); // Use GetAsync

                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync(); // Await the response
                    result = JsonSerializer.Deserialize<List<ApiUrls>>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return result;
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

                // Convert content to JSON
                string jsonContent = JsonSerializer.Serialize(requestDto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Make the POST request
                HttpResponseMessage response = await client.PostAsync(requestDto.Url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync(); // Await the response
                    result = JsonSerializer.Deserialize<DynamicFlowComponentResponseDto>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return result;
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

                // Convert content to JSON
                string jsonContent = JsonSerializer.Serialize(requestDto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Make the POST request
                HttpResponseMessage response = await client.PostAsync(requestDto.Url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync(); // Await the response
                    result = JsonSerializer.Deserialize<List<GenericKeyValueResponseDto>>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return result;
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

                // Convert content to JSON
                string jsonContent = JsonSerializer.Serialize(requestDto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Make the POST request
                HttpResponseMessage response = await client.PostAsync(requestDto.Url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync(); // Await the response
                    result = JsonSerializer.Deserialize<GenericResponseApi>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return result;
            }
        }
    }
}
