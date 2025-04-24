using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using Mapster;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Query
{
    internal class QuerySetupFlow(IDbContext _dbContext) : IRequestHandler<GetSetupFlowRequestDbo, List<KeyValueGeneric>>//Yes
    {
        public async Task<List<KeyValueGeneric>> Handle(GetSetupFlowRequestDbo request, CancellationToken cancellationToken)
        {
            var responseDbo = await FlowDbo();
            return responseDbo;
        }

        private async Task<List<KeyValueGeneric>> FlowDbo()
        {
            var response = await _dbContext.GetListAsync<KeyValueGeneric>("usp_get_setup_flow", null, "");
            return response;
        }
    }
}
