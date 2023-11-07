using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoServiceSale.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class SaleController : Controller
    {
        private readonly IService<Sale> _service;
        private readonly IService<Auto> _serviceforAuto;
        private readonly IService<Customer> _serviceforCustomer;

        public SaleController(IService<Sale> service, IService<Auto> serviceforAuto, IService<Customer> serviceforCustomer)
        {
            _service = service;
            _serviceforCustomer = serviceforCustomer;
            _serviceforAuto = serviceforAuto;
        }



        // GET: SaleController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync(includeprops: "Auto", includeprops2: "Customer");
            return View(model);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(_serviceforCustomer.GetAll(), "Id", "Name");
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Sale sale)
        {
            try
            {
               await _service.AddAsync(sale);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "Model");
                ViewBag.CustomerId = new SelectList(_serviceforCustomer.GetAll(), "Id", "Name");
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(_serviceforCustomer.GetAll(), "Id", "Name");
            var model=  await _service.FindAsync(id);
            return View(model);
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(Sale sale)
        {
            try
            {
                _service.Update(sale);
              await  _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.AutoId = new SelectList(_serviceforAuto.GetAll(), "Id", "Model");
                ViewBag.CustomerId = new SelectList(_serviceforCustomer.GetAll(), "Id", "Name");
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Sale sale)
        {
            try
            {
                _service.Delete(sale);
               await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
