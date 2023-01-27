using Microsoft.AspNetCore.Mvc;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class ProjectController : Controller
    {
        CompanyContext db;
        public ProjectController()
        {
            db= new CompanyContext();
        }
        public IActionResult GetAll()
        {
            List<project> projects = db.Projects.ToList();
            return View("GetAll", projects);
        }
        public IActionResult AddProject()
        {
            ///department department = db.Departments.Where(e => e.Number == id).SingleOrDefault();
            return View("AddProject",db.Departments.ToList());
        }
        public IActionResult Add(project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            //TempData["msg"] = "You Add one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(int id)
        {
            project project = db.Projects.Where(e =>e.Number==id).Single();
            return View("Edit", project);
        }
        public IActionResult Delete(int id)
        {
            project project = db.Projects.Where(e => e.Number == id).Single();
            db.Projects.Remove(project);
            db.SaveChanges();
            //TempData["msg"] = "You Delete one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(project project)
        {
            var Oldproject = db.Projects.SingleOrDefault(e => e.Number == project.Number);
            Oldproject.Name = project.Name;
            Oldproject.Location= project.Location;
            Oldproject.DepartmentId=project.DepartmentId;
            db.SaveChanges();
            //TempData["msg"] = "You Update one Dependent";
            return RedirectToAction("GetAll");
        }
    }
}
