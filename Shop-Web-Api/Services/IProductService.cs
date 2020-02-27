using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> CreateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}