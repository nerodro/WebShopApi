using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Property.Category;
using ServiceLayer.Property.Roles;
using ServiceLayer.Property.UserProfileService;
using ServiceLayer.Property.UserService;
using TestOnion.Models;
using WebShop.Models;
using WebShopOnionApi.Models;

namespace WebShopOnionApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class RoleController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IRoleService _role;
        public RoleController(IUserService userService, IUserProfileService userProfileService, IRoleService role)
        {
            this._userService = userService;
            this._userProfileService = userProfileService;
            this._role = role;
        }
        [HttpGet("AllUsersForRole/{id}")]
        public IEnumerable<UserViewModel> GetlAllUsersForRole(long id)
        {
            List<UserViewModel> model = new List<UserViewModel>();
            if (_userProfileService != null)
            {
                _role.GetUserForRole(id).ToList().ForEach(u =>
                {
                    UserProfile userProfile = _userProfileService.GetUserProfile(u.Id);
                    UserViewModel user = new UserViewModel
                    {
                        Id = u.Id,
                        Name = $"{userProfile.FirstName} {userProfile.LastName}",
                        Email = u.Email,
                        Address = userProfile.Address
                    };
                    model.Add(user);
                });
            }
            return model;
        }
        [HttpGet("AllRoles")]
        public IEnumerable<RoleViewModel> GetlAllRoles()
        {
            List<RoleViewModel> model = new List<RoleViewModel>();
            if (_role != null)
            {
                _role.GetAll().ToList().ForEach(u =>
                {
                    RoleViewModel role = new RoleViewModel
                    {
                        Id = u.Id,
                        RoleName = u.RoleName
                    };
                    model.Add(role);
                });
            }
            return model;
        }
        //[HttpGet("SingleRole/{id}")]
        //public async Task<ActionResult<UserViewModel>> UserProfile(long id)
        //{
        //    UserViewModel model = new UserViewModel();
        //    if (id != 0)
        //    {
        //        User userEntity = userService.GetUser(id);
        //        UserProfile userProfileEntity = userProfileService.GetUserProfile(id);
        //        model.Id = userEntity.Id;
        //        model.FirstName = userProfileEntity.FirstName;
        //        model.UserName = userEntity.UserName;
        //        model.LastName = userProfileEntity.LastName;
        //        model.Address = userProfileEntity.Address;
        //        model.Email = userEntity.Email;
        //        return new ObjectResult(model);
        //    }
        //    return BadRequest();
        //}
    }
}
