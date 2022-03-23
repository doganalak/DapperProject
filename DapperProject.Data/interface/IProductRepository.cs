using DapperProject.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperProject.Data
{
    public interface IProductRepository : IRepository<Products>
    {
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<Products> GetProductsByIdAsync(int id);
        Task<bool> InsertProductsAsync(Products product);
        Task<bool> UpdateProductsAsync(Products product);
        Task<bool> DeleteProductsAsync(int id);
    }
}
