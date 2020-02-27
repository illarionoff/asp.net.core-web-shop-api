using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class Category
    {
        [Key] public int CategoryID { get; set; }
        [Required] public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}