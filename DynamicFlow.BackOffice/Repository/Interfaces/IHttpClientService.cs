using DynamicFlow.BackOffice.Models;

namespace DynamicFlow.BackOffice.Repository.Interfaces
{
    public interface IHttpClientService
    {
        Task<(T? ModelData, int? StatusCode, string? CompleteResponse, bool? IsSuccessStatusCode)> PostAsync<T>(RequestType getpost, object param, string url, string source, List<ApiHeaders>? apiHeaders = default);

    }
}
