using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestOnion.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long RoleId { get; set; } = 0!;
        public string Password { get; set; } = null!;
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
    }
}
