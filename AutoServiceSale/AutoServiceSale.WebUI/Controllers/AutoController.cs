using AutoServiceSale.Entities.Concrete;
using AutoServiceSale.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceSale.WebUI.Controllers
{
    public class AutoController : Controller
    {
        private readonly IAutoService  _service;
        private readonly IService<Customer> _serviceCustomer;

        public AutoController(IAutoService service, IService<Customer> serviceCustomer)
        {
            _service = service;
            _serviceCustomer = serviceCustomer;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model= await _service.FindtCustomAutoAsync(id);
            return View(model);
        }

        public async Task<IActionResult> SaleList()
        {
            var model = await _service.GetAllCustomAutoAsync(x => x.IsOnSale==true);
            return View(model);
        }

        public async Task<IActionResult> Search(string q)
        {
            var model = await _service.GetAllCustomAutoAsync(x => x.IsOnSale == true && x.Brand.Name.Contains(q)||x.BanType.Contains(q) || x.Model.Contains(q));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GetInfo(Customer customer)
        {
            try
            {
                await _serviceCustomer.AddAsync(customer);
                await _service.SaveAsync();
                return Redirect("/Auto/Index/"+customer.AutoId);
            }
            catch (Exception)
            {

                throw;
            } 
            return View();
        }
    }
}
