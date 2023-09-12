using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.RegisterService
{
    public interface IRegistrationService
    {
        void CreateUser(User user);
    }
}
