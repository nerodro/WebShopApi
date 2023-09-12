using DomainLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Infrascructure.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Categories
{
    public class CategoriesLogic<T> : ICategories<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public CategoriesLogic(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAllCategories()
        {
            return entities.AsEnumerable();
        }
        public void AddCategory(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void EditCategory(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void DeleteCategory(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void RemoveCategory(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }
        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public IEnumerable<T> GetAllCart()
        {
            return entities.AsEnumerable();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void RemoveAll(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.Count() != 0)
            {
                entities.RemoveRange(entity);
            }
        }
    }
}
