using Dapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperProject.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);

        Task<List<TEntity>> GetFilterAll(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetFilter(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetQueryAll(string query);
        Task<int> GetStoredProcedure(string storedProcedure, DynamicParameters dynamicParameters);      
    }
}
