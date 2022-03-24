using Dapper;
using DapperProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperProject.Data.Service
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        public ProductRepository(DatabaseSettings dbSettings)
            : base(dbSettings) { }
     

        public async Task<bool> DeleteProductsAsync(int id)
        {
            return await DeleteAsync(id);
        }

        public async Task<Products> GetFilterProducts(Expression<Func<Products, bool>> filter)
        {
            return await GetFilter(filter);
        }

        public async Task<List<Products>> GetFilterProductsAll(Expression<Func<Products, bool>> filter)
        {
            return await GetFilterAll(filter);
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Products> GetProductsByIdAsync(int id)
        {
            return await FindByIdAsync(id);
        }

        public async Task<bool> InsertProductsAsync(Products products)
        {
            return await CreateAsync(products);
        }

        public async Task<bool> UpdateProductsAsync(Products products)
        {
            return await UpdateAsync(products);
        }

        public async Task<int> ProductsStoredProcedure(string storedProcedure, DynamicParameters dynamicParameters)
        {
            return await GetStoredProcedure(storedProcedure, dynamicParameters);
        }

        public async Task<List<Products>> GetQueryProducts(string query)
        {
            return await GetQueryAll(query);
        }
    }
}
