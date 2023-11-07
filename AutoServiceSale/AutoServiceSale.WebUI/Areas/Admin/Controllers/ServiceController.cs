using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceSale.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ServiceController : Controller
    {
        private readonly IService<Entities.Concrete.Service> _service;

        public ServiceController(IService<Entities.Concrete.Service> service)
        {
            _service = service;
        }

        // GET: ServiceController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Entities.Concrete.Service service)
        {
            try
            {
               await _service.AddAsync(service);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model=await _service.FindAsync(id);
            return View(model);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Entities.Concrete.Service service)
        {
            try
            {
                _service.Update(service);
               await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Entities.Concrete.Service service)
        {
            try
            {
                _service.Delete(service);
              await  _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
