﻿using Microsoft.AspNetCore.Mvc;
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
                .Where(e => e.TraineeId == userId)
                .Include(e => e.ProgramsModel)
                    .ThenInclude(p => p.ProgramManagement) // Include ProgramManagement for IsArchived
                .AsSplitQuery()  // Split the query to avoid joining too many tables
                .Select(e => new
                {
                    Program = e.ProgramsModel,
                    e.EnrollmentStatus,
                    e.ProgramStatus,
                    e.ReasonForDenial,
                    IsArchived = e.ProgramsModel.ProgramManagement.Any(pm => pm.IsArchived) // Check if any ProgramManagement entry is archived
                })
                .ToList();
            return View(enrolledPrograms);
        }

        [HttpPost]
        public IActionResult DeleteProgram(int programId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var enrollment = _context.Enrollment
                .Include(e => e.ProgramsModel)
                .ThenInclude(p => p.ProgramManagement)
                .FirstOrDefault(e => e.ProgramId == programId && e.TraineeId == userId);

            if (enrollment != null)
            {
                // Check if the program is archived
                var isArchived = enrollment.ProgramsModel.ProgramManagement.Any(pm => pm.IsArchived);

                if (enrollment.EnrollmentStatus == "Denied" || isArchived)
                {
                    // Allow deletion if status is Denied or the program is archived
                    _context.Enrollment.Remove(enrollment);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = isArchived
                        ? "Enrollment deleted successfully as the program is archived."
                        : "Enrollment deleted successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Cannot delete enrollment. It can only be deleted if denied or archived.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Enrollment not found or invalid program ID.";
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
                .Include(p => p.Quizzes)
                    .ThenInclude(q => q.Questions)  // Avoid including Answers if unnecessary
                .AsSplitQuery()  // Split the queries for related entities
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
                Modules = program.Modules.ToList(),
                Quizzes = program.Quizzes.ToList() // Include only the necessary data
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult RedirectToQuizOrResult(int quizId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Retrieve the enrollment for the current user and the specified quiz
            var enrollment = _context.Enrollment
                .FirstOrDefault(e => e.TraineeId == userId &&
                                     e.ProgramsModel.Quizzes.Any(q => q.QuizId == quizId));

            if (enrollment == null)
            {
                TempData["Error"] = "Enrollment not found for this quiz.";
                return RedirectToAction("MyLearningStream");
            }

            // Check for an existing quiz result for this enrollment and quiz
            var quizResult = _context.StudentQuizResults
                .FirstOrDefault(sqr => sqr.QuizId == quizId && sqr.EnrollmentId == enrollment.EnrollmentId);

            if (quizResult != null)
            {
                // Redirect to QuizResult using the StudentQuizResultId
                return RedirectToAction("QuizResult", "Assessment", new { resultId = quizResult.StudentQuizResultId });
            }
            else
            {
                // If no result exists, redirect to StudentQuizView for answering
                return RedirectToAction("StudentQuizView", "Assessment", new { quizId = quizId });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

