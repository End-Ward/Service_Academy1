using Microsoft.AspNetCore.Mvc;
using Service_Academy1.Models;
using System.Diagnostics;

namespace ServiceAcademy.Controllers
{
    public class ProgramCreateController : Controller
    {
        private readonly ILogger<ProgramCreateController> _logger;

        public ProgramCreateController(ILogger<ProgramCreateController> logger)
        {
            _logger = logger;
        }

        public IActionResult ProgramCreation()
        {
            return View();
        }
        public IActionResult Home()
        {
            ViewData["ActivePage"] = "Home";
            return View();
        }

        public IActionResult ProgramCatalog()
        {
            ViewData["ActivePage"] = "ProgramCatalog";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["ActivePage"] = "Contact";
            return View();
        }

        public IActionResult Faqs()
        {
            ViewData["ActivePage"] = "Faqs";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
