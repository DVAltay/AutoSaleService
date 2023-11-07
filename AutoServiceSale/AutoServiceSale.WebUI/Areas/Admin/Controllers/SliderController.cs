using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using AutoServiceSale.WebUI.Utilis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceSale.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class SliderController : Controller
    {
        private readonly IService<Slider> _service;

        public SliderController(IService<Slider> service)
        {
            _service = service;
        }

        // GET: SliderController
        public async Task<ActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(Slider slider,IFormFile? picture)
        {
            try
            {
                if (picture is not null)
                {
                    slider.Picture = await FileHelper.FileLoaderAsync(picture, "/Img/Slider/");
                }
                await _service.AddAsync(slider);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.Find(id));
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Slider slider, IFormFile picture)
        {
            try
            {
                if (picture is not null)
                {
                    slider.Picture = await FileHelper.FileLoaderAsync(picture, "/Img/Slider/");
                }
                _service.Update(slider);
                await  _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Slider slider)
        {
            try
            {
                _service.Delete(slider);
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
