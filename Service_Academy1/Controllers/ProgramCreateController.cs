using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service_Academy1.Models;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceAcademy.Controllers
{
    public class ProgramCreateController : Controller
    {
        private readonly ILogger<ProgramCreateController> _logger;
        private readonly ApplicationDbContext _context;

        public ProgramCreateController(ILogger<ProgramCreateController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult ProgramCreation()
        {
            var instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var instructorName = User.FindFirstValue(ClaimTypes.Name); // Get the user's name

            var viewModel = new ProgramCreateViewModel
            {
                InstructorId = instructorId,
                InstructorName = instructorName
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProgramCreation(ProgramsModel program, IFormFile photoInput)
        {
            // Remove InstructorId from model binding (set to null) to avoid validation error
            program.InstructorId = null;

            if (!ModelState.IsValid)
            {
                // Log validation errors
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        _logger.LogError($"Field: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }
                return View(program);
            }

            if (photoInput != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CreatedImages");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + photoInput.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photoInput.CopyToAsync(fileStream);
                }

                program.PhotoPath = "/CreatedImages/" + uniqueFileName;
            }
            else
            {
                _logger.LogError("Photo input is required.");
                ModelState.AddModelError("photoInput", "The Photo field is required.");
                return View(program);
            }

            try
            {
                // Get the current user Id and name from AspNetUsers
                var instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var instructorName = User.FindFirstValue(ClaimTypes.Name); // Get the user's name

                program.InstructorId = instructorId;  // Assign the current user's Id to InstructorId
                program.Instructor = instructorName;  // Assign the instructor's name

                // Add the program to the database
                _context.Programs.Add(program);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Successfully added a Program";
                return RedirectToAction("ProgramCreation", "ProgramCreate"); // Ensure correct action name
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving program to the database.");
                TempData["Error"] = "Failed to add a Program. Please try again.";
                return View(program);
            }
        }
    }
}
