using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Query
{
    internal class QueryGeQueryGetParametertProcedure(IDbContext _dbContext) : IRequestHandler<GetParameterRequestDbo, GetParameterResponseDbo>//Yes
    {
        public async Task<GetParameterResponseDbo> Handle(GetParameterRequestDbo request, CancellationToken cancellationToken)
        {
            var response = await FlowDbo(request);
            return response;
        }
        private async Task<GetParameterResponseDbo> FlowDbo(GetParameterRequestDbo requestDbo)
        {
            string rawQuery = "SET NOCOUNT ON; SELECT p.name [Key], p.name [Value] FROM sys.parameters p INNER JOIN sys.types t ON p.system_type_id = t.system_type_id AND p.user_type_id = t.user_type_id WHERE p.object_id = OBJECT_ID('{0}') ORDER BY p.parameter_id;";
            rawQuery = rawQuery.Replace("{0}", requestDbo.Procedure);
            var parameter = await _dbContext.GetListQueryAsync<KeyValueStringGeneric>(rawQuery, null, requestDbo.ConnectionString);
            rawQuery = " select ''[Key],'--Select--'[Value] union SELECT 'df.'+[name] [Key], 'df.'+[name] [Value] FROM sys.procedures p WHERE schema_name(schema_id) = 'df' ";
            var procedure = await _dbContext.GetListQueryAsync<KeyValueStringGeneric>(rawQuery, null, requestDbo.ConnectionString);
            var response = new GetParameterResponseDbo();
            response.Parameter = parameter;
            response.Procedure = procedure;
            return response;
        }
    }
}
