using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_Web_Api.Models;
using Shop_Web_Api.Services;

namespace Shop_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            var result = await _productService.CreateProductAsync(product);
            if (result == false)
                return BadRequest();

            return CreatedAtAction("GetById", new {id = product.ProductID}, product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var removed = await _productService.DeleteProductAsync(id);

            if (!removed) return NotFound();

            return NoContent();
        }
    }
}