using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class SubCategory
    {
        [Key] public int SubCategoryID { get; set; }
        [Required] public string SubCategoryName { get; set; }
        [Required] public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}