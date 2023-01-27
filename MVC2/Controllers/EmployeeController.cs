using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MVC2.Models;

namespace MVCDAY2.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext db;
        public EmployeeController()
        {
            db = new CompanyContext();
        }
        public IActionResult AddEmployee()
        {
            //View("AddEmployee", db.Projects.ToList());
            return View("AddEmployee",db.Employees.ToList());
        }
        public IActionResult GetAll()
        {
            List<employee> employees =db.Employees.ToList() ;
            return View("GetAll", employees);
        }
        public IActionResult Edit(int id)
        {
            employee emp = db.Employees.Where(e=>e.SSN==id).Single();
            return View("Edit", emp);
        }
        public IActionResult Delete(int id)
        {
            employee emp = db.Employees.Where(e => e.SSN == id).Single();
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(employee emp)
        {
            var Oldemp = db.Employees.SingleOrDefault(e => e.SSN == emp.SSN);
             Oldemp.Fname = emp.Fname; 
             Oldemp.Lname = emp.Lname;
             Oldemp.Minit = emp.Minit; 
             Oldemp.Salary = emp.Salary; 
             Oldemp.Address = emp.Address; 
            Oldemp.Bdate= emp.Bdate;
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Add(employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return  RedirectToAction("GetAll");
        }

        public IActionResult Login (){
            return View("Login");
            
        }
        public IActionResult Check(employee emp) {
            employee e = db.Employees.Where(e => e.SSN == emp.SSN && e.Fname == emp.Fname).Single();
            if (e != null)
            {
                HttpContext.Session.SetInt32("SSN", e.SSN);
               // return RedirectToAction("/Home/Index");
            }
            return RedirectToAction("Profile");
        }
        public IActionResult Profile()
        {
           var emp = db.Employees.Where(e => e.SSN == HttpContext.Session.GetInt32("SSN")).Select(e => new {e.SSN,e.Fname,e.Minit,e.Lname,e.Address,e.Bdate,e.Gender,e.Salary,DepManager=e.Department.employeeSSN}).Single();
            return View("Profile", emp);

        }
    }
}
