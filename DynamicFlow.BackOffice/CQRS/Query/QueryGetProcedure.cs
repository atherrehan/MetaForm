using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using Mapster;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Query
{
    internal class QueryGetProcedure(IDbContext _dbContext) : IRequestHandler<GetPropertyProcedureRequestDbo, GetPropertyProcedureResponseDbo>//Yes
    {
        public async Task<GetPropertyProcedureResponseDbo> Handle(GetPropertyProcedureRequestDbo request, CancellationToken cancellationToken)
        {
            var response = await ProcedureDbo(request);
            var bind = BindDbo(response);
            return bind;
        }
        private async Task<List<object>> ProcedureDbo(GetPropertyProcedureRequestDbo requestDbo)
        {
            var response = await _dbContext.GetMultipleSelectsAsync
                (
                "usp_get_procedure",
                "",
                requestDbo,
                x => x.Read<KeyValueStringGeneric>().FirstOrDefault() ?? new KeyValueStringGeneric(),
                x => x.Read<KeyValueGeneric>().ToList() ?? []
                );
            return response;
        }
        private static GetPropertyProcedureResponseDbo BindDbo(List<object> procedureDbo)
        {
            var returnResponse = new GetPropertyProcedureResponseDbo();
            returnResponse.Connection = procedureDbo[0].Adapt<KeyValueStringGeneric>();
            returnResponse.FlowScript = procedureDbo[1].Adapt<List<KeyValueGeneric>>();
            return returnResponse;
        }
    }
}
