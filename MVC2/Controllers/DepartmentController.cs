using Microsoft.AspNetCore.Mvc;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext db;

        public DepartmentController()
        {
            db = new CompanyContext();
        }
        public IActionResult GetAll()
        {
            List<department> departments = db.Departments.ToList();
            //RedirectToAction("/Project/GetAll");
            return View("GetAll", departments);
        }
        public IActionResult AddDepartment()
        {
            //employee emp = db.Employees.Where(e => e.SSN == id).Single();
            return View("AddDepartment",db.Employees.ToList());
        }

        public IActionResult Add(department dep)
        {
            db.Departments.Add(dep);
            db.SaveChanges();
            //TempData["msg"] = "You Add one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(int id)
        {
            department dep = db.Departments.Where(e => e.Number==id).Single();
            return View("Edit", dep);
        }
        public IActionResult Delete(int id)
        {
            List< project> projects = db.Projects.Where(e => e.Department.Number == id).ToList();
            foreach(project project in projects)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
            }
         
            department dep = db.Departments.Where(e => e.Number == id).Single();
            db.Departments.Remove(dep);
            db.SaveChanges();
            //TempData["msg"] = "You Delete one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(department dep)
        {
            var Olddep = db.Departments.SingleOrDefault(e=>e.Number==dep.Number);
            Olddep.Name = dep.Name;
            Olddep.startdate = dep.startdate;
            Olddep.employeeSSN = dep.employeeSSN;
            db.SaveChanges();
            //TempData["msg"] = "You Update one Dependent";
            return RedirectToAction("GetAll");
        }
    }
}
