using GBCSporting2021_DreamTeam.Models;
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
            var session = new ProgramSession(HttpContext.Session);
            session.RemoveTechnician();
            return RedirectToAction("Get", "TechIncident");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var session = new ProgramSession(HttpContext.Session);
            var tech = session.GetTechnician();
            var model = new TechIncidentViewModel
            {
                TechniciansList = context.Technicians.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Get(TechIncidentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Technician = context.Technicians.Find(model.Technician.TechnicianId);

                var session = new ProgramSession(HttpContext.Session);
                var tech = session.GetTechnician();
                tech.Add(model.Technician);
                session.SetTechnician(tech);
                return RedirectToAction("List", "TechIncident", context.Technicians.Find(model.Id));
            }

            List<Incident> incidents = context.Incident.ToList();
            model.Incident = incidents;
            return View(model);
        }

        [HttpPost]
        public IActionResult List(int id)
        {
            var session = new ProgramSession(HttpContext.Session);
            var tech = session.GetTechnician();
            var model = new TechIncidentViewModel
            {
                Incident = context.Incident.ToList(),
            };

            IQueryable<Incident> query = context.Incident
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Where(i => i.TechnicianId == id);

            model.Incident = query.ToList();
            ViewBag.techName = context.Technicians.Find(id).Name;

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var session = new ProgramSession(HttpContext.Session);
            var tech = session.GetTechnician();
            ViewBag.Action = "Edit";
            var model = new TechIncidentEditViewModel
            {
                Customer = context.Customers.ToList(),
                Product = context.Products.ToList(),
                TechniciansList = context.Technicians.ToList(),
                Incident = context.Incident.Find(id),
                
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TechIncidentEditViewModel model)
        {
            var session = new ProgramSession(HttpContext.Session); 
            var tech = session.GetTechnician();
            if (ModelState.IsValid)
            {
                context.Incident.Update(model.Incident);
                TempData["message"] = $"{model.Incident.Title} was updated.";

                context.SaveChanges();
                return RedirectToAction("Get", "TechIncident");
            }
            else
            {
                ViewBag.Action = "Edit";
                return View(model);
            }
        }
    }
}
