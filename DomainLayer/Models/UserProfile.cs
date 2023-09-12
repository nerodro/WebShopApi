using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainLayer.Models
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? PostalCode { get; set; }
        public int? CardNumber { get; set; }
        public int? CSVCode { get; set; }
        public int? DateExpireCard { get; set; }
        //public long RoleId { get; set; }
        //public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public virtual List<Cart> Cart { get; set; }

        public UserProfile()
        {
            Cart = new List<Cart>();
        }
    }
}
