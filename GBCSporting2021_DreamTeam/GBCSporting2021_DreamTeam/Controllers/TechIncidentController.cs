using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class TechIncidentController : Controller
    {
        private IncidentContext context { get; set; }

        public TechIncidentController(IncidentContext ctx)
        {
            context = ctx;
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("Get", "TechIncident");
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var incident = context.Incident.Find(id);
            ViewBag.Technician = context.Technicians.OrderBy(t => t.Name).ToList();
            return View(incident);
        }

        [HttpPost]
        public RedirectToActionResult Get(Incident incident)
        {
            var session = new ProgramSession(HttpContext.Session);
            session.SetTechnician(incident.Technician);
            TempData["techName"] = incident.Technician.Name;
            return RedirectToAction("List", "TechIncident");

        }
        [HttpPost]
        public IActionResult List(Incident inc)
        {
            var incident = context.Incident
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Where(i => i.TechnicianId == inc.TechnicianId)
                .ToList();
            return View(incident);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var session = new ProgramSession(HttpContext.Session);
            var tech = session.GetTechnician();
            ViewBag.Action = "Edit";
            var incident = context.Incident.Find(id);
            ViewBag.Technician = context.Technicians.OrderBy(t => t.Name).ToList();
            ViewBag.Customer = context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Product = context.Products.OrderBy(p => p.Name).ToList();
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            var session = new ProgramSession(HttpContext.Session);
            var tech = session.GetTechnician();
            if (ModelState.IsValid)
            {
                context.Incident.Update(incident);
                TempData["message"] = $"{incident.Title} was updated.";

                context.SaveChanges();
                return RedirectToAction("Get", "TechIncident");
            }
            else
            {
                ViewBag.Action = "Edit";
                return View(incident);
            }
        }
    }
}
