using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Service_Academy1.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Reflection;
using System;

namespace ServiceAcademy.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ILogger<InstructorController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public InstructorController(ILogger<InstructorController> logger, ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _logger = logger;
            _context = context;
            _environment = environment;
        }

        // Action method for Home.cshtml
        public async Task<IActionResult> InstructorDashboard()
        {
            // Get the current user's ID
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetch programs created by the logged-in instructor
            var programs = await _context.Programs
                                          .Where(p => p.InstructorId == currentUserId) // Filter by the current instructor's ID
                                          .Include(p => p.ProgramManagement) // Include the ProgramManagement relationship
                                          .ToListAsync();

            // Check if any programs are being retrieved
            if (programs == null || !programs.Any())
            {
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
        public IActionResult ProgramStream(int programId)
        {
            var program = _context.Programs
                                  .Include(p => p.Modules)
                                  .FirstOrDefault(p => p.ProgramId == programId);

            if (program == null)
            {
                TempData["Error"] = "Program not found.";
                return RedirectToAction("InstructorDashboard");
            }

            var viewModel = new ProgramStreamViewModel
            {
                ProgramId = program.ProgramId,
                Title = program.Title,
                Description = program.Description,
                PhotoPath = program.PhotoPath,
                Modules = program.Modules.ToList()
            };

            return View(viewModel);
        }

        public IActionResult ProgramStreamManage(int programId)
        {
            _logger.LogInformation("Fetching enrolled trainees for Program ID: {ProgramId}", programId);

            // Fetch enrolled trainees for the specified program ID with a pending or approved status
            var enrolledTrainees = _context.Enrollment
                .Where(e => e.ProgramId == programId &&
                            (e.EnrollmentStatus == "Approved" || e.EnrollmentStatus == "Pending"))
                .Select(e => new EnrolleeViewModel
                {
                    EnrollmentId = e.EnrollmentId,
                    TraineeName = e.currentTrainee != null ? e.currentTrainee.UserName : "Unknown",
                    EnrollmentStatus = e.EnrollmentStatus,
                    ProgramStatus = e.ProgramStatus
                })
                .ToList();

            if (!enrolledTrainees.Any())
            {
                _logger.LogWarning("No enrolled trainees found for Program ID: {ProgramId}", programId);
            }
            else
            {
                _logger.LogInformation("Found {Count} enrolled trainees for Program ID: {ProgramId}", enrolledTrainees.Count, programId);
            }

            return View(enrolledTrainees);
        }

        // Approve enrollment
        [HttpPost]
        public async Task<IActionResult> ApproveEnrollment(int enrollmentId)
        {
            var enrollment = await _context.Enrollment.FindAsync(enrollmentId);
            if (enrollment == null) return NotFound();

            enrollment.EnrollmentStatus = "Approved";
            await _context.SaveChangesAsync();

            return RedirectToAction("ProgramStreamManage", new { programId = enrollment.ProgramId });
        }

        [HttpPost]
        public async Task<IActionResult> DenyEnrollment(int enrollmentId, string reasonForDenial)
        {
            var enrollment = await _context.Enrollment.FindAsync(enrollmentId);
            if (enrollment == null) return NotFound();

            enrollment.EnrollmentStatus = "Denied";
            enrollment.ReasonForDenial = reasonForDenial; // Store the denial reason
            await _context.SaveChangesAsync();

            return RedirectToAction("ProgramStreamManage", new { programId = enrollment.ProgramId });
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
            var program = await _context.Programs
                                         .Include(p => p.Modules) // Include related modules
                                         .Include(p => p.Enrollments) // Include related enrollments
                                         .FirstOrDefaultAsync(p => p.ProgramId == programId);

            if (program != null)
            {
                // Remove all related modules
                var modules = _context.Modules.Where(m => m.ProgramId == programId);
                _context.Modules.RemoveRange(modules);

                // Remove all related enrollments
                var enrollments = _context.Enrollment.Where(e => e.ProgramId == programId);
                _context.Enrollment.RemoveRange(enrollments);

                // Now remove the program itself
                _context.Programs.Remove(program);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Program and its related data deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Program not found.";
            }

            return RedirectToAction("InstructorDashboard");
        }


        [HttpPost]
        public async Task<IActionResult> UploadModule(int programId, string title, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "No file selected";
                return RedirectToAction("ProgramStream", new { programId });
            }

            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var module = new ModuleModel
            {
                ProgramId = programId,
                Title = title,
                FilePath = "/uploads/" + file.FileName
            };

            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProgramStream", new { programId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

 