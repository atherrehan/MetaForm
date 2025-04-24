using static Dapper.SqlMapper;
using System.Data;

namespace DynamicFlow.BackOffice.DbContext;

public interface IDbContext
{
    Task<List<T>> GetListAsync<T>(string sp, object? parms = null, string connectionString = "", CommandType commandType = CommandType.StoredProcedure);

    Task<List<T>> GetListQueryAsync<T>(string sp, object? parms = null, string connectionString = "", CommandType commandType = CommandType.Text);

    Task<List<object>> GetMultipleSelectsAsync(string sql, string connectionString = "", object? parameters = null, params Func<GridReader, object>[] readerFuncs);

    Task<T> ExecuteSingleReturn<T>(string sql, string connectionString = "", object? parms = null, CommandType commandType = CommandType.StoredProcedure);

}
