using DynamicFlow.BackOffice.Models;
using DynamicFlow.BackOffice.Repository.Interfaces;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace DynamicFlow.BackOffice.Repository
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<(T? ModelData, int? StatusCode, string? CompleteResponse, bool? IsSuccessStatusCode)> PostAsync<T>(RequestType getpost, object param, string url, string source, List<ApiHeaders>? apiHeaders = null)
        {
            T? Result = default;
            string ResultData = "";
            int StatusCode = 0;
            bool IsSuccessStatusCode = false;

            try
            {
                var httpClient = _httpClientFactory.CreateClient("client");
                StringContent? stringRequest;
                stringRequest = new StringContent(param?.Serialize() ?? "", Encoding.UTF8, MediaTypeNames.Application.Json);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (apiHeaders?.Count > 0)
                {
                    foreach (var Header in apiHeaders)
                    {
                        httpClient.DefaultRequestHeaders.Add(Header.Key, Header.Value);
                    }
                }
                using (var response = (getpost == RequestType.GET) ? await httpClient.GetAsync(url).ConfigureAwait(false) : await httpClient.PostAsync(url, stringRequest))
                {
                    StatusCode = (int)response.StatusCode;
                    ResultData = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        IsSuccessStatusCode = true;
                        try
                        {

                            Result = ResultData.Deserialize<T>();
                        }
                        catch (Exception)
                        {

                            Result = default;
                            throw;
                        }
                    }
                }
                return (Result, StatusCode, ResultData, IsSuccessStatusCode);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
