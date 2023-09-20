using Microsoft.AspNetCore.Mvc;

namespace WebShopOnionApi.Models
{
    public class RoleViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
