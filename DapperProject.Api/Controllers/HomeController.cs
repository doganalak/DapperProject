using Dapper;
using DapperProject.Data;
using DapperProject.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DapperProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepositor)
        {
            _productRepository = productRepositor;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Products getFilter = await _productRepository.GetFilter(a => a.Id == id);
            Products products = await _productRepository.FindByIdAsync(id);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            int Id = 3;
            List<Products> getQueryAll = await _productRepository.GetQueryAll($"select * from Product(nolock) where Id>{Id}");
            List<Products> getFilterAll = await _productRepository.GetFilterAll(a => a.Id > 2);
            List<Products> getAll = await _productRepository.FindAllAsync();
            return Ok();
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Products products)
        {
            var p = new DynamicParameters();
            p.Add("@ProductName", "Saat");
            p.Add("@ProductCount", 25);
            p.Add("@CreateDate", DateTime.Now);
            var _return = await _productRepository.ProductsStoredProcedure("Sp_Product", p);

            await _productRepository.CreateAsync(products);
            return Ok(products.ProductName);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
            return Ok("");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Products products)
        {
            Products getProduct = await _productRepository.FindByIdAsync(products.Id);
            if (getProduct != null)
            {
                await _productRepository.UpdateAsync(products);
            }
            return Ok("");
        }
    }
}
