using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class ProductOptionValue
    {
        [Key] public int ProductOptionsValueID { get; set; }
        [Required] public int ProductID { get; set; }
        public Product Product { get; set; }
        [Required] public int FilterOptionID { get; set; }
        public FilterOption FilterOption { get; set; }
        [Required] public string FilterOptionValue { get; set; }
    }
}