using RepositoryLayer.Infrascructure.Products;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.Cart;
using RepositoryLayer.Infrascructure.User;
using DomainLayer.Models;

namespace ServiceLayer.Property.CartService
{
    public class CartService : ICartService
    {
        private ICart<Cart> _cart;
        private IProducts<Products> _products;
        private IUserLogic<User> _userLogic;
        private readonly ApplicationContext _context;
        public CartService(IProducts<Products> products, ICart<Cart> cart, IUserLogic<User> user)
        {
            this._cart = cart;
            this._products = products;
            this._userLogic = user;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cart.GetAllCart();
        }
        public IEnumerable<Cart> GetProductInCart(string name)
        {
            var user = _userLogic.GetAll().Where(x => x.UserName == name).FirstOrDefault();
            List<Cart> cart = (List<Cart>)_cart.GetAllCart().Where(x => x.UserProfileId == user.Id).ToList();
            return cart;
        }

        public void AddProductToCart(Cart cart)
        {
            _cart.AddToCart(cart);
        }
        public void EditCount(Cart cart)
        {
            _cart.EditCount(cart);
        }
        public Cart Get(long id)
        {
            return _cart.Get(id);
        }

        public void DeleteFromCart(long id)
        {
            Cart cart = _cart.Get(id);
            _cart.DeleteFromCart(cart);
            _cart.SaveChanges();
        }
        public void DeleteAll(long id)
        {
            List<Cart> carts = _context.Cart.Where(x => x.ProductsId == id).ToList();
            _cart.RemoveAll(carts);
        }
    }
}
