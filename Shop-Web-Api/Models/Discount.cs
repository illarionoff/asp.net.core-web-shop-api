using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_Web_Api.Models
{
    public class Discount
    {
        [Key] public int DiscountID { get; set; }
        [Required] public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DiscountPercent { get; set; }
        [Required] public int DiscountTypeID { get; set; }
        public DiscountType DiscountType { get; set; }
    }
}