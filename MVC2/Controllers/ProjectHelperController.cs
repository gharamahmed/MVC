using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2.Models;
namespace MVC2.Controllers
{
    public class ProjectHelperController : Controller
    {
        private CompanyContext context;
        public ProjectHelperController()
        {
            context = new CompanyContext();
        }
       
        public IActionResult Index()
        {
            List<project>projects=context.Projects.ToList();
            return View(projects);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<department>departments=context.Departments.ToList();
            ViewBag.departments = new SelectList(departments, "Number", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddProject(project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            project Oldproject = context.Projects.SingleOrDefault(i => i.Number == id);
            List <department> Departments = context.Departments.ToList();
            //ViewBag.courses = new SelectList(courses, "Id", "Name");
            ViewBag.departments = new SelectList(Departments, "Number", "Name");
            return View("Edit",Oldproject);
        }
        [HttpPost]
        public IActionResult EditProject(project project)
        {
            var Oldproject = context.Projects.SingleOrDefault(e => e.Number == project.Number);
            Oldproject.Name = project.Name;
            Oldproject.Location = project.Location;
            Oldproject.DepartmentId = project.DepartmentId;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
