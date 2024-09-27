using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Registration View
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                await _signInManager.SignInAsync(user, isPersistent: false);

                TempData["SuccessMessage"] = "Registration successful!";
                return RedirectToAction("MyLearning", "Trainee");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    // Login View
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault(); // Assuming a single role per user
                    switch (role)
                    {
                        case "Admin":
                            return RedirectToAction("Dashboard", "Admin");
                        case "Instructor":
                            return RedirectToAction("InstructorDashboard", "Instructor");
                        case "Student":
                            return RedirectToAction("MyLearning", "Trainee");
                        default:
                            return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

   

    [Authorize(Roles = "Admin")] // Only allow Admins to access this action
    public IActionResult ManageAccount()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ManageAccount(ManageAccountViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Fetch the list of users first



            model.Users = await _userManager.Users.ToListAsync();
            


            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.Username, // You might not need FullName here 
                
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                TempData["SuccessMessage"] = "Account created successfully!";
                return RedirectToAction("ManageAccount");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }
}
