using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop_Web_Api.Extensions;
using Shop_Web_Api.Models;
using Shop_Web_Api.Services;

namespace Shop_Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly UserManager<IdentityUser> _userManager;

        public ContactsController(IContactService contactService, UserManager<IdentityUser> userManager)
        {
            _contactService = contactService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<Order>> AddContact([FromBody] ContactRequest request)
        {
            var userID = HttpContext.GetUserId();

            var result = await _contactService.AddContactAsync(userID, request.Address, request.City);

            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactService.GetContactsAsync());
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById()
        {
            var userID = HttpContext.GetUserId();
            var product = await _contactService.GetContactByUserIdAsync(userID);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}