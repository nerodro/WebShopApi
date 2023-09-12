using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.LoginService
{
    public interface ILoginService
    {
        User GetUser(string name, string password);
    }
}
