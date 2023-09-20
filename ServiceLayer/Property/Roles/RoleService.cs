using DomainLayer.Models;
using RepositoryLayer.Infrascructure.Cart;
using RepositoryLayer.Infrascructure.Company;
using RepositoryLayer.Infrascructure.Products;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Infrascructure.Roles;
using RepositoryLayer.Infrascructure.User;

namespace ServiceLayer.Property.Roles
{
    public class RoleService : IRoleService
    {
        private IRoles<Role> _roles;
        private IUserLogic<User> _user;
        public RoleService(IRoles<Role> roles, IUserLogic<User> user)
        {
            this._roles = roles;
            this._user = user;
        }

        public IEnumerable<Role> GetAll()
        {
            return _roles.GetAll();
        }
        public IEnumerable<User> GetUserForRole(long id)
        {
            yield return (User)_user.GetAll().Where(x => x.RoleId == id);
        }

        public Role Get(long id)
        {
            return _roles.Get(id);
        }
    }
}
