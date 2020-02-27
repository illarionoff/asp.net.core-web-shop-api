using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_Web_Api.Data;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbcontext _context;

        public CategoryService(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            var removed = await _context.SaveChangesAsync();

            return removed > 0;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.Include(p => p.ProductCategories).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Include(p => p.ProductCategories).SingleOrDefaultAsync(x => x.CategoryID == id);
        }

        public  IEnumerable<Product> GetProductByCategory(int id)
        {
            return null;
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}