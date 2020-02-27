using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shop_Web_Api.Models
{
    public class Order
    {
        [Key] public int OrderID { get; set; }
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))] public IdentityUser User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}