using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.Company;
using ServiceLayer.Property.Category;
using ServiceLayer.Property.ProductServce;
using WebShop.Models;

namespace WebShopOnionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IProductService _product = null!;
        private readonly ICategoryService _category = null!;

        public CategoryController(IProductService product, ICategoryService category)
        {
            this._category = category;
            this._product = product;
        }
        [HttpGet("GetProductsForCategory/{id}")]
        public IEnumerable<ProductViewModel> OpenCategory(int id)
        {
            List<ProductViewModel> models = new List<ProductViewModel>();
            if (_category != null)
            {
                _category.GetAllProduct(id).ToList().ForEach(u =>
                {
                    ProductViewModel procut = new ProductViewModel
                    {
                        ProductName = u.ProductName,
                        ProductDescription = u.ProductDescription,
                    };
                    models.Add(procut);
                });
            }
            return models;
        }
        [HttpGet("GetAllCategories")]
        public IEnumerable<CategoryViewModel> AllCategories()
        {
            List<CategoryViewModel> model = new List<CategoryViewModel>();
            if (_category != null)
            {
                _category.GetAll().ToList().ForEach(u =>
                {
                    CategoryViewModel category = new CategoryViewModel
                    {
                        Id = u.Id,
                        CategoryName = u.CategoryName,
                    };
                    model.Add(category);
                });
            }
            return model;
        }
        [HttpGet("GetCurrentCategory/{Id}")]
        public async Task<ActionResult<CategoryViewModel>> CurrentCategory(int Id)
        {
            CategoryViewModel model = new CategoryViewModel();
            Category category = _category.Get(Id);
            if (category != null)
            {
                model.Id = category.Id;
                model.CategoryName = category.CategoryName;
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<CategoryViewModel>> AddCategory(CategoryViewModel model)
        {
            Category category = new Category
            {
                CategoryName = model.CategoryName,
            };
            _category.Create(category);
            if (category.Id > 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpPut("EditCategory")]
        public async Task<ActionResult<CategoryViewModel>> EditCategory(CategoryViewModel model)
        {
            Category category = _category.Get(model.Id);
            category.CategoryName = model.CategoryName;
            _category.Update(category);
            if (category.Id > 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteCategory/{id}")]
        public ActionResult DeleteCategory(long id)
        {
            Category category = _category.Get(id);
            _category.Delete(id);
            return Ok(category);
        }
    }
}
