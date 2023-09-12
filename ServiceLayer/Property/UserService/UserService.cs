using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Infrascructure.User;
using RepositoryLayer.Infrascructure.Cart;
using DomainLayer.Models;

namespace ServiceLayer.Property.UserService
{
    public class UserService : IUserService
    {
        private IUserLogic<User> userControlLogic;
        private IUserLogic<UserProfile> userProfileLogic;
        public UserService(IUserLogic<User> userControl, IUserLogic<UserProfile> userProfile)
        {
            this.userControlLogic = userControl;
            this.userProfileLogic = userProfile;
        }

        public IEnumerable<User> GetUsers()
        {
            return userControlLogic.GetAll();
        }

        public User GetUser(long id)
        {
            return userControlLogic.Get(id);
        }
        public int GetUserViaName(string name)
        {
            var user = userControlLogic.GetAll().Where(x => x.UserName == name).FirstOrDefault();
            int id = (int)user.Id;
            return id;
        }

        public void CreateUser(User user)
        {
            userControlLogic.Create(user);
        }
        public void UpdateUser(User user)
        {
            userControlLogic.Update(user);
        }

        public void DeleteUser(long id)
        {
            UserProfile userProfile = userProfileLogic.Get(id);
            userProfileLogic.Remove(userProfile);
            User user = GetUser(id);
            userControlLogic.Delete(user);
            userControlLogic.SaveChanges();
        }
    }
}
