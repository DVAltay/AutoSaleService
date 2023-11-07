using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace AutoServiceSale.WebUI.Areas.Admin
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<User> _service;
        private readonly IService<Role> _serviceforRole;

        public LoginController(IService<User> service, IService<Role> serviceforRole)
        {
            _service = service;
            _serviceforRole = serviceforRole;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email,string password)
        {
            try
            {
              var user =  _service.Get(u => u.Email == email && u.Password == password && u.IsActive );
                if (user == null)
                {
                    TempData["Message"] = "User not found";
                }
                else 
                {
                    var role=_serviceforRole.Get(r=>r.Id == user.RoleId);
                    var claims = new List<Claim>()
                    {
                       new Claim(ClaimTypes.Name,user.Name),
                       new Claim("Role",role.Name)
                    };
                    var userIdentity = new ClaimsIdentity(claims,"Login");
                    ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin");
                }
                 
            }
            catch (Exception)
            {

                TempData["Message"] = "Error";
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
    }
}
