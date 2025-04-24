using DynamicFlow.Models.Enums;
using DynamicFlow.Service.Common.Service.Interfaces;
using Mapster;
using MediatR;
using Module.Dynamic.Infrastructure.DbContext;
using Module.Flow.Core.DBOs;
using System.Data;

namespace Module.Flow.Core.CQRS.Query
{
    internal class QueryGetUrls(IDynamicDbContext _dbContext, ICacheService _cacheService) : IRequestHandler<ApiUrlRequestDbo, List<ApiUrlResponseDbo>>
    {
        public async Task<List<ApiUrlResponseDbo>> Handle(ApiUrlRequestDbo requestDbo, CancellationToken cancellationToken)
        {
            var responseDbo = await UrlsDbo();
            return responseDbo;
        }
        private async Task<List<ApiUrlResponseDbo>> UrlsDbo()
        {
            var Response = new List<ApiUrlResponseDbo>();
            _cacheService.TryGet(UrlCacheEnum.UrlCache.ToString(), out List<ApiUrlResponseDbo> apiURL);
            if (apiURL is null)
            {
                apiURL = await _dbContext.GetListAsync<ApiUrlResponseDbo>("usp_get_url", commandType: CommandType.StoredProcedure);
                if (apiURL is not null)
                {
                    _cacheService.Set(UrlCacheEnum.UrlCache.ToString(), apiURL, 60, 60);
                }
            }
            Response = apiURL.Adapt<List<ApiUrlResponseDbo>>();
            return Response;
        }
    }
}
