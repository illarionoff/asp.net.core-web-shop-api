using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string name, string password, string role);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
