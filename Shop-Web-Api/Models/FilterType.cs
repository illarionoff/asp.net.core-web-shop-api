using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class FilterType
    {
        [Key] public int FilterTypeID { get; set; }
        [Required] public string FilterTypeName { get; set; }
    }
}