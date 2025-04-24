using Dapper;
using DynamicFlow.Service.Common.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace DynamicFlow.API.Infrastructure.DbContext
{
    public class DynamicDbContext : IDynamicDbContext
    {
        private readonly string _connectionString;
        public DynamicDbContext(IOptions<ServiceDatabaseConnection> connection)
        {
            _connectionString = connection.Value.DefaultConnectionString;

        }

        public async Task<List<T>> GetListAsync<T>(string sp, object? parms = null, string connectionString = "", CommandType commandType = CommandType.StoredProcedure)
        {
            using var _db = await CreateConnectionAsync(!string.IsNullOrEmpty(connectionString) ? connectionString : _connectionString);
            var Data = await _db.QueryAsync<T>(sp, parms, commandType: commandType);
            return Data.ToList();
        }

        public async Task<List<object>> GetMultipleSelectsAsync(string sql, string connectionString = "", object? parameters = null, params Func<SqlMapper.GridReader, object>[] readerFuncs)
        {
            var results = new List<object>();
            using var _db = await CreateConnectionAsync(!string.IsNullOrEmpty(connectionString) ? connectionString : _connectionString);
            using var Result = await _db.QueryMultipleAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            foreach (var readerFunc in readerFuncs)
            {
                results.Add(readerFunc(Result));
            }
            return results;
        }

        public async Task<T> ExecuteSingleReturn<T>(string sql, string connectionString = "", object? parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using var _db = await CreateConnectionAsync(!string.IsNullOrEmpty(connectionString) ? connectionString : _connectionString);
            var result = await _db.QueryFirstOrDefaultAsync<T>(sql, parms, commandType: commandType);
            if (result is null)
            {
                throw new Exception();
            }
            return result;
        }

        private async Task<IDbConnection> CreateConnectionAsync(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
