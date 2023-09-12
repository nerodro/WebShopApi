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

namespace WebShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;
        private readonly ICategoryService categoryService;
        private ApplicationContext context;

        public UserController(IUserService userService, IUserProfileService userProfileService, ICategoryService category)
        {
            this.userService = userService;
            this.userProfileService = userProfileService;
            this.categoryService = category;
        }

        [HttpGet("GetAllUsers")]
        //[Authorize(Roles = "Admin, Moder,User")]
        public IEnumerable<MultiViewModel> Index()
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
                        Name = $"{userProfile.FirstName} {userProfile.LastName}",
                        Email = u.Email,
                        Address = userProfile.Address
                    };
                    model.Add(user);
                });
            }
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            if (categoryService != null)
            {
                categoryService.GetAll().ToList().ForEach(f =>
                {
                    Category category = categoryService.Get(f.Id);
                    CategoryViewModel viewModel = new CategoryViewModel
                    {
                        Id = f.Id,
                        CategoryName = f.CategoryName
                    };
                    categories.Add(viewModel);
                });
            }
            MultiViewModel multi = new MultiViewModel();
            multi.UserViewModels = model;
            multi.CategoryViewModels = categories;
            yield return multi;
        }

        [HttpPost("CreateUsers")]
        public async Task<ActionResult<UserViewModel>> AddUser(UserViewModel model)
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
            return Ok(model);
        }

        [HttpPut("EditUser")]
        public async Task<ActionResult<UserViewModel>> EditUser(UserViewModel model)
        {
            User userEntity = userService.GetUser(model.Id);
            userEntity.Email = model.Email;
            userEntity.UserName = model.UserName;
            userEntity.ModifiedDate = DateTime.UtcNow;
            UserProfile userProfileEntity = userProfileService.GetUserProfile(model.Id);
            userProfileEntity.FirstName = model.FirstName;
            userProfileEntity.LastName = model.LastName;
            userProfileEntity.Address = model.Address;
            userProfileEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.UserProfile = userProfileEntity;
            userService.UpdateUser(userEntity);
            return Ok(model);
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
