using DapperProject.Data;
using DapperProject.Entity;
using Microsoft.AspNetCore.Mvc;
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
            Products products = await _productRepository.FindByIdAsync(id);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Products> getAll = await _productRepository.FindAllAsync();
            return Ok();
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Products products)
        {
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
