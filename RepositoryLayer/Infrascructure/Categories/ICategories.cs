using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Categories
{
    public interface ICategories<T> where T : BaseEntity
    {
        IEnumerable<T> GetAllCategories();
        void AddCategory(T entity);
        void EditCategory(T entity);
        void DeleteCategory(T entity);
        void RemoveCategory(T entity);
        T Get(long id);
        void SaveChanges();
        void RemoveAll(List<T> entity);
    }
}
