using System.Data;
using Dapper;
using DynamicFlow.Blazor.Infrastructure.Enums;
using DynamicFlow.Blazor.Infrastructure.Repository.Interfaces;
using DynamicFlow.Blazor.Infrastructure.Services;
using DynamicFlow.Models.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DynamicFlow.Blazor.Infrastructure.Repository
{
    public class RepositoryService : IRepositoryService
    {
        private readonly string _connectionString;
        private readonly ICacheService _cacheService;
        private readonly CacheConfigurations? _cacheTimeConfig;
        public RepositoryService(IOptions<DatabaseConnection> connection, ICacheService cacheService)
        {
            _connectionString = connection.Value.WebConnectionString;
            _cacheService = cacheService;
        }
        public async Task<ApiUrl> GetURL(string Key)
        {
            ApiUrl url = new();
            _cacheService.Get(UrlCacheEnum.UrlCache.ToString(), out List<ApiUrl> esbURL);
            if (esbURL is null)
            {
                using var _db = await CreateConnectionAsync();
                var Data = await _db.QueryAsync<ApiUrl>("CMS.GetAllUrl", commandType: CommandType.StoredProcedure);
                esbURL = Data.ToList();
                if (esbURL is not null)
                {
                    _cacheService.Set(UrlCacheEnum.UrlCache.ToString(), esbURL, _cacheTimeConfig?.AbsoluteExpirationTime ?? 30, _cacheTimeConfig?.SlidingExpiration ?? 30);
                }
            }
            url = esbURL?.FirstOrDefault(row => row.Key == Key) ?? new ApiUrl();
            return url;
        }
        private async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

    }
}
