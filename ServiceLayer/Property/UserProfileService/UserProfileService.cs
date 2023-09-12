using DomainLayer.Models;
using RepositoryLayer.Infrascructure.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Property.UserProfileService
{
    public class UserProfileService : IUserProfileService
    {
        private IUserLogic<UserProfile> userProfileRepository;

        public UserProfileService(IUserLogic<UserProfile> userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }

        public UserProfile GetUserProfile(long id)
        {
            return userProfileRepository.Get(id);
        }
    }
}
