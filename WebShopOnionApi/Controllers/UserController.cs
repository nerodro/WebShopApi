using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryLayer;
using ServiceLayer.Property.Category;
using ServiceLayer.Property.UserProfileService;
using ServiceLayer.Property.UserService;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using TestOnion.Models;
using WebShop.Models;
using RepositoryLayer.Infrascructure.Company;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;
        private readonly ICategoryService categoryService;

        public UserController(IUserService userService, IUserProfileService userProfileService, ICategoryService category)
        {
            this.userService = userService;
            this.userProfileService = userProfileService;
            this.categoryService = category;
        }

        [HttpGet("GetAllUsers")]
        //[Authorize(Roles = "Admin, Moder,User")]
        public /*IEnumerable<MultiViewModel>*/ IEnumerable<UserViewModel> Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            if (userProfileService != null)
            {
                userService.GetUsers().ToList().ForEach(u =>
                {
                    UserProfile userProfile = userProfileService.GetUserProfile(u.Id);
                    UserViewModel user = new UserViewModel
                    {
                        Id = u.Id,
                        FirstName = userProfile.FirstName,
                        LastName = userProfile.LastName,
                        Email = u.Email,
                        RoleId = (long)u.RoleId,
                        Address = userProfile.Address
                    };
                    model.Add(user);
                });
            }
            return model;
        }

        [HttpPost("CreateUsers")]
        public async Task<ActionResult<UserViewModel>> CreateUsers(UserViewModel model)
        {
            User userEntity = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                RoleId = model.RoleId,
                UserProfile = new UserProfile
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                }
            };
            userService.CreateUser(userEntity);
            return CreatedAtAction("UserProfile", new { id = userEntity.Id }, model);
        }

        [HttpPut("EditUser/{id}")]
        public async Task<ActionResult<UserViewModel>> EditUser(int id, UserViewModel model)
        {
            model.Id = id;
            User userEntity = userService.GetUser(model.Id);
            UserProfile userProfileEntity = userProfileService.GetUserProfile(id);
            if (ModelState.IsValid)
            {
                userEntity.Email = model.Email;
                userEntity.UserName = model.UserName;
                userEntity.ModifiedDate = DateTime.UtcNow;
                userProfileEntity.FirstName = model.FirstName;
                userProfileEntity.LastName = model.LastName;
                userProfileEntity.Address = model.Address;
                userProfileEntity.ModifiedDate = DateTime.UtcNow;
                userEntity.UserProfile = userProfileEntity;
                userService.UpdateUser(userEntity);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<UserViewModel>> DeleteUser(long id)
        {
            UserProfile userProfile = userProfileService.GetUserProfile(id);
            userService.DeleteUser(id);
            return Ok(userProfile);
        }
        [HttpGet("GetOneUser/{id}")]
        public async Task<ActionResult<UserViewModel>> UserProfile(long id)
        {
            UserViewModel model = new UserViewModel();
            if (id != 0)
            {
                User userEntity = userService.GetUser(id);
                UserProfile userProfileEntity = userProfileService.GetUserProfile(id);
                model.Id = userEntity.Id;
                model.FirstName = userProfileEntity.FirstName;
                model.UserName = userEntity.UserName;
                model.LastName = userProfileEntity.LastName;
                model.Address = userProfileEntity.Address;
                model.Email = userEntity.Email;
                return new ObjectResult(model);
            }
            return BadRequest();
        }

    }
}
