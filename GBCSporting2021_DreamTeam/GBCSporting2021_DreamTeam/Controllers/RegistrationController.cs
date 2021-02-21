using GBCSporting2021_DreamTeam.Models;
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
        public IActionResult Index()
        {
            var reg = context.Registration
                .Include(r => r.Product)
                .Include(r => r.Customer)
                .OrderBy(r => r.RegistrationDate)
                .ToList();
            return View(reg);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customer = context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
            return View("Edit", new Registration());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customer = context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
            var reg = context.Registration.Find(id);
            return View(reg);
        }

        [HttpPost]
        public IActionResult Edit(Registration reg)
        {
            if (ModelState.IsValid)
            {
                if (reg.RegistrationId == 0)
                    context.Registration.Add(reg);
                else
                    context.Registration.Update(reg);
                context.SaveChanges();
                return RedirectToAction("Index", "Registration");
            }
            else
            {
                ViewBag.Action = (reg.RegistrationId == 0) ? "Add" : "Edit";
                ViewBag.Customer = context.Customers.OrderBy(c => c.LastName).ToList();
                ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
                return View(reg);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Registration.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Registration reg)
        {
            context.Registration.Remove(reg);
            context.SaveChanges();
            return RedirectToAction("Index", "Registration");
        }
    }
}
