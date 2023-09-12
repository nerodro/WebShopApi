using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.UserProfileService
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(long id);
    }
}
