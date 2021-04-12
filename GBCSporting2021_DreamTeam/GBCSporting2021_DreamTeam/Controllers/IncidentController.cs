using GBCSporting2021_DreamTeam.DataAccess;
using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class IncidentController : Controller
    {
        private UnitOfWork unitOfWork;

        public IncidentController(IncidentContext ctx)
        {
            unitOfWork = new UnitOfWork(ctx);
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "Incident");
        }

        [Route("[controller]/{filter?}")]
        public IActionResult List(string filter = "all")
        {
            var incidents = unitOfWork.IncidentRepository.Get(includeProperties: "Product,Customer,Technician");

            if (filter == "unassigned")
            {
                incidents = incidents.Where(i => i.TechnicianId == null);
            }
            else if (filter == "open")
            {
                incidents = incidents.Where(i => i.Close == null);
            }

            var model = new IncidentViewModel
            {
                Filter = filter,
                Incident = incidents.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            string action = "Add";
            List<Customer> customers = unitOfWork.CustomerRepository.Get(orderBy: c => c.OrderBy(q => q.LastName)).ToList();
            List<Products> products = unitOfWork.ProductRepository.Get(orderBy: p => p.OrderBy(q => q.Name)).ToList();
            List<Technician> technicians = unitOfWork.TechnicianRepository.Get(orderBy: t => t.OrderBy(q => q.Name)).ToList();

            IncidentEditViewModel model = new IncidentEditViewModel
            {
                Customers = customers,
                Products = products,
                Technicians = technicians,
                Incident = new Incident { Open = DateTime.Now },
                Action = action
            };
            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var incident = unitOfWork.IncidentRepository.Get(includeProperties: "Product,Customer,Technician").FirstOrDefault(i => i.IncidentId == id);

            List<Customer> customers = unitOfWork.CustomerRepository.Get(orderBy: c => c.OrderBy(q => q.LastName)).ToList();
            List<Products> products = unitOfWork.ProductRepository.Get(orderBy: p => p.OrderBy(q => q.Name)).ToList();
            List<Technician> technicians = unitOfWork.TechnicianRepository.Get(orderBy: t => t.OrderBy(q => q.Name)).ToList();

            IncidentEditViewModel model = new IncidentEditViewModel
            {
                Customers = customers,
                Products = products,
                Technicians = technicians,
                Incident = incident,
                Action = "Edit"
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IncidentEditViewModel model)
        {
            string action = model.Action;

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    unitOfWork.IncidentRepository.Insert(model.Incident);
                    TempData["message"] = $"{model.Incident.Title} was added.";
                }
                else
                {
                    unitOfWork.IncidentRepository.Update(model.Incident);
                    TempData["message"] = $"{model.Incident.Title} was updated.";
                }
                unitOfWork.Save();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Action = (model.Incident.IncidentId == 0) ? "Add" : "Edit";
                model.Customers = unitOfWork.CustomerRepository.Get(orderBy: c => c.OrderBy(q => q.LastName)).ToList();
                model.Products = unitOfWork.ProductRepository.Get(orderBy: p => p.OrderBy(q => q.Name)).ToList();
                model.Technicians = unitOfWork.TechnicianRepository.Get(orderBy: t => t.OrderBy(q => q.Name)).ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = unitOfWork.IncidentRepository.Get(id);
            IncidentEditViewModel model = new IncidentEditViewModel { Incident = incident, Action = "Delete" };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete(IncidentEditViewModel model)
        {
            TempData["message"] = "Incident successfully deleted.";
            unitOfWork.IncidentRepository.Delete(model.Incident);
            unitOfWork.Save();
            return RedirectToAction("List", "Incident");
        }
    }
}
