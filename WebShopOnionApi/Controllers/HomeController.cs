//using DomainLayer.Models;
//using Microsoft.AspNetCore.Mvc;
//using RepositoryLayer;
//using RepositoryLayer.Infrascructure.Cart;
//using ServiceLayer.Property.Category;
//using ServiceLayer.Property.ProductServce;
//using System.Diagnostics;
//using System.Security.Claims;
//using WebShop.Models;

//namespace WebShop.Controllers
//{
//    public class HomeController : ControllerBase
//    {
//        private readonly IProductService _product;
//        private readonly ICategoryService _category;
//        private ApplicationContext context;
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger, IProductService product, ICategoryService category)
//        {
//            _logger = logger;
//            this._category = category;
//            this._product = product;
//        }
//        [HttpGet]
//        public ActionResult OpenCategory(int id)
//        {
//            List<ProductViewModel> models = new List<ProductViewModel>();
//            if(_category != null)
//            {
//                _category.GetAllProduct(id).ToList().ForEach(u =>
//                {
//                    ProductViewModel procut = new ProductViewModel
//                    {
//                        ProductName = u.ProductName,
//                        ProductDescription = u.ProductDescription,
//                    };
//                    models.Add(procut);
//                });
//            }
//            return View("OpenCategory", models);
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult Chat()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}