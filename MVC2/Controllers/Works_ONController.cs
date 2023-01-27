using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using System;

namespace MVC2.Controllers
{
    public class Works_ONController : Controller
    {
        CompanyContext db;
        public Works_ONController()
        {
            db = new CompanyContext();
        }
        public IActionResult GetAll(int id)
        {
            List<department> departments = db.Departments.Where(e=>e.employeeSSN==id).ToList();
            ViewBag.Departments = departments;
           ViewBag.Projects=db.Projects.ToList();
            ViewBag.WorksOn = db.Works.ToList();
            ViewBag.WorksOn = db.Works.ToList();
            //RedirectToAction("/Project/GetAll");
            return View();
        }
        public IActionResult AddEmployee()
        {
            ViewBag.Employees=db.Employees.ToList();
            ViewBag.Projects = db.Projects.ToList();
            return View();
        }
        public IActionResult Add(works_on works,int[]pnum )
        {
           
            foreach (var work in pnum)
            {
                works_on works_ = new works_on();
                works_.ESSN = works.ESSN;
                works_.Hours = works.Hours;
                works_.Pnum = work;
                db.Works.Add(works_);
                db.SaveChanges();
            }
    
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(int id,int pnum)
        {
            //department dep = db.Departments.Where(e => e.Number == id).Single();
            works_on works = db.Works.Where(e => e.Pnum == pnum &&e.ESSN==id).Single();
            return View("Edit", works);
        }
        public IActionResult Delete(int id, int pnum)
        {
            works_on works = db.Works.Where(e => e.Pnum == pnum && e.ESSN == id).Single();
            db.Works.Remove(works);
            db.SaveChanges();
            //TempData["msg"] = "You Delete one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(works_on works)
        {
            works_on Oldworks = db.Works.Where(e => e.Pnum == works.Pnum && e.ESSN == works.ESSN).Single();
            Oldworks.Hours = works.Hours;
            db.SaveChanges();
            //TempData["msg"] = "You Update one Dependent";
            return RedirectToAction("GetAll");
        }
    }
}
