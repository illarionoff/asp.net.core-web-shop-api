using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> CreateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
        public IEnumerable<Product> GetProductByCategory(int id);
    }
}