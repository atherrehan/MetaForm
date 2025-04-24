using System.Data;
using static Dapper.SqlMapper;

namespace Module.Dynamic.Infrastructure.DbContext
{
    public interface IDynamicDbContext
    {
        Task<List<T>> GetListAsync<T>(string sp, object? parms = null, string connectionString = "", CommandType commandType = CommandType.StoredProcedure);

        Task<List<object>> GetMultipleSelectsAsync(string sql, string connectionString = "", object? parameters = null, params Func<GridReader, object>[] readerFuncs);

        Task<T> ExecuteSingleReturn<T>(string sql, string connectionString = "", object? parms = null, CommandType commandType = CommandType.StoredProcedure);

    }
}
