using TestOnion.Models;

namespace WebShop.Models
{
    public class MultiViewModel
    {
        public List<UserViewModel> UserViewModels { get; set; }
        public List<CategoryViewModel> CategoryViewModels { get; set; }
    }
}
