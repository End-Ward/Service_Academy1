using Microsoft.AspNetCore.Mvc;
using Service_Academy1.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ServiceAcademy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ILogger<AdminController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Dashboard()
        {
            ViewData["ActivePage"] = "Dashboard";
            return View();
        }

        public IActionResult Analytics()
        {
            ViewData["ActivePage"] = "Analytics";
            return View();
        }

        public async Task<IActionResult> ManageAccount()
        {
            ViewData["ActivePage"] = "ManageAccount";

            // Fetch the list of users
            var model = new ManageAccountViewModel
            {
                Users = await _userManager.Users.ToListAsync()
            };

            return View(model);
        }

        public IActionResult ManageProgram()
        {
            ViewData["ActivePage"] = "ManageProgram";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
