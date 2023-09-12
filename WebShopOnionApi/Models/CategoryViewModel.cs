using Microsoft.AspNetCore.Mvc;

namespace WebShop.Models
{
    public class CategoryViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        public string CategoryName { get; set; }
    }
}
