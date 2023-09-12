using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.CartService
{
    public interface ICartService
    {
        IEnumerable<Cart> GetProductInCart(string name/*long Id*/);
        IEnumerable<Cart> GetAll();
        void AddProductToCart(Cart cart);
        void EditCount(Cart cart);
        void DeleteFromCart(long id);
        Cart Get(long id);
        void DeleteAll(long id);
    }
}
