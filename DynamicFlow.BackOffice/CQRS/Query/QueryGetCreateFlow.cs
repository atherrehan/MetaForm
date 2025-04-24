using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using Mapster;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Query
{
    internal class QueryGetCreateFlow(IDbContext _dbContext) : IRequestHandler<GetCreateFlowRequestDbo, GetCreateFlowResponseDbo>//Yes
    {
        public async Task<GetCreateFlowResponseDbo> Handle(GetCreateFlowRequestDbo request, CancellationToken cancellationToken)
        {
            var responseDbo = await FlowDbo();
            var response = BindDbo(responseDbo);
            return response;
        }
        private async Task<List<object>> FlowDbo()
        {
            var response = await _dbContext.GetMultipleSelectsAsync
               (
               "usp_get_create_flow",
               "",
               null,
               x => x.Read<KeyValueGeneric>().ToList() ?? [],
               x => x.Read<KeyValueGeneric>().ToList() ?? []
               );

            return response;
        }
        private static GetCreateFlowResponseDbo BindDbo(List<object> flowDbo)
        {
            var returnResponse = new GetCreateFlowResponseDbo();
            returnResponse.dbConnection = flowDbo[0].Adapt<List<KeyValueGeneric>>();
            returnResponse.button = flowDbo[1].Adapt<List<KeyValueGeneric>>();
            return returnResponse;
        }
    }
}
