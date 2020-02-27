using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class DiscountType
    {
        [Key] public int DiscountTypeID { get; set; }
        [Required] public string DiscountTypeName { get; set; }
    }
}