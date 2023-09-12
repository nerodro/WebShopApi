using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = null!;
        public string categoryico { get; set; } = null!;
        public virtual List<Products> Products { get; set; }
        public Category()
        {
            Products = new List<Products>();
        }
    }
}
