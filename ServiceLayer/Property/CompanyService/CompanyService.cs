using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.Company;
using RepositoryLayer.Infrascructure.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private IProducts<Products> _products;
        private ICompany<Company> _company;
        private readonly ApplicationContext _context;
        public CompanyService(IProducts<Products> products, ICompany<Company> company)
        {
            this._company = company;
            this._products = products;
        }

        public IEnumerable<Products> GetAllProduct(long Id)
        { 
            return _context.Products.Where(x => x.CompanyId == Id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _company.GetAll();
        }

        public Company Get(long id)
        {
            return _company.Get(id);
        }

        public void Create(Company company)
        {
            _company.Create(company);
        }
        public void Update(Company company)
        {
            _company.Update(company);
        }

        public void Delete(long id)
        {
            List<Products> product = (List<Products>)_products.GetAll().Where(x => x.CompanyId == id).ToList();
            if (product != null)
            {
                _products.RemoveAll(product);
            }
            Company company = _company.Get(id);
            _company.Delete(company);
            _company.SaveChanges();
        }
    }
}
