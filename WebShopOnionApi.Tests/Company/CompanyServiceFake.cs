using DomainLayer.Models;
using ServiceLayer.Property.CompanyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopOnionApi.Tests
{
    public class CompanyServiceFake : ICompanyService
    {
        private readonly List<Company> _companyList;
        public CompanyServiceFake()
        {
            _companyList = new List<Company>();
            {
                new Company() { Id = 1, CompanyNamme = "Test1", CompanyIdentity = "Test1" };

                new Company() { Id = 2, CompanyNamme = "Test2", CompanyIdentity = "Test2" };
            };
        }
        public IEnumerable<Company> GetAll()
        {
            return _companyList;
        }
        public Company Get(long id)
        {
            return _companyList.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Products> GetAllProduct(long id)
        {
            throw new NotImplementedException();
        }

        public void Create(Company company)
        {
            company.Id = 1;
            _companyList.Add(company);
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
