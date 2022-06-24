using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Task.Data;
using Task.Models;

namespace Task.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext context;

        public CategoryController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Category.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var data = new Category()
                {
                    CategoryName = model.CategoryName,
                    IsActive = model.IsActive,
                    ShowInWebsite = model.ShowInWebsite,
                    ExpiryDate = model.ExpiryDate,
                    CategoryLogo = model.CategoryLogo
                };
                context.Category.Add(data);
                context.SaveChanges();
                TempData["error"] = "Recoed saved!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Please enter data before submit!";
                return View(model);
            }
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var data = context.Category.SingleOrDefault(x => x.CategoryID == id);
            context.Category.Remove(data);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }

        //Edit
        public IActionResult Edit(int id)
        {
            var data = context.Category.SingleOrDefault(x => x.CategoryID == id);
            var result = new Category()
            {
                CategoryName = data.CategoryName,
                IsActive = data.IsActive,
                ShowInWebsite = data.ShowInWebsite,
                ExpiryDate = data.ExpiryDate,
                CategoryLogo = data.CategoryLogo

            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            var emp = new Category()
            {
                CategoryID = model.CategoryID,
                CategoryName = model.CategoryName,
                IsActive = model.IsActive,
                ShowInWebsite = model.ShowInWebsite,
                ExpiryDate = model.ExpiryDate,
                CategoryLogo = model.CategoryLogo

            };
            context.Category.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Edit Sucessfull";
            return RedirectToAction("Index");
        }
    }
}
