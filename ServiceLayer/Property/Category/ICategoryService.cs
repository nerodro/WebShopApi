using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.Category
{
    public interface ICategoryService
    {
        IEnumerable<DomainLayer.Models.Category> GetAll();
        IEnumerable<Products> GetAllProduct(int id);
        DomainLayer.Models.Category Get(long id);
        void Create(DomainLayer.Models.Category categories);
        void Update(DomainLayer.Models.Category categories);
        void Delete(long id);
    }
}
