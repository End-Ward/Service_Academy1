using Microsoft.AspNetCore.Mvc;
using Service_Academy1.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

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

        // Dashboard action
        public IActionResult Dashboard()
        {
            ViewData["ActivePage"] = "Dashboard";
            return View();
        }

        // Analytics action
        public IActionResult Analytics()
        {
            ViewData["ActivePage"] = "Analytics";
            return View();
        }

        // ManageAccount action: Get users and display in the view
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

        // CreateAccount action: Handles the creation of new users
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FullName = model.Username // Assuming FullName is the same as Username
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    TempData["SuccessMessage"] = "Account created successfully!";
                    return RedirectToAction("ManageAccount");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // Fetch the list of users to be passed into the view, along with the CreateAccount form data
            var manageAccountViewModel = new ManageAccountViewModel
            {
                Users = await _userManager.Users.ToListAsync(),
                CreateAccountForm = model // Include the form data so it can be displayed again
            };

            // Return the ManageAccount view with both the user list and the form data
            return View("ManageAccount", manageAccountViewModel);
        }
        // ManageProgram action: Handles the program management view
        public IActionResult ManageProgram()
        {
            ViewData["ActivePage"] = "ManageProgram";
            return View();
        }

        // Error handling action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
