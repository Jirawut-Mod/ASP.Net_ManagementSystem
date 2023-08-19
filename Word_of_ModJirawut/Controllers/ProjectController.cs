using Word_of_ModJirawut.Models;
using Microsoft.AspNetCore.Mvc;
using Word_of_ModJirawut.Data;

namespace Word_of_ModJirawut.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ProjectController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable <Project> allProject = _db.Projects;
            return View(allProject);
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

        public IActionResult About()
        {
            return View();
        }
    }
}
