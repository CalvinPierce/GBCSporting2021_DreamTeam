using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Mvc;
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

        
        public IActionResult Get(int id)
        {
            ViewBag.Technician = context.Technicians.OrderBy(t => t.Name).ToList();
            var techIncident = context.Incident.Find(id);
            return View(techIncident);
            //return RedirectToAction("List", "TechIncident");
        }

        
        public IActionResult List(int techId, string filter = "")
        {

            var incident = context.Incident
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .Where(i => i.TechnicianId == techId)
                .OrderBy(i => i.Open)
                .ToList();

            return View(incident);
        }
    }
}
