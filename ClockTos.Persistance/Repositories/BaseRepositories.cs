using System.Data;
using ClockTos.Application.Abstractions.IRepositories;
using ClockTos.Domain.Entities;
using ClockTos.Persistance.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ClockTos.Persistance.Repositories
{
    public class BaseRepositories<T>:IBaseRepository<BaseEntity>
    {
        private readonly ClockDbContext context;

        public BaseRepositories(ClockDbContext context)
        {
            this.context = context;
        }

        #region dapper methods

        public async Task<int> ExecuteAsync(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            return await context.ExecuteAsyncExtension(sql, param, commandType, transaction);

        }
        public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.QueryAsync<TEntity>(sql, param, transaction, null, commandType);
        }


        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            return await context.FirstOrDefaultAsyncExtension<TEntity>(sql, param, commandType, transaction);
        }


        #endregion
    }
    public static class DapperExtension
    {

        public static async Task<int> ExecuteAsyncExtension(this DbContext context, string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            try
            {
                SqlConnection connection = new(context.Database.GetConnectionString());
                return await connection.ExecuteAsync(sql, param, transaction, null, commandType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<IEnumerable<TEntity>> QueryAsyncExtension<TEntity>(this DbContext context, string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            try
            {
                SqlConnection connection = new(context.Database.GetConnectionString());
                return await connection.QueryAsync<TEntity>(sql, param, transaction, null, commandType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static async Task<TEntity> FirstOrDefaultAsyncExtension<TEntity>(this DbContext context, string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            try
            {
                SqlConnection connection = new(context.Database.GetConnectionString());
                return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, transaction, null, commandType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
