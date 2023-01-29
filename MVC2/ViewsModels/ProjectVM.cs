using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.ViewsModels
{
    public class ProjectVM
    {
        public int Number { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be more or equal 5 letters")]
        
        public string Name { get; set; }
        [Display(Name = "Project Location")]
        [Required(ErrorMessage = "Location is required")]
        [Remote("validateLocation", "CustomAttribute", ErrorMessage ="Location must be Cairo or Alex or Giza")]
        public string Location { get; set; }
        [Compare("Location")]
        public string confirmLocation{ get; set; }

        //public department? Department { get; set; }
        //[ForeignKey("Department")]
        public int? DepartmentId { get; set; }
    }
}
