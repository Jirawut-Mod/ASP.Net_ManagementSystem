using Word_of_ModJirawut.Models;
using Microsoft.AspNetCore.Mvc;
using Word_of_ModJirawut.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Word_of_ModJirawut.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDBContext _db;
        private object _dbContext;

        public ProjectController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? searchIdProduct)
        {
            IEnumerable<Project> projects = _db.Projects;

            if (searchIdProduct.HasValue)
            {
                projects = projects.Where(p => p.IdProduct == searchIdProduct.Value);
            }

            ViewBag.SearchIdProduct = searchIdProduct;

            return View(projects.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project obj)
        {
            if (ModelState.IsValid)
            {
                // เช็คว่าช่อง Note มีค่าว่างหรือไม่
                if (string.IsNullOrWhiteSpace(obj.Note))
                {
                    obj.Note = null; // กำหนดให้เป็น null
                }

                _db.Projects.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Projects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project obj)
        {
            if (ModelState.IsValid)
            {
                _db.Projects.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Projects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Projects.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...

            app.UseStaticFiles(); // ตรวจสอบว่ามีบรรทัดนี้ในการเปิดใช้งาน Static Files
        }

        public IActionResult About()
        {
            
            return View();
        }

        

        public IActionResult Graph()
        {
            var products = _db.Projects.GroupBy(p => p.IdProduct)
                                       .Select(group => new { IdProduct = group.Key, TotalPrice = group.Sum(p => p.Price) })
                                       .ToList();

            ViewBag.Products = products;

            return View();
        }



    }
}
