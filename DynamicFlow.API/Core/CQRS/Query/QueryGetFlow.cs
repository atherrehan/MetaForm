using DynamicFlow.API.Core.DBO;
using DynamicFlow.API.Infrastructure.DbContext;
using DynamicFlow.Models.Exceptions;
using DynamicFlow.Models.Generic;
using Mapster;
using MediatR;

namespace DynamicFlow.API.Core.CQRS.Query
{
    internal class QueryGetFlow(IDynamicDbContext _dbContext) : IRequestHandler<DynaicFlowComponentRequestDbo, DynaicFlowComponentResponseDbo>
    {
        public async Task<DynaicFlowComponentResponseDbo> Handle(DynaicFlowComponentRequestDbo requestDbo, CancellationToken cancellationToken)
        {
            var responseDbo = await FlowDbo(requestDbo);
            if (responseDbo == null)
            {
                return new DynaicFlowComponentResponseDbo();
            }
            var responseReturn = BindDbo(responseDbo);
            return responseReturn;

        }

        private async Task<List<object>> FlowDbo(DynaicFlowComponentRequestDbo requestDbo)
        {
            var response = await _dbContext.GetMultipleSelectsAsync
               (
               "usp_get_flow",
               "",
               requestDbo,
               x => x.Read<GenericResponseApi>().FirstOrDefault() ?? new GenericResponseApi(),
               x => x.Read<DynamicFlowResponseDbo>().FirstOrDefault() ?? new DynamicFlowResponseDbo(),
               x => x.Read<DynamicFlowComponentPropertiesResponseDbo>().ToList() ?? []
               );

            return response;
        }

        private static DynaicFlowComponentResponseDbo BindDbo(List<object> flowDbo)
        {
            var returnResponse = new DynaicFlowComponentResponseDbo
            {
                Response = flowDbo[0].Adapt<GenericResponseApi>()
            };
            if (!returnResponse.Response.ResponseCode.Equals("00"))
            {
                returnResponse.Flow = new();
                returnResponse.Properties = new List<DynamicFlowComponentPropertiesResponseDbo>();
                return returnResponse;
            }
            returnResponse.Flow = flowDbo[1].Adapt<DynamicFlowResponseDbo>();
            returnResponse.Properties = flowDbo[2].Adapt<List<DynamicFlowComponentPropertiesResponseDbo>>();
            return returnResponse;
        }
    }
}
