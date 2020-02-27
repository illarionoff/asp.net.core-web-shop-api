using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Web_Api.Models
{
    public class ContactRequest
    {
        public string Address { get; set; }
        public string City { get; set; } 
    }
}
