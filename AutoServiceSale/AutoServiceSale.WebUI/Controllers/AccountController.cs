using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using AutoServiceSale.Service.Concrete;
using AutoServiceSale.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AutoServiceSale.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<User> _userService;
        private readonly IService<Role> _roleService;

        public AccountController(IService<User> userService, IService<Role> roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [Authorize (Policy="CustomerPolicy")]
        public IActionResult Index()
        {
            var userguid = User.FindFirst(ClaimTypes.UserData)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userguid.IsNullOrEmpty()==false & email.IsNullOrEmpty()==false)
            {
                var user = _userService.Get(u=> u.Email==email && u.UserGuid.ToString()==userguid);

                if (user != null)
                {
                    return View(user);
                }
            }
           
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UserUpdate(User user)
        {
            _userService.Update(user);
            await _userService.SaveAsync();
            TempData["Message"] = "Saved";
            return View("Index",user);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var role = _roleService.Get(r => r.Name == "Customer");
                user.RoleId = role.Id;
                user.IsActive = true;
                await _userService.AddAsync(user);
                await _userService.SaveAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Login(CustomerLoginViewModel customerloginviewmodel)
        {
            try
            {
                var user = await _userService.GetAsync(u => u.Email == customerloginviewmodel.Email && u.Password == customerloginviewmodel.Password && u.IsActive);
                if (user == null)
                {
                    TempData["Message"] = "User not found";
                    return View();
                }
                else
                {
                    var role = _roleService.Get(r => r.Id == user.RoleId);
                    var claims = new List<Claim>()
                    {
                       new Claim(ClaimTypes.Name,user.Name),
                       new Claim(ClaimTypes.Email,user.Email),
                       new Claim(ClaimTypes.UserData,user.UserGuid.ToString()),
                       new Claim("Role",role.Name)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    if (role.Name=="Admin")
                    {
                        return Redirect("/Admin");
                    }
                    return Redirect("/Account");
                }

            }
            catch (Exception)
            {

                TempData["Message"] = "Error";
                return View();
            }
           
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            
            return Redirect("/Account/Login");
        }
    }
}
