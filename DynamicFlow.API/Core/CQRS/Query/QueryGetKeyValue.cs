using DynamicFlow.API.Core.DBO;
using DynamicFlow.API.Infrastructure.DbContext;
using MediatR;

namespace DynamicFlow.API.Core.CQRS.Query
{
    internal class QueryGetKeyValue(IDynamicDbContext _dbContext) : IRequestHandler<KeyValueRequestDbo, List<KeyValueDbo>>
    {
        public async Task<List<KeyValueDbo>> Handle(KeyValueRequestDbo requestDbo, CancellationToken cancellationToken)
        {
            var responseDbo = await KeyValueDbo(requestDbo);
            return responseDbo;
        }
        private async Task<List<KeyValueDbo>> KeyValueDbo(KeyValueRequestDbo requestDbo)
        {
            var response = new KeyValueDbo();
            var param = new
            {
                LanguageId = requestDbo.LanguageId,
                Id = requestDbo.Value
            };
            return await _dbContext.GetListAsync<KeyValueDbo>(requestDbo.Script, param, requestDbo.ConnectionString);
        }

    }
}
