using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class DepartmentHelperController : Controller
    {
        private CompanyContext context;

        public DepartmentHelperController()
        {
            context= new CompanyContext();
        }
        public IActionResult Index()
        {
            List<department>departments=context.Departments.ToList();
            return View(departments);
        }
        public IActionResult Add()
        {
            List<employee> employees = context.Employees.ToList();
            ViewBag.Employees = new SelectList(employees, "SSN", "Fname");
            return View();
        }
        public IActionResult AddDepartment(department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            department OldDepartment = context.Departments.SingleOrDefault(i => i.Number == id);
            List<employee> Employees = context.Employees.ToList();
            //ViewBag.courses = new SelectList(courses, "Id", "Name");
            ViewBag.Employees = new SelectList(Employees, "SSN", "Fname");
            return View("Edit", OldDepartment);
        }

        public IActionResult EditDepartment(department department)
        {
            var OldDepartment = context.Departments.SingleOrDefault(e => e.Number == department.Number);
            OldDepartment.Name= department.Name;
            OldDepartment.startdate= department.startdate;
            OldDepartment.employeeSSN= department.employeeSSN;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
