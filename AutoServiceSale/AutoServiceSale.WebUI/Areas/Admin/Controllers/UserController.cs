using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoServiceSale.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class UserController : Controller
    {

        private readonly IService<User> _service;
        private readonly IService<Role> _serviceForRole;

        public UserController(IService<User> service, IService<Role> serviceForRole)
        {
            _service = service;
            _serviceForRole = serviceForRole;
        }
        // GET: UserController
        public async Task <ActionResult> Index()
        {
            var model = await _service.GetAllAsync(includeprops: "Role");
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: UserController/Create
        public  ActionResult Create(User user)
        {
            ViewBag.RoleId = new SelectList( _serviceForRole.GetAll(),"Id","Name");
           
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(User user)
        {
            
            try
            {
                await _service.AddAsync(user);
                await _service.SaveAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Unexpected error");
            }
            ViewBag.RoleId = new SelectList(await _serviceForRole.GetAllAsync(), "Id", "Name");
            return View(user);
           
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
          var model=  await _service.FindAsync(id);
            ViewBag.RoleId = new SelectList(await _serviceForRole.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(user);
                  await  _service.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Unexpected error");
                }

            }
            ViewBag.RoleId = new SelectList(await _serviceForRole.GetAllAsync(), "Id", "Name");
            return View(user);
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
           _service.Delete(user);
            _service.Save()
;            return RedirectToAction("Index");
        }
    }
}
