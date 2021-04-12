using GBCSporting2021_DreamTeam.DataAccess;
using GBCSporting2021_DreamTeam.Models;
using GBCSporting2021_DreamTeam.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class RegistrationController : Controller
    {
        private UnitOfWork unitOfWork;

        public RegistrationController(IncidentContext ctx)
        {
            unitOfWork = new UnitOfWork(ctx);
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "Registration");
        }

        public IActionResult List()
        {
            var session = new RegistrationSession(HttpContext.Session);
            var cid = session.GetId();
            if (cid == -1)
            {
                return RedirectToAction("Get");
            }

            var customer = unitOfWork.CustomerRepository.Get(cid);
            var products = unitOfWork.ProductRepository.Get(orderBy: p => p.OrderBy(q => q.Name)).ToList();
            var registrations = unitOfWork.RegistrationRepository.Get().Where(r => r.CustomerId == cid).ToList();

            var viewModel = new RegistrationViewModel { Customer = customer, Products = products, Registrations = registrations };

            return View(viewModel);
        }

        public IActionResult Get()
        {
            ViewBag.Customers = unitOfWork.CustomerRepository.Get(orderBy: c => c.OrderBy(q => q.LastName)).ToList();
            return View();
        }

        public IActionResult Set(string id)
        {
            Int32.TryParse(id, out int cid);
            var session = new RegistrationSession(HttpContext.Session);
            session.SetId(cid);
            return RedirectToAction("List");
        }

        public IActionResult AddRegistration(int id)
        {
            var session = new RegistrationSession(HttpContext.Session);
            var cid = session.GetId();
            string name = unitOfWork.ProductRepository.Get(id).Name;

            if (ModelState.IsValid)
            {
                // check if product is already registered
                if (unitOfWork.RegistrationRepository.Get().Where(r => r.ProductId == id).Where(r => r.CustomerId == cid).ToList().Count() != 0)
                {
                    TempData["message"] = name + " already registered";
                }
                else
                {
                    unitOfWork.RegistrationRepository.Insert(new Registration { CustomerId = cid, ProductId = id });
                    unitOfWork.RegistrationRepository.Save();
                    TempData["message"] = name + " Added!";
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var registration = unitOfWork.RegistrationRepository.Get(id);
            return View(registration);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Registration reg)
        {
            TempData["message"] = "Registration successfully deleted.";
            unitOfWork.RegistrationRepository.Delete(reg);
            unitOfWork.Save();
            int? id = HttpContext.Session.GetInt32("customerId");
            return RedirectToAction("List", "Registration", new { id = id });
        }

    }
}
