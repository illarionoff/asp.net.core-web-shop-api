using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class SubCategoryFilter
    {
        [Key] public int SubCategoryFilterID { get; set; }
        [Required] public int FilterID { get; set; }
        public Filter Filter { get; set; }
        [Required] public int SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}