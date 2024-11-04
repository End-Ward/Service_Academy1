using Microsoft.AspNetCore.Mvc;
using Service_Academy1.Models;
using System.Diagnostics;

namespace ServiceAcademy.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AssessmentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method for Home.cshtml
        public IActionResult Assessment()
        {
            ViewData["ActivePage"] = "Assessment";
            return View();
        }
      
    }
}
