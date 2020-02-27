using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop_Web_Api.Data;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbcontext _context;
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> _userManager;


        public OrderService(ApplicationDbcontext context, IProductService productService, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _productService = productService;
            _userManager = userManager;
        }

        public async Task<Order> CreateOrderAsync(string userID, int productID)
        {
            var newOrder = new Order();

            newOrder.UserID = userID;
   
            await _context.Orders.AddAsync(newOrder);
            
            var newOrderProduct = new OrderProduct();
            newOrderProduct.OrderID = newOrder.OrderID;
            newOrderProduct.ProductID = productID;
            newOrder.OrderProducts = new List<OrderProduct>();
            newOrder.OrderProducts.Add(newOrderProduct);

           var created = await _context.SaveChangesAsync();

            if (created <= 0)
            {
                return null;
            }

            return newOrder;
        }

        public async Task<Order> GetOrderByIdAsync(string userID, int id)
        {
            return await _context.Orders.Where(u => u.UserID == userID).Include(o => o.OrderProducts).SingleOrDefaultAsync(order => order.OrderID == id);
        }

        public async Task<List<Order>> GetOrdersAsync(string userID)
        {
            var user = await _userManager.FindByIdAsync(userID);

            var roles = _userManager.GetRolesAsync(user).Result;
         
            if (roles.Any())
            {
                if (roles[0] == "Admin")
                {
                    return await _context.Orders.ToListAsync();
                }
                else
                {
                    return await _context.Orders.Where(u => u.UserID == userID).ToListAsync();
                }
            }
            return null;
        }

        public async Task<bool> DeleteOrderAsync(string userID, int id)
        {
            var order = await GetOrderByIdAsync(userID, id);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            var removed = await _context.SaveChangesAsync();

            return removed > 0;
        }
    }
}