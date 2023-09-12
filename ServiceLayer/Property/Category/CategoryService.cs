using DomainLayer.Models;
using RepositoryLayer.Infrascructure.Company;
using RepositoryLayer.Infrascructure.Products;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Infrascructure.Categories;

namespace ServiceLayer.Property.Category
{
    public class CategoryService : ICategoryService
    {
        private IProducts<Products> _products;
        private ICategories<DomainLayer.Models.Category> _categoryService;
        private readonly ApplicationContext _context;
        public CategoryService(IProducts<Products> products, ICategories<DomainLayer.Models.Category> categories)
        {
            this._products = products;
            this._categoryService = categories;
        }

        public IEnumerable<Products> GetAllProduct(int Id)
        {
            return _products.GetAll().Where(x => x.CategoryId == Id);
        }

        public IEnumerable<DomainLayer.Models.Category> GetAll()
        {
            return _categoryService.GetAllCategories();
        }

        public DomainLayer.Models.Category Get(long id)
        {
            return _categoryService.Get(id);
        }

        public void Create(DomainLayer.Models.Category categories)
        {
            _categoryService.AddCategory(categories);
        }
        public void Update(DomainLayer.Models.Category categories)
        {
            _categoryService.EditCategory(categories);
        }

        public void Delete(long id)
        {
            DomainLayer.Models.Category categories = _categoryService.Get(id);
            _categoryService.DeleteCategory(categories);
            _categoryService.SaveChanges();
        }
    }
}
