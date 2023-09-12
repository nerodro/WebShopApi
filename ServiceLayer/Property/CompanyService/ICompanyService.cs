using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.CompanyService
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();
        IEnumerable<Products> GetAllProduct(long id);
        Company Get(long id);
        void Create(Company company);
        void Update(Company company);
        void Delete(long id);
     //   void Remove(long id);
       // void SaveChanges();
    }
}
