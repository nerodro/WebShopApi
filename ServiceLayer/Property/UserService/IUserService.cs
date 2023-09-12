using DomainLayer.Models;

namespace ServiceLayer.Property.UserService
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        int GetUserViaName(string name);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }
}
