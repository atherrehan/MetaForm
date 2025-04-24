using DynamicFlow.Models.Generic;

namespace DynamicFlow.Blazor.Infrastructure.DbContext
{
    public interface IDbContext
    {
        Task<ApiUrl> GetURL(string ProcessingCode);

    }
}
