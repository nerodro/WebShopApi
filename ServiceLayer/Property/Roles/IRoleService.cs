using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.Roles
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        IEnumerable<User> GetUserForRole(long id);
        Role Get(long id);
    }
}
