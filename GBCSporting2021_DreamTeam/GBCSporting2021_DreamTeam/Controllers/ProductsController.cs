using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class ProductsController : Controller
    {
        private IncidentContext context { get; set; }

        public ProductsController(IncidentContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var products = context.Products
                .OrderBy(p => p.ReleaseDate)
                .ToList();
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
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                    context.Products.Add(product);
                else
                    context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index", "Products");
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
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Products product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}

