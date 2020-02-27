using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync(string userID);
        Task<Order> GetOrderByIdAsync(string userID, int id);
        Task<Order> CreateOrderAsync(string userID, int productID);
        Task<bool> DeleteOrderAsync(string userID, int id);
    }
}