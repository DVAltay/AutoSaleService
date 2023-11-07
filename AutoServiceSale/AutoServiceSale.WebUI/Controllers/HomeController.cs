using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using AutoServiceSale.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoServiceSale.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        
        private readonly IService<Slider> _service;
        private readonly IAutoService _serviceforAuto;
        public HomeController(IService<Slider> service, IAutoService serviceforAuto)
        {
            _service = service;
            _serviceforAuto = serviceforAuto;   
        }

       

       

        public async Task<IActionResult> Index()
        {
            var model = new HomePageModel()
            {
                Sliders = await _service.GetAllAsync(),
                Autos = await _serviceforAuto.GetAllCustomAutoAsync(x=>x.IsHomePage),
            };
             
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}