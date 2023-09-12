using DomainLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Models
{
    public class ProductViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int ProductNumber { get; set; } = 0;
        public string? Photos { get; set; }
        public int Price { get; set; } = 0;
        public long CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public int CategoryId { get; set; } = 0!;
    }
}
