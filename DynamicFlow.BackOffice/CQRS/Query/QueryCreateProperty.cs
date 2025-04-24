using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using Mapster;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Query
{
    internal class QueryGetCreateProperty(IDbContext _dbContext) : IRequestHandler<GetCreatePropertyRequestDbo, GetCreatePropertyResponseDbo>//Yes
    {
        public async Task<GetCreatePropertyResponseDbo> Handle(GetCreatePropertyRequestDbo request, CancellationToken cancellationToken)
        {
            var responseDbo = await FlowDbo();
            var response = BindDbo(responseDbo);
            return response;
        }
        private async Task<List<object>> FlowDbo()
        {
            var response = await _dbContext.GetMultipleSelectsAsync
               (
               "usp_get_create_property",
               "",
               null,
               x => x.Read<KeyValueGeneric>().ToList() ?? [],
               x => x.Read<KeyValueGeneric>().ToList() ?? [],
               x => x.Read<GetExistingProperty>().ToList() ?? []
               );

            return response;
        }
        private static GetCreatePropertyResponseDbo BindDbo(List<object> flowDbo)
        {
            var returnResponse = new GetCreatePropertyResponseDbo();
            returnResponse.propertyType = flowDbo[0].Adapt<List<KeyValueGeneric>>();
            returnResponse.dbScript = flowDbo[1].Adapt<List<KeyValueGeneric>>();
            returnResponse.currentProperty = flowDbo[2].Adapt<List<GetExistingProperty>>();
            return returnResponse;
        }
    }
}
