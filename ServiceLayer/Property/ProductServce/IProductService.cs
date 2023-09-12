using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.ProductServce
{
    public interface IProductService
    {
        IEnumerable<Products> GetAll();
        Company GetCompany(long id);
        Products Get(long id);
        void Create(Products products);
        void Update(Products products);
        void Delete(long id);
        void DeleteAll(long id);
    }
}
