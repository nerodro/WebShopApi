using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Cart
{
    public interface ICart<T> where T : BaseEntity
    {
        IEnumerable<T> GetCart(/*long Id*/);
        IEnumerable<T> GetAllCart();
        void AddToCart(T entity);
        void EditCount(T entity);
        void DeleteFromCart(T entity);
        void RemoveFromCart(T entity);
        T Get(long id);
        void SaveChanges();
        void RemoveAll(List<T> entity);
    }
}
