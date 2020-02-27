using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class Filter
    {
        [Key] public int FilterID { get; set; }
        [Required] public int FilterTypeID { get; set; }
        public FilterType FilterType { get; set; }
    }
}