using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MVC2.Controllers
{
    public class CustomAttributeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult validateLocation(string Location)
        {
            if (Location.Contains("cairo") || Location.Contains("alex")|| Location.Contains("giza"))
            {
                return Json(true);
            }
            return Json(true);
        }
    }
}
