using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2.Models;
using MVC2.ViewsModels;

namespace MVC2.Controllers
{
    public class ValidateProjectController : Controller
    {
        CompanyContext context;
        public ValidateProjectController()
        {
            context = new CompanyContext();
        }
        public IActionResult Index()
        {
            List<project> projects = context.Projects.ToList();   
            return View(projects);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<department> departments = context.Departments.ToList();
            ViewBag.departments = new SelectList(departments, "Number", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProjectVM project)
        {

            if (ModelState.GetFieldValidationState("Name") == ModelValidationState.Valid
                && ModelState.GetFieldValidationState("Location") == ModelValidationState.Valid &&
                !(project.Location.Contains("cairo") || project.Location.Contains("alex") || project.Location.Contains("giza")))
            {
                ModelState.AddModelError("Location", "Location must be Cairo or Alex or Giza");
            }
            if (ModelState.IsValid)
            {
                project newProject = new project()
                {
                    Name = project.Name,
                    Location = project.Location,
                    DepartmentId= project.DepartmentId
                };
                context.Projects.Add(newProject);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
