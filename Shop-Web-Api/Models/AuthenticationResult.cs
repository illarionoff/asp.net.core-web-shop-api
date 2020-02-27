using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Web_Api.Models
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { set; get; }
        public IEnumerable<string> Errors { get; set; }
    }
}
