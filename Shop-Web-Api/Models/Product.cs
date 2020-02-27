using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class Product
    {
        [Key] public int ProductID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Amount { get; set; }
        [Required] public decimal BasePrice { get; set; }
        public string PromoText { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}