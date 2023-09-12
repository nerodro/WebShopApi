using DomainLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Models
{
    public class CompanyViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        public string CompanyNamme { get; set; } = null!;
        public string CompanyIdentity { get; set; } = null;
    }
}
