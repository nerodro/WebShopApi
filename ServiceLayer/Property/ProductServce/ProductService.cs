using RepositoryLayer.Infrascructure.Company;
using RepositoryLayer.Infrascructure.Products;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Infrascructure.Cart;
using DomainLayer.Models;

namespace ServiceLayer.Property.ProductServce
{
    public class ProductService : IProductService
    {
        private IProducts<Products> _products;
        private ICompany<Company> _company;
        private ICart<Cart> _cart;
        private readonly ApplicationContext _context;
        public ProductService(IProducts<Products> products, ICompany<Company> company, ICart<Cart> cart)
        {
            this._company = company;
            this._products = products;
            this._cart = cart;
        }

        public IEnumerable<Products> GetAll()
        {
            return _products.GetAll();
        }

        public Company GetCompany(long id)
        {
            return _context.Company.FirstOrDefault(x => x.Id == id);
        }

        public Products Get(long id)
        {
            return _products.Get(id);
        }

        public void Create(Products products)
        {
            _products.Create(products);
        }
        public void Update(Products products)
        {
            _products.Update(products);
        }

        public void Delete(long id)
        {
            List<Cart> cart = (List<Cart>)_cart.GetAllCart().Where(x => x.ProductsId == id).ToList();
            if (cart != null)
            {
                _cart.RemoveAll(cart);
            }
            Products product = _products.Get(id);
            _products.Remove(product);
            _products.SaveChanges();
        }
        public void DeleteAll(long id)
        {
            List<Products> products = _context.Products.Where(x => x.CompanyId == id).ToList();
            _products.RemoveAll(products);
        }
    }
}
