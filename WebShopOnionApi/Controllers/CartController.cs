//using DomainLayer.Models;
//using Microsoft.AspNetCore.Mvc;
//using RepositoryLayer;
//using RepositoryLayer.Infrascructure.Company;
//using ServiceLayer.Property.CartService;
//using ServiceLayer.Property.CompanyService;
//using ServiceLayer.Property.ProductServce;
//using ServiceLayer.Property.UserService;
//using System.Security.Claims;
//using WebShop.Models;

//namespace WebShop.Controllers
//{
//    public class CartController : ControllerBase
//    {
//        private readonly IProductService _product;
//        private readonly ICartService _cart;
//        private readonly IUserService _user;
//        private ApplicationContext context;

//        public CartController(IProductService product, ICartService cart, IUserService user)
//        {
//            this._cart= cart;
//            this._product = product;
//            this._user = user;
//        }

//        [HttpGet]
//        //[Authorize(Roles = "admin, moder,user")]
//        public IActionResult Index()
//        {
//            string Id = User.FindFirst(ClaimTypes.Name).Value;
//            List<CartViewModel> model = new List<CartViewModel>();
//            if (_cart != null)
//            {
//                _cart.GetProductInCart(Id).ToList().ForEach(u =>
//                {
//                    CartViewModel cart = new CartViewModel
//                    {
//                        Id = u.Id,
//                        ProductId = (int)u.ProductsId,
//                        ProductName = u.ProductName,
//                        Count = u.CountProduct
//                    };
//                    model.Add(cart);
//                });
//            }

//            return View(model);
//        }

//        [HttpGet]
//        public ActionResult AddToCart(int? Id)
//        {
//            string Name = User.FindFirst(ClaimTypes.Name).Value;
//            CartViewModel cart = new CartViewModel();
//            if(Id.HasValue && Id != 0)
//            {
//                Products products = _product.Get((long)Id);
//                cart.ProductName = products.ProductName;
//                cart.UserId = _user.GetUserViaName(Name);
//                cart.ProductId = (int)products.Id;
//                cart.ProductName = products.ProductName;
//            }
//            //return RedirectToAction("Index", "Cart");
//            return View("AddToCart", cart);
//        }


//        [HttpPost]
//        public async Task<IActionResult> AddToCart(CartViewModel model)
//        {
//            Cart cart = new Cart
//            {
//                ProductsId = model.ProductId,
//                UserProfileId = model.UserId,
//                ProductName= model.ProductName,
//                CountProduct = 1,
//            };
//            _cart.AddProductToCart(cart);
//            if (cart.Id > 0)
//            {
//                return RedirectToAction("Index", "Cart");
//            }
//            return View(model);
//        }
//        [HttpGet]
//        public ActionResult EditCart(int? id)
//        {
//            CartViewModel model = new CartViewModel();
//            if (id.HasValue && id != 0)
//            {
//                Cart cart = _cart.Get(id.Value);
//                model.Count = cart.CountProduct;
//            }
//            return View("EditCart", model);
//        }

//        [HttpPost]
//        public ActionResult EditCart(CartViewModel model)
//        {
//            Cart cart = _cart.Get(model.Id);
//            cart.CountProduct = model.Count;
//            _cart.EditCount(cart);
//            if (cart.Id > 0)
//            {
//                return RedirectToAction("index");
//            }
//            return View(model);
//        }

//        [HttpGet]
//        public ActionResult DeleteProductFromCart(int id)
//        {
//            Cart cart = _cart.Get(id);
//            string name = $"{cart.ProductName} {cart.CountProduct}";
//            return View("DeleteProductFromCart", name);
//        }

//        [HttpPost]
//        public ActionResult DeleteProductFromCart(long id)
//        {
//            _cart.DeleteFromCart(id);
//            return RedirectToAction("Index");
//        }
//    }
//}
