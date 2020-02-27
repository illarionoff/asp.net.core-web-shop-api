using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class FilterOption
    {
        [Key] public int FilterOptionID { get; set; }
        [Required] public string OptionName { get; set; }
        [Required] public int FilterID { get; set; }
        public Filter Filter { get; set; }
    }
}