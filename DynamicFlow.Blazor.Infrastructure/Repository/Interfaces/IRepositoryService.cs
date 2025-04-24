using DynamicFlow.Models.Generic;

namespace DynamicFlow.Blazor.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryService
    {
        Task<ApiUrl> GetURL(string Key);

    }
}
