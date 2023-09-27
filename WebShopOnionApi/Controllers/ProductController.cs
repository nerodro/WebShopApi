using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using ServiceLayer.Property.CompanyService;
using ServiceLayer.Property.ProductServce;
using ServiceLayer.Property.UserProfileService;
using ServiceLayer.Property.UserService;
using TestOnion.Models;
using WebShop.Models;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ICompanyService _company = null!;
        private readonly IProductService _product = null!;

        public ProductController(ICompanyService company, IProductService product)
        {
            this._company = company;
            this._product = product;
        }

        [HttpGet("ViewAllProducts")]
        public IEnumerable<ProductViewModel> Index()
        {
            List<ProductViewModel> model = new List<ProductViewModel>();
            if (_product != null)
            {
                _product.GetAll().ToList().ForEach(u =>
                {
                    Company company = _company.Get(u.CompanyId);
                    ProductViewModel product = new ProductViewModel()
                    {
                        Id = u.Id,
                        ProductName = u.ProductName,
                        ProductNumber = u.ProductNumber,
                        Price = u.Price,
                        ProductDescription = u.ProductDescription,
                        CompanyName = company.CompanyNamme,
                        CategoryId = (int)u.CategoryId,
                        productStatus = u.statusProduct
                    };
                    model.Add(product);
                });
            }

            return model;
        }
        [HttpGet("ViewAllActiveProducts")]
        public IEnumerable<ProductViewModel> AllActive()
        {
            List<ProductViewModel> model = new List<ProductViewModel>();
            if (_product != null)
            {
                _product.GetActive().ToList().ForEach(u =>
                {
                    Company company = _company.Get(u.CompanyId);
                    ProductViewModel product = new ProductViewModel()
                    {
                        Id = u.Id,
                        ProductName = u.ProductName,
                        ProductNumber = u.ProductNumber,
                        Price = u.Price,
                        ProductDescription = u.ProductDescription,
                        CompanyName = company.CompanyNamme,
                        CategoryId = (int)u.CategoryId,
                        productStatus = u.statusProduct
                    };
                    model.Add(product);
                });
            }

            return model;
        }
        [HttpGet("ViewAllHaltProducts")]
        public IEnumerable<ProductViewModel> AllHalt()
        {
            List<ProductViewModel> model = new List<ProductViewModel>();
            if (_product != null)
            {
                _product.GetHalt().ToList().ForEach(u =>
                {
                    Company company = _company.Get(u.CompanyId);
                    ProductViewModel product = new ProductViewModel()
                    {
                        Id = u.Id,
                        ProductName = u.ProductName,
                        ProductNumber = u.ProductNumber,
                        Price = u.Price,
                        ProductDescription = u.ProductDescription,
                        CompanyName = company.CompanyNamme,
                        CategoryId = (int)u.CategoryId,
                        productStatus = u.statusProduct
                    };
                    model.Add(product);
                });
            }

            return model;
        }
        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductViewModel>> AddProduct(ProductViewModel model)
        {
            Products products = new Products
            {
                ProductName = model.ProductName,
                CompanyId = model.CompanyId,
                Price = model.Price,
                ProductDescription = model.ProductDescription,
                ProductNumber = model.ProductNumber,
                CategoryId = model.CategoryId,
                statusProduct = model.productStatus
            };
            _product.Create(products);
            if (products.Id > 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpPut("EditProduct/{id}")]
        public async Task<ActionResult<ProductViewModel>> EditProduct(int id, ProductViewModel model)
        {
            model.Id = id;
            Products products = _product.Get(model.Id);
            products.CompanyId = model.CompanyId;
            products.ProductNumber = model.ProductNumber;
            products.ProductDescription = model.ProductDescription;
            products.ProductName = model.ProductName;
            products.Price = model.Price;
            products.ModifiedDate = DateTime.UtcNow;
            _product.Update(products);
            if (products.Id > 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpPut("EditStatusProduct/{Id},{statusId}")]
        public async Task<ActionResult<ProductViewModel>> EditStatusProduct(int Id, int statusId)
        {
            ProductViewModel model = new ProductViewModel();
            Products products = _product.Get(Id);
            model.productStatus = statusId;
            products.statusProduct = model.productStatus;
            products.ModifiedDate = DateTime.UtcNow;
            _product.UpdateStatus(products);
            if (products.Id > 0)
            {
                return Ok(model.productStatus);
            }
            return BadRequest();
        }


        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<ProductViewModel>> DeleteProduct(long id)
        {
            Products products = _product.Get(id);
            _product.Delete(id);
            return Ok(products);
        }
        [HttpGet("GetSingleProduct/{id}")]
        public async Task<ActionResult<ProductViewModel>> ProductProfile(long id)
        {

            ProductViewModel model = new ProductViewModel();

            if (id != 0)
            {
                Products products = _product.Get(id);
                Company company = _company.Get(products.CompanyId);
                model.ProductNumber = products.ProductNumber;
                model.ProductDescription = products.ProductDescription;
                model.ProductName = products.ProductName;
                model.Price = products.Price;
                model.CompanyName = company.CompanyNamme;
                return new ObjectResult(model);
            }
            return BadRequest();
        }
    }
}
