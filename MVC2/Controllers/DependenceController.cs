using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MVC2.Models;

namespace MVCDAY2.Controllers
{
  
    public class DependenceController : Controller
    {
        CompanyContext db;
        public DependenceController() {
            db = new CompanyContext();
        }
        public IActionResult GetAll()
        {
            List<dependent> dependents= db.Dependents.Where(e=>e.ESSN==HttpContext.Session.GetInt32("SSN")).ToList();
            return View("GetAll", dependents);
        }
        public IActionResult AddDependence(int id)
        {
            //employee emp = db.Employees.Where(e => e.SSN == id).Single();
            return View("AddDependence");
        }

        public IActionResult Add(dependent dep)
        {
            db.Dependents.Add(dep);
            db.SaveChanges();
            TempData["msg"] = "You Add one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(string id)
        {
            dependent dep = db.Dependents.Where(e => e.ESSN ==(int)HttpContext.Session.GetInt32("SSN")&&e.Name==id).Single();
            return View("Edit", dep);
        }
        public IActionResult Delete(string id)
        {
            dependent dep = db.Dependents.Where(e => e.ESSN ==(int)HttpContext.Session.GetInt32("SSN") && e.Name == id).Single(); ;
            db.Dependents.Remove(dep);
            db.SaveChanges();
            TempData["msg"] = "You Delete one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(dependent dep)
        {
            var Olddep = db.Dependents.SingleOrDefault(e => e.ESSN ==(int)HttpContext.Session.GetInt32("SSN") && e.Name == dep.Name);
            //Olddep.Name = dep.Name;
            Olddep.Birthdate = dep.Birthdate;
            Olddep.Relationship = dep.Relationship;
            Olddep.ESSN = HttpContext.Session.GetInt32("SSN");
            db.SaveChanges();
            TempData["msg"] = "You Update one Dependent";
            return RedirectToAction("GetAll");
        }
    }

}
