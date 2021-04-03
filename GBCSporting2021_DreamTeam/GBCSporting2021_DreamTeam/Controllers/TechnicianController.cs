using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class TechnicianController : Controller
    {
        private IncidentContext context { get; set; }

        public TechnicianController(IncidentContext ctx)
        {
            context = ctx;
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "Technician");
        }

        [Route("[controller]")]
        public IActionResult List()
        {
            var tech = context.Technicians
                .OrderBy(t => t.Name)
                .ToList();
            return View(tech);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var tech = context.Technicians.Find(id);
            return View(tech);
        }

        [HttpPost]
        public IActionResult Edit(Technician tech)
        {
            if (ModelState.IsValid)
            {
                if (tech.TechnicianId == 0)
                {
                    context.Technicians.Add(tech);
                    TempData["message"] = $"{tech.Name} was added.";
                }
                else
                {
                    context.Technicians.Update(tech);
                    TempData["message"] = $"{tech.Name} was updated.";
                }
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = (tech.TechnicianId == 0) ? "Add" : "Edit";
                return View(tech);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tech = context.Technicians.Find(id);
            return View(tech);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Technician tech)
        {
            TempData["message"] = "Technician successfully deleted.";
            context.Technicians.Remove(tech);
            context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }
    }
}

