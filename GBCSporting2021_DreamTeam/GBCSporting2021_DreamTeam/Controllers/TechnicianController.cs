using GBCSporting2021_DreamTeam.DataAccess;
using GBCSporting2021_DreamTeam.Models;
using GBCSporting2021_DreamTeam.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class TechnicianController : Controller
    {
        private Repository<Technician> repository;

        public TechnicianController(IncidentContext ctx)
        {
            repository = new Repository<Technician>(ctx);
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "Technician");
        }

        [Route("[controller]")]
        public IActionResult List()
        {
            var technician = repository.Get(orderBy: t => t.OrderBy(q => q.Name)).ToList();
            return View(technician);
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
            var technician = repository.Get(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianId == 0)
                {
                    repository.Insert(technician);
                    TempData["message"] = $"{technician.Name} was added.";
                }
                else
                {
                    repository.Update(technician);
                    TempData["message"] = $"{technician.Name} was updated.";
                }
                repository.Save();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = repository.Get(id);
            return View(technician);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Technician technician)
        {
            TempData["message"] = "Technician successfully deleted.";
            repository.Delete(technician);
            repository.Save();
            return RedirectToAction("List", "Technician");
        }
    }
}

