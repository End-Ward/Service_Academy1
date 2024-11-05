using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_Academy1.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ServiceAcademy.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TraineeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult MyLearning()
        {
            // Retrieve the messages from TempData
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];

            // Get the logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetch programs the trainee is enrolled in, including enrollment status and reason for denial
            var enrolledPrograms = _context.Enrollment
                .Where(e => e.TraineeId == userId) // Filter by TraineeId
                .Include(e => e.ProgramsModel) // Include related program details
                .Select(e => new
                {
                    Program = e.ProgramsModel,
                    e.EnrollmentStatus,
                    e.ProgramStatus,
                    e.ReasonForDenial // Include reason for denial
                })
                .ToList();

            return View(enrolledPrograms);
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

        [HttpPost]
        public IActionResult DeleteProgram(int programId)
        {
            var enrollment = _context.Enrollment.FirstOrDefault(e => e.ProgramId == programId && e.TraineeId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (enrollment != null && enrollment.EnrollmentStatus == "Denied")
            {
                _context.Enrollment.Remove(enrollment);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Enrollment deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Cannot delete enrollment. It can only be deleted if denied.";
            }

            return RedirectToAction("MyLearning");
        }
        public IActionResult MyLearningStream(int programId)
        {
            if (programId <= 0)
            {
                TempData["Error"] = "Invalid Program ID";
                return RedirectToAction("MyLearning");
            }

            var program = _context.Programs
                .Include(p => p.Modules) // Include Modules data
                .FirstOrDefault(p => p.ProgramId == programId);

            if (program == null)
            {
                TempData["Error"] = "Program not found.";
                return RedirectToAction("MyLearning");
            }

            var viewModel = new ProgramStreamViewModel // Or create a MyLearningStreamViewModel
            {
                ProgramId = program.ProgramId,
                Title = program.Title,
                Description = program.Description,
                PhotoPath = program.PhotoPath,
                Modules = program.Modules.ToList() // Include modules in the view model
            };

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
