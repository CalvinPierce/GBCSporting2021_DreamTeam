using GBCSporting2021_DreamTeam.Models;
using GBCSporting2021_DreamTeam.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class CustomerController : Controller
    {
        private UnitOfWork unitOfWork;

        public CustomerController(IncidentContext ctx)
        {
            unitOfWork = new UnitOfWork(ctx);
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "Customer");
        }

        [Route("[controller]")]
        public IActionResult List()
        {
            var customer = unitOfWork.CustomerRepository.Get(includeProperties: "Country").ToList();
            return View(customer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Country = unitOfWork.CountryRepository.Get().ToList();
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = unitOfWork.CountryRepository.Get().ToList();
            var customer = unitOfWork.CustomerRepository.Get(includeProperties: "Country").FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string key = nameof(Customer.Email);

            if (ModelState.GetValidationState(key) == ModelValidationState.Valid)
            {
                var customerCheck = unitOfWork.CustomerRepository.Get(c => c.Email == customer.Email && c.CustomerId != customer.CustomerId && c.Email != null).FirstOrDefault();
                if (customerCheck != null)
                {
                    ModelState.AddModelError(key, "Email already in use!");
                }
            }

            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    unitOfWork.CustomerRepository.Insert(customer);
                    TempData["message"] = $"{customer.FullName} was added.";
                }
                else
                {
                    unitOfWork.CustomerRepository.Update(customer);
                    TempData["message"] = $"{customer.FullName} was updated.";
                }
                unitOfWork.Save();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                ViewBag.Countries = unitOfWork.CountryRepository.Get().ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = unitOfWork.CustomerRepository.Get(id);
            return View(customer);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Customer customer)
        {
            TempData["message"] = "Customer successfully deleted.";
            unitOfWork.CustomerRepository.Delete(customer);
            unitOfWork.Save();
            return RedirectToAction("List", "Customer");
        }
    }
}

