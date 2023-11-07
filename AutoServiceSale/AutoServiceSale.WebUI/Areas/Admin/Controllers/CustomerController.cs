using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoServiceSale.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class CustomerController : Controller
    {
        private readonly IService<Customer> _service;
        private readonly IService<Auto> _serviceforAuto;

        public CustomerController(IService<Customer> service, IService<Auto> serviceforAuto)
        {
            _service = service;
            _serviceforAuto = serviceforAuto;
        }

        // GET: CustomerController
        public async Task <ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "NumberPlate");
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                await _service.AddAsync(customer);
                await _service.SaveAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Unexpected error");
            }
            ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "NumberPlate");
            return View();
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "NumberPlate");
            return View(model);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _service.Update(customer);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "NumberPlate");
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                _service.Delete(customer);
                _service.Save();
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
