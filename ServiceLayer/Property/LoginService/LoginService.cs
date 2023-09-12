using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationContext _context;
        private IUserLogic<User> userControlLogic;
        private IUserLogic<UserProfile> userProfileLogic;
        public LoginService(IUserLogic<User> userControl, IUserLogic<UserProfile> userProfile,  ApplicationContext context)
        {
            this.userControlLogic = userControl;
            this.userProfileLogic = userProfile;
            this._context = context;
        }

        public User GetUser(string name, string password)
        {
            User user1 = _context.User.Include(u => u.Role).FirstOrDefault(x => x.UserName == name && x.Password == password);
            //User user1 = _context.User.FirstOrDefault(x => x.UserName == name && x.Password == password);
            if (user1 != null)
            {
                long id = user1.Id;
                return userControlLogic.Get(id);
            }
            else
            {
                return null;
            }
        }
    }
}
