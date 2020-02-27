using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_Web_Api.Data;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbcontext _context;

        public ProductService(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.ProductCategories).Include(p => p.OrderProducts).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p=>p.ProductCategories).Include(p=>p.OrderProducts).SingleOrDefaultAsync(x => x.ProductID == id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            var removed = await _context.SaveChangesAsync();

            return removed > 0;
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}