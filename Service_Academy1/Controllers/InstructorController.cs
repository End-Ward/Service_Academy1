using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Service_Academy1.Models;
using System.Diagnostics;

namespace ServiceAcademy.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ILogger<InstructorController> _logger;
        private readonly ApplicationDbContext _context;
        public InstructorController(ILogger<InstructorController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Action method for Home.cshtml
        public async Task<IActionResult> InstructorDashboard()
        {
            // Fetch all programs along with their ProgramManagement data
            var programs = await _context.Programs
                                          .Include(p => p.ProgramManagement) // Include the ProgramManagement relationship
                                          .ToListAsync();

            // Check if any programs are being retrieved
            if (programs == null || !programs.Any())
            {
                // Log or handle the empty result case (optional)
                ViewData["Message"] = "No programs available.";
            }

            return View(programs);
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
        [HttpPost]
        public async Task<IActionResult> ActivateProgram(int programId, DateTime startDate, DateTime endDate)
        {
            // Check if there's an existing management record for the program
            var management = await _context.ProgramManagement.FirstOrDefaultAsync(pm => pm.ProgramId == programId);

            if (management == null)
            {
                // If there is no existing management record, create a new one
                management = new ProgramManagementModel
                {
                    ProgramId = programId,
                    StartDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc),
                    EndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc),
                    IsArchived = false,
                    IsActive = true // Set it as active
                };

                _context.ProgramManagement.Add(management);
            }
            else
            {
                // If there is an existing management record, just update it
                management.StartDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
                management.EndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
                management.IsArchived = false;
                management.IsActive = true; // Ensure it is set to active
            }

            await _context.SaveChangesAsync();

            TempData["Message"] = "Program activated successfully.";
            return RedirectToAction("InstructorDashboard");
        }


        [HttpPost]
        public async Task<IActionResult> DeactivateProgram(int programId)
        {
            var management = await _context.ProgramManagement.FirstOrDefaultAsync(pm => pm.ProgramId == programId);
            if (management != null)
            {
                management.EndDate = DateTime.UtcNow;
                management.IsActive = false; // Set program as inactive
                await _context.SaveChangesAsync();

                TempData["Message"] = "Program deactivated successfully.";
            }
            return RedirectToAction("InstructorDashboard");
        }

        [HttpPost]
        public async Task<IActionResult> ArchiveProgram(int programId)
        {
            var management = await _context.ProgramManagement.FirstOrDefaultAsync(pm => pm.ProgramId == programId);
            if (management != null)
            {
                management.IsArchived = true;
                await _context.SaveChangesAsync();
                TempData["Message"] = "Program archived successfully.";
            }
            return RedirectToAction("InstructorDashboard");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProgram(int programId)
        {
            var program = await _context.Programs.FindAsync(programId);
            if (program != null)
            {
                // Remove the associated ProgramManagement record
                var management = await _context.ProgramManagement.FirstOrDefaultAsync(pm => pm.ProgramId == programId);
                if (management != null)
                {
                    _context.ProgramManagement.Remove(management);
                }

                // Now remove the program itself
                _context.Programs.Remove(program);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Program and its management data deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Program not found.";
            }
            return RedirectToAction("InstructorDashboard");
        }
    }
}

