using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service_Academy1.Models;
using System.IO;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProgramCreation(ProgramsModel program, IFormFile photoInput)
        {
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
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + photoInput.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photoInput.CopyToAsync(fileStream);
                }

                program.PhotoPath = "/Images/" + uniqueFileName;
            }
            else
            {
                _logger.LogError("Photo input is required.");
                ModelState.AddModelError("photoInput", "The Photo field is required.");
                return View(program);
            }

            try
            {
                _context.Programs.Add(program);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving program to the database.");
                return View(program);
            }

            return RedirectToAction("InstructorDashboard");
        }
    }
}
