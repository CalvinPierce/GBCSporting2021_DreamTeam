using GBCSporting2021_DreamTeam.DataAccess;
using GBCSporting2021_DreamTeam.Models;
using GBCSporting2021_DreamTeam.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class TechIncidentController : Controller
    {
        private UnitOfWork unitOfWork;

        public TechIncidentController(IncidentContext ctx)
        {
            unitOfWork = new UnitOfWork(ctx);
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "TechIncident");
        }

        public IActionResult List()
        {
            var session = new TechnicianSession(HttpContext.Session);
            var tid = session.GetId();
            if (tid == -1)
            {
                return RedirectToAction("Get");
            }

            var incidents = unitOfWork.IncidentRepository.Get(includeProperties: "Technician,Customer,Product").Where(i => i.TechnicianId == tid).
                Where(i => i.Close == null).ToList();
            ViewBag.Name = unitOfWork.TechnicianRepository.Get(tid).Name;
            return View(incidents);
        }

        public IActionResult Get()
        {
            var technicians = unitOfWork.TechnicianRepository.Get(orderBy: t => t.OrderBy(q => q.Name)).ToList();
            return View(technicians);
        }

        [HttpPost]
        public IActionResult Set(int id)
        {
            var session = new TechnicianSession(HttpContext.Session);
            session.SetId(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var incident = unitOfWork.IncidentRepository.Get(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.IncidentRepository.Update(incident);
                TempData["message"] = $"{incident.Title} was updated.";
                unitOfWork.Save();
                return RedirectToAction("List", "TechIncident");
            }
            else
            {
                return View(incident);
            }
        }
    }
}
