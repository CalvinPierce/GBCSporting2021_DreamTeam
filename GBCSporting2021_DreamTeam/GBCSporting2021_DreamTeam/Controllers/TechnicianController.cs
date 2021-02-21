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
        public IActionResult Index()
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
                    context.Technicians.Add(tech);
                else
                    context.Technicians.Update(tech);
                context.SaveChanges();
                return RedirectToAction("Index", "Technician");
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
        public IActionResult Delete(Technician tech)
        {
            context.Technicians.Remove(tech);
            context.SaveChanges();
            return RedirectToAction("Index", "Technician");
        }
    }
}

