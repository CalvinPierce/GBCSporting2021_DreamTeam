using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class IncidentController : Controller
    {
        private IncidentContext context { get; set; }

        public IncidentController(IncidentContext ctx)
        {
            context = ctx;
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "Incident");
        }

        [Route("[controller]")]
        public IActionResult List()
        {
            var incident = context.Incident
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .OrderBy(i => i.Open)
                .ToList();
            return View(incident);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customer = context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technician = context.Technicians.OrderBy(t => t.Name).ToList();
            return View("Edit", new Incident());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customer = context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technician = context.Technicians.OrderBy(t => t.Name).ToList();
            var incident = context.Incident.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentId == 0)
                {
                    context.Incident.Add(incident);
                    TempData["message"] = $"{incident.Title} was added.";
                }
                else
                {
                    context.Incident.Update(incident);
                    TempData["message"] = $"{incident.Title} was updated.";
                }
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Action = (incident.IncidentId == 0) ? "Add" : "Edit";
                ViewBag.Customer = context.Customers.OrderBy(c => c.LastName).ToList();
                ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
                ViewBag.Technician = context.Technicians.OrderBy(t => t.Name).ToList();
                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incident.Find(id);
            return View(incident);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Incident incident)
        {
            TempData["message"] = "Incident successfully deleted.";
            context.Incident.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List", "Incident");
        }
    }
}
