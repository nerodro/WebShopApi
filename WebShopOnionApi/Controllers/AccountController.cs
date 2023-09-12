//using DomainLayer;
//using DomainLayer.Models;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Mvc;
//using RepositoryLayer;
//using ServiceLayer.Property.LoginService;
//using ServiceLayer.Property.RegisterService;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using WebShop.Models;

//namespace WebShop.Controllers
//{
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private readonly ApplicationContext context;
//        private readonly IRegistrationService _registeredServices;
//        private readonly ILoginService _loginService;
//        public AccountController(IRegistrationService registered, ILoginService login)
//        {
//            this._registeredServices = registered;
//            this._loginService = login;
//        }
//        [HttpGet]
//        //[ValidateAntiForgeryToken]
//        public IActionResult Register()
//        {
//            RegistrationViewModel model = new RegistrationViewModel();

//            return View("Register", model);
//        }
//        [HttpPost]
//        public async Task<IActionResult> Register(RegistrationViewModel registrationViewModel)
//        {
//            User userEntity = new User
//            {
//                UserName = registrationViewModel.FirstName,
//                Password = HasPassword(registrationViewModel.Password),

//                AddedDate = DateTime.UtcNow,
//                ModifiedDate = DateTime.UtcNow,
//                RoleId = 3,
//                UserProfile = new UserProfile
//                {
//                    FirstName = registrationViewModel.FirstName,
//                    AddedDate = DateTime.UtcNow,
//                    ModifiedDate = DateTime.UtcNow,
//                }
//            };
//            _registeredServices.CreateUser(userEntity);
//            await Authenticate(userEntity);
//            if (userEntity.Id > 0)
//            {

//                return RedirectToAction("Index", "User");
//            }
//            else
//            {
//                ModelState.AddModelError("", "Ошибка");
//            }
//            return View(registrationViewModel);
//        }
//        [HttpGet]
//        public ActionResult Login()
//        {
//            return View("Login");
//        }

//        [HttpPost]
//        public async Task<ActionResult> LoginAsync(LoginViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                string name = model.FirstName;
//                string password = HasPassword(model.Password);
//                User userEntity = _loginService.GetUser(name, password);
                
//                if (userEntity != null)
//                {
//                    await Authenticate(userEntity);
//                    return RedirectToAction("Index", "User");
//                }
//                else if (userEntity == null)
//                {
//                    ModelState.AddModelError("Ошибка", "Ошибка");
//                }
//            }
//            return View(model);
//        }
//        private async Task Authenticate(User user)
//        {
//                // создаем один claim
//                var claims = new List<Claim>
//            {
//                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
//                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.RoleName),
//            };
//                // создаем объект ClaimsIdentity
//                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
//                    ClaimsIdentity.DefaultRoleClaimType);
//                // установка аутентификационных куки
//                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            
//        }
//        public async Task<IActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return RedirectToAction("Login", "Account");
//        }
//        private static string HasPassword(string Password)
//        {
//            MD5 md5 = MD5.Create();
//            byte[] b = Encoding.ASCII.GetBytes(Password);
//            byte[] hash = md5.ComputeHash(b);
//            StringBuilder sb = new StringBuilder();
//            foreach (var i in hash)
//            {
//                sb.Append(i.ToString("X2"));
//            }
//            return Convert.ToString(sb);
//        }
//    }
//}
