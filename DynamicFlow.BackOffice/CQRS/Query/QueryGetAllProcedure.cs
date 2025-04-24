using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Query
{
    internal class QueryGetAllProcedure(IDbContext _dbContext) : IRequestHandler<GetAllProcedureRequestDbo, List<KeyValueStringGeneric>>//yes
    {
        public async Task<List<KeyValueStringGeneric>> Handle(GetAllProcedureRequestDbo request, CancellationToken cancellationToken)
        {
            var response = await FlowDbo(request);
            return response;
        }
        private async Task<List<KeyValueStringGeneric>> FlowDbo(GetAllProcedureRequestDbo requestDbo)
        {
            var connectionString = await _dbContext.ExecuteSingleReturn<KeyValueGeneric>("usp_get_connection", "", requestDbo);
            var response = await _dbContext.GetListQueryAsync<KeyValueStringGeneric>("SELECT ROW_NUMBER() over (order by [name]) [Key], 'df.'+[name] [Value] FROM sys.procedures WHERE schema_name(schema_id) = 'df' ORDER BY create_date desc;", null, connectionString.Value);
            return response;
        }
        
    }
}
