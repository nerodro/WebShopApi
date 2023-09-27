using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.Company;
using ServiceLayer.Property.CartService;
using ServiceLayer.Property.CompanyService;
using ServiceLayer.Property.ProductServce;
using ServiceLayer.Property.UserService;
using System.Security.Claims;
using WebShop.Models;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IProductService _product;
        private readonly ICartService _cart;
        private readonly IUserService _user;
        private ApplicationContext context;

        public CartController(IProductService product, ICartService cart, IUserService user)
        {
            this._cart = cart;
            this._product = product;
            this._user = user;
        }

        [HttpGet("GetAllProductsInCart")]
        [Authorize]
        public IEnumerable<CartViewModel> Index()
        {
            string Id = User.FindFirst(ClaimTypes.Name).Value;
            List<CartViewModel> model = new List<CartViewModel>();
            if (_cart != null)
            {
                _cart.GetProductInCart(Id).ToList().ForEach(u =>
                {
                    CartViewModel cart = new CartViewModel
                    {
                        Id = u.Id,
                        ProductId = (int)u.ProductsId,
                        ProductName = u.ProductName,
                        Count = u.CountProduct
                    };
                    model.Add(cart);
                });
            }

            return model;
        }
        [HttpGet("GetAllCarts")]
        [Authorize]
        public IEnumerable<CartViewModel> AllCarts()
        {
            List<CartViewModel> model = new List<CartViewModel>();
            if (_cart != null)
            {
                _cart.GetAll().ToList().ForEach(u =>
                {
                    CartViewModel cart = new CartViewModel
                    {
                        Id = u.Id,
                        ProductId = (int)u.ProductsId,
                        ProductName = u.ProductName,
                        Count = u.CountProduct
                    };
                    model.Add(cart);
                });
            }

            return model;
        }

        [HttpGet("GetCart/{Id}")]
        [Authorize]
        public async Task<ActionResult<CartViewModel>> CartOnId(int Id)
        {
            CartViewModel model = new CartViewModel();
            Cart cart = _cart.Get(Id);
            if(cart != null)
            {
                model.Id = cart.Id;
                model.ProductName = cart.ProductName;
                model.UserId = (int)cart.UserProfileId;
                model.Count = cart.CountProduct;
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpPost("AddProductToCart/{id}")]
        public async Task<ActionResult<CartViewModel>> AddToCart(int id)
        {
            CartViewModel model = new CartViewModel();
            Products products = _product.Get(id);
            string Name = User.FindFirst(ClaimTypes.Name).Value;
            int UserId = _user.GetUserViaName(Name);
            Cart cart = new Cart
            {
                ProductsId = products.Id,
                UserProfileId = UserId,
                ProductName = products.ProductName,
                CountProduct = 1,
            };
            _cart.AddProductToCart(cart);
            if (cart.Id > 0)
            {
                model.Id = cart.Id;
                model.ProductName = cart.ProductName;
                model.UserId = (int)cart.UserProfileId;
                model.Count = cart.CountProduct;
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpPut("EditCountOfProduct/{id}")]
        public ActionResult EditCart(int id)
        {
            CartViewModel model = new CartViewModel { Id = id };
            Cart cart = _cart.Get(model.Id);
            cart.CountProduct = model.Count;
            _cart.EditCount(cart);
            if (cart.Id > 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteProductFromCard/{id}")]
        public ActionResult DeleteProductFromCart(long id)
        {
            CartViewModel model = new CartViewModel { Id = id };
            Cart cart = _cart.Get(model.Id);
            _cart.DeleteFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
