using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop_Web_Api.Extensions;
using Shop_Web_Api.Models;
using Shop_Web_Api.Services;

namespace Shop_Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{productID}")]
        public async Task<ActionResult<Order>> CreateOrder(int productID)
        {
            var id = HttpContext.GetUserId();

            var result = await _orderService.CreateOrderAsync(id, productID);

            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            var userID = HttpContext.GetUserId();
            return Ok(await _orderService.GetOrdersAsync(userID));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userID = HttpContext.GetUserId();
            var product = await _orderService.GetOrderByIdAsync(userID,id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var userID = HttpContext.GetUserId();
            var removed = await _orderService.DeleteOrderAsync(userID,id);

            if (!removed) return NotFound();

            return NoContent();
        }
    }
}