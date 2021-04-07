using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class RegistrationController : Controller
    {
        private IncidentContext context { get; set; }

        public RegistrationController(IncidentContext ctx)
        {
            context = ctx;
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("Get", "Registration");
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var model = new RegistrationViewModel
            {
                Customer = context.Customers.Find(id),
                Registrations = context.Registration
                .Include(r => r.Product)
                .Where(r => r.CustomerId == id)
                .ToList(),
                Products = context.Products.ToList(),
            };
            HttpContext.Session.SetInt32("customerId", id);
            return View(model);
        }

        [HttpPost]
        public IActionResult List(RegistrationViewModel model)
        {
            int? id = HttpContext.Session.GetInt32("customerId");
            if (ModelState.IsValid)
            {
                Registration reg = new Registration
                {
                    CustomerId = (int) id,
                    ProductId = model.productId
                };
                context.Registration.Add(reg);
                context.SaveChanges(); 
                TempData["message"] = "Registration added";
            }
            model = new RegistrationViewModel
            {
                Customer = context.Customers.Find(id),
                Registrations = context.Registration
                .Include(r => r.Product)
                .Where(r => r.CustomerId == id)
                .ToList(),
                Products = context.Products.ToList(),
            };
            HttpContext.Session.SetInt32("customerId", model.Customer.CustomerId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Registration.Find(id);
            return View(incident);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Registration reg)
        {
            TempData["message"] = "Registration successfully deleted.";
            context.Registration.Remove(reg);
            context.SaveChanges();
            int? id = HttpContext.Session.GetInt32("customerId");
            return RedirectToAction("List", "Registration", new { id = id });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = new RegistrationViewModel
            {
                Customers = context.Customers.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Get(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List", "Registration", new { id = model.customerId });
            }
            model.Customers = context.Customers.ToList();
            return View(model);
        }

    }
}
