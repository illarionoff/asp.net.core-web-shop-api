using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shop_Web_Api.Models
{
    public class Contact
    {
        [Key] public int ContactID { get; set; }
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))] public IdentityUser User { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}