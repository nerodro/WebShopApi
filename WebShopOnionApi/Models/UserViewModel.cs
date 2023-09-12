﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestOnion.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
    }
}
