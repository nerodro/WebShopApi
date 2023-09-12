using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.Registration;
using RepositoryLayer.Infrascructure.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.RegisterService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationContext _context;
        private readonly IRegistration<User> _registrationService;
        private readonly IUserLogic<User> _userLogic;
        public RegistrationService( IRegistration<User> registration, IUserLogic<User> userLogic, ApplicationContext context) 
        {
            this._registrationService = registration;
            this._userLogic = userLogic;
            this._context = context;
        }
        public async void CreateUser(User user)
        {

            User user1 = _context.User.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            Role userRole = _context.Role.FirstOrDefault(r => r.RoleName == "User");
            if (userRole != null)
            {
                user.Role = userRole;
            }
            if (user1 == null)
            {
                _registrationService.Create(user);
            }

        }
    }
}
