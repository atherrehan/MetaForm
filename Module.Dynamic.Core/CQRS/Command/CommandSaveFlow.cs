using System.Data;
using System.Dynamic;
using Dapper;
using DynamicFlow.Models.Exceptions;
using MediatR;
using Microsoft.Data.SqlClient;
using Module.Dynamic.Core.DBOs;
using Module.Dynamic.Infrastructure.DbContext;

namespace Module.Flow.Core.CQRS.Command
{
    internal class CommandSaveFlow(IDynamicDbContext _dbContext) : IRequestHandler<DynamicFlowComponentSaveRequestDbo, DynamicFlowComponentSaveResponseDbo>
    {
        public async Task<DynamicFlowComponentSaveResponseDbo> Handle(DynamicFlowComponentSaveRequestDbo requestDbo, CancellationToken cancellationToken)
        {
            var dynamicParameters = new DynamicParameters();
            foreach (var kv in requestDbo?.KeyValue ?? throw new NullModelException())
            {
                dynamicParameters.Add("@" + kv.Parameter, kv.Value, GetDbType(kv.DataType));
            }
            var responseDbo = await SaveDbo(requestDbo.Script, requestDbo.ConnectionString, dynamicParameters);
            return responseDbo;
        }

        private async Task<DynamicFlowComponentSaveResponseDbo> SaveDbo(string script, string connectionString, object requestDbo)
        {
            if (string.IsNullOrEmpty(script) || string.IsNullOrEmpty(connectionString) || requestDbo is null)
            {
                throw new NullModelException();
            }
            var response = await _dbContext.ExecuteSingleReturn<DynamicFlowComponentSaveResponseDbo>(script, connectionString, requestDbo);
            if (response is null)
            {
                throw new NullModelException();
            }
            return response;
        }
       
        private DbType GetDbType(string dataType)
        {
            return dataType switch
            {
                "int" => DbType.Int32,
                "string" => DbType.String,
                "datetime" => DbType.DateTime,
                "date" => DbType.Date,
                "bool" => DbType.Boolean,
                "decimal" => DbType.Decimal,
                "double" => DbType.Double,
                "long" => DbType.Int64,
                _ => DbType.String
            };
        }
    }
}
