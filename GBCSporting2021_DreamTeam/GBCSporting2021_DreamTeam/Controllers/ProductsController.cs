using GBCSporting2021_DreamTeam.DataAccess;
using GBCSporting2021_DreamTeam.Models;
using GBCSporting2021_DreamTeam.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class ProductsController : Controller
    {
        private Repository<Products> repository;

        public ProductsController(IncidentContext ctx)
        {
            repository = new Repository<Products>(ctx);
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        [Route("[controller]")]
        public IActionResult List()
        {
            var products = repository.Get(orderBy: p => p.OrderBy(q => q.ReleaseDate)).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Products());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = repository.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    repository.Insert(product);
                    TempData["message"] = $"{product.Name} was added.";
                }
                else
                {
                    repository.Update(product);
                    TempData["message"] = $"{product.Name} was updated.";
                }
                repository.Save();
                return RedirectToAction("List", "Products");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = repository.Get(id);
            return View(product);

        }

        [HttpPost]
        public RedirectToActionResult Delete(Products product)
        {
            string name = product.Name;
            TempData["message"] = "Product successfully deleted.";
            repository.Delete(product);
            repository.Save();
            return RedirectToAction("List", "Products");
        }
    }
}

