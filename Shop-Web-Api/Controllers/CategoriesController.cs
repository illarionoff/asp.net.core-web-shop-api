using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_Web_Api.Models;
using Shop_Web_Api.Services;

namespace Shop_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            var result = await _categoryService.CreateCategoryAsync(category);
            if (result == false)
                return BadRequest();

            return CreatedAtAction("GetById", new {id = category.CategoryID}, category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetCategoriesAsync());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok( _categoryService.GetProductByCategory(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var removed = await _categoryService.DeleteCategoryAsync(id);

            if (!removed) return NotFound();

            return NoContent();
        }
    }
}