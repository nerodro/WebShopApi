using Microsoft.AspNetCore.Mvc;

namespace WebShop.Models
{
    public class CartViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int UserId { get; set; }
        public int Count { get; set; } = 0!;
    }
}
