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

        [Route("[controller]/{filter?}")]
        public IActionResult List(string filter = "all")
        {
            var model = new IncidentViewModel
            {
                Filter = filter,
                Incident = context.Incident.ToList()
            };

            IQueryable<Incident> query = context.Incident
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician);

            if (filter == "all")
                query = query.Where(
                    i => i.IncidentId != null);
            if (filter == "unassigned")
                query = query.Where(
                    i => i.TechnicianId == null);
            if (filter == "open")
                query = query.Where(
                    i => i.Close == null);

            model.Incident = query.ToList();
            model.Filter = filter;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            var model = new IncidentEditViewModel
            {
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                Technicians = context.Technicians.ToList(),
                Incident = new Incident(),
                Action = "Add"
            };
            return View("Edit", model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var model = new IncidentEditViewModel
            {
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                Technicians = context.Technicians.ToList(),
                Incident = context.Incident.Find(id),
                Action = "Edit"
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IncidentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Incident.IncidentId == 0)
                {
                    context.Incident.Add(model.Incident);
                    TempData["message"] = $"{model.Incident.Title} was added.";
                }
                else
                {
                    context.Incident.Update(model.Incident);
                    TempData["message"] = $"{model.Incident.Title} was updated.";
                }
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Action = (model.Incident.IncidentId == 0) ? "Add" : "Edit";
                model.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
                model.Products = context.Products.OrderBy(p => p.Name).ToList();
                model.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
                return View(model);
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
