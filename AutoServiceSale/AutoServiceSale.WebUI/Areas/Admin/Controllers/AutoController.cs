using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using AutoServiceSale.WebUI.Utilis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoServiceSale.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class AutoController : Controller
    {
       // private readonly IService<Auto> _service;
        private readonly IAutoService _service;
        private readonly IService<Brand> _serviceforBrand;

        public AutoController(IAutoService service,IService<Brand> serviceforBrand)
        {
            _service = service;
            _serviceforBrand = serviceforBrand;
        }

        

        // GET: AutoController
        public  async Task<ActionResult> Index()
        {
            var model = await _service.GetAllCustomAutoAsync();
            return View(model);
        }

        // GET: AutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutoController/Create
        public ActionResult Create()
        {
            ViewBag.BrandId= new SelectList(_serviceforBrand.GetAll(), "Id", "Name");
            return View();
        }

        // POST: AutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Auto auto,IFormFile? Picture1URL, IFormFile? Picture2URL, IFormFile? Picture3URL)
        {
            try
            {
                if (Picture1URL is not null)
                {
                    auto.Picture1URL = await FileHelper.FileLoaderAsync(Picture1URL, "/Img/Autos/");
                }
                
                if (Picture2URL is not null)
                {
                    auto.Picture2URL = await FileHelper.FileLoaderAsync(Picture2URL, "/Img/Autos/");
                }
            
                if (Picture3URL is not null)
                {
                auto.Picture3URL = await FileHelper.FileLoaderAsync(Picture3URL, "/Img/Autos/");
                }

            await _service.AddAsync(auto);
               await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.BrandId = new SelectList(_serviceforBrand.GetAll(), "Id", "Name");
                return View();
            }
        }

        // GET: AutoController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.BrandId = new SelectList(_serviceforBrand.GetAll(), "Id", "Name");
            return View(model);
        }

        // POST: AutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Auto auto, IFormFile? Picture1URL, IFormFile? Picture2URL, IFormFile? Picture3URL)
        {
            try
            {
                if (Picture1URL is not null)
                {
                    auto.Picture1URL = await FileHelper.FileLoaderAsync(Picture1URL,"/Img/Autos/");
                }

                if (Picture2URL is not null)
                {
                    auto.Picture2URL = await FileHelper.FileLoaderAsync(Picture2URL, "/Img/Autos/");
                }

                if (Picture3URL is not null)
                {
                    auto.Picture3URL = await FileHelper.FileLoaderAsync(Picture3URL, "/Img/Autos/");
                }
               
                _service.Update(auto);
             await   _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Auto auto)
        {
            try
            {
                _service.Delete(auto);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
