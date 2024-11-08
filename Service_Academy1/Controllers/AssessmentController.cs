using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_Academy1.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ServiceAcademy.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public AssessmentController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(QuizModel quizModel, int NumberOfQuestions, int ProgramId)
        {
            // Check if ProgramId exists
            var programExists = _context.Programs.Any(p => p.ProgramId == ProgramId);
            if (!programExists)
            {
                ModelState.AddModelError("", "The selected ProgramId does not exist.");
                return RedirectToAction("ProgramStream", "Instructor", new { id = ProgramId });
            }

            // Set the ProgramId in the QuizModel
            quizModel.ProgramId = ProgramId;

            // Save the QuizModel to the database
            _context.Quizzes.Add(quizModel);
            _context.SaveChanges();

            // Redirect to the CreateAssessment view, passing the NumberOfQuestions
            return RedirectToAction("CreateAssessment", new { id = quizModel.QuizId, numberOfQuestions = NumberOfQuestions });
        }
        // GET: CreateAssessment view
        public IActionResult CreateAssessment(int id, int numberOfQuestions)
        {
            var quiz = _context.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }

            ViewBag.ProgramId = quiz.ProgramId; // Pass ProgramId to the view
            ViewBag.NumberOfQuestions = numberOfQuestions; // Set NumberOfQuestions from user input
            return View(quiz);
        }
        [HttpPost]
        public IActionResult SaveQuestions(QuizModel quizModel, List<QuestionModel> questions)
        {
            var quiz = _context.Quizzes.Include(q => q.Questions).FirstOrDefault(q => q.QuizId == quizModel.QuizId);

            if (quiz != null)
            {
                foreach (var question in questions)
                {
                    // Link question to the quiz and save it to the database
                    question.QuizId = quiz.QuizId;
                    _context.Questions.Add(question);
                    _context.SaveChanges(); // Save each question first to generate the QuestionId

                    // Now add the correct answer to AnswerModel
                    var correctAnswer = new AnswerModel
                    {
                        Answer = question.CorrectAnswer,  // This is the correct answer text from the form
                        QuestionId = question.QuestionId  // Associate it with the saved question
                    };
                    _context.Answers.Add(correctAnswer); // Save the answer to the Answer table
                }
                _context.SaveChanges(); // Save all answers at once
            }

            // Redirect to ProgramStream or another appropriate location
            return RedirectToAction("ProgramStream", "Instructor", new { programId = quiz.ProgramId });
        }
        public IActionResult ViewQuiz(int quizId)
        {
            var quiz = _context.Quizzes
                               .Include(q => q.Questions)
                               .ThenInclude(q => q.Answers)
                               .FirstOrDefault(q => q.QuizId == quizId);

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz); // Pass the quiz model to the view
        }
        public async Task<IActionResult> StudentQuizView(int quizId)
        {
            // Get the current user's ID
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetch the quiz to get the associated ProgramId
            var quiz = await _context.Quizzes
                                     .Include(q => q.Questions)
                                     .ThenInclude(q => q.Answers)
                                     .FirstOrDefaultAsync(q => q.QuizId == quizId);

            if (quiz == null)
            {
                return NotFound("Quiz not found.");
            }

            // Fetch the enrollment associated with the user and the program
            var enrollment = await _context.Enrollment
                                           .FirstOrDefaultAsync(e => e.TraineeId == currentUserId && e.ProgramId == quiz.ProgramId);

            if (enrollment == null)
            {
                return Unauthorized("You are not enrolled in this program.");
            }

            // Check if the student already has a quiz result
            var existingResult = await _context.StudentQuizResults
                                               .FirstOrDefaultAsync(r => r.QuizId == quizId && r.EnrollmentId == enrollment.EnrollmentId);

            if (existingResult != null)
            {
                TempData["QuizErrorMessage"] = "You already have an existing result! You can't take the quiz again!";
                return RedirectToAction("QuizResult", new { resultId = existingResult.StudentQuizResultId });
            }

            ViewBag.EnrollmentId = enrollment.EnrollmentId;

            return View(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitQuiz(int quizId, Dictionary<int, string> answers, int enrollmentId)
        {
            // Fetch the quiz to get the associated ProgramId
            var quiz = await _context.Quizzes
                                     .Include(q => q.Questions)
                                     .ThenInclude(q => q.Answers)
                                     .FirstOrDefaultAsync(q => q.QuizId == quizId);

            if (quiz == null)
            {
                return NotFound("Quiz not found.");
            }

            // Check if the provided enrollment ID is valid for this program
            var enrollment = await _context.Enrollment
                                            .FirstOrDefaultAsync(e => e.EnrollmentId == enrollmentId
                                                                       && e.ProgramId == quiz.ProgramId);

            if (enrollment == null)
            {
                return BadRequest("Invalid Enrollment.");
            }

            // Check if the student already has a quiz result
            var existingResult = await _context.StudentQuizResults
                                               .FirstOrDefaultAsync(r => r.QuizId == quizId && r.EnrollmentId == enrollment.EnrollmentId);

            if (existingResult != null)
            {
                TempData["QuizErrorMessage"] = "You already have an existing result!";
                return RedirectToAction("QuizResult", new { resultId = existingResult.StudentQuizResultId });
            }

            // Proceed with calculating and saving the quiz result
            int rawScore = 0;
            List<StudentAnswerModel> studentAnswers = new List<StudentAnswerModel>();

            foreach (var question in quiz.Questions)
            {
                var studentAnswer = new StudentAnswerModel
                {
                    QuestionId = question.QuestionId,
                    Answer = answers.ContainsKey(question.QuestionId) ? answers[question.QuestionId] : string.Empty,
                    IsCorrect = answers.ContainsKey(question.QuestionId) && answers[question.QuestionId] == question.CorrectAnswer
                };

                studentAnswers.Add(studentAnswer);

                if (studentAnswer.IsCorrect)
                {
                    rawScore++;
                }
            }

            int totalScore = quiz.Questions.Count;
            double computedScore = Math.Round(((double)rawScore / totalScore) * 63.5 + 37.5, 2);

            var studentQuizResult = new StudentQuizResultModel
            {
                QuizId = quizId,
                EnrollmentId = enrollment.EnrollmentId,
                RawScore = rawScore,
                TotalScore = totalScore,
                ComputedScore = computedScore,
                Remarks = computedScore >= 50 ? "Pass" : "Fail",
                StudentAnswers = studentAnswers
            };

            _context.StudentQuizResults.Add(studentQuizResult);
            await _context.SaveChangesAsync();

            return RedirectToAction("QuizResult", new { resultId = studentQuizResult.StudentQuizResultId });
        }


        public async Task<IActionResult> QuizResult(int resultId)
        {
            // Ensure we include the Quiz along with StudentAnswers and related Questions
            var result = await _context.StudentQuizResults
                .Include(r => r.StudentAnswers)
                    .ThenInclude(sa => sa.Question) // Include the related questions for each answer
                .Include(r => r.Quiz)  // Ensure the Quiz is included here
                .FirstOrDefaultAsync(r => r.StudentQuizResultId == resultId);

            if (result == null)
            {
                _logger.LogError("Quiz result not found for resultId: {ResultId}", resultId);
                return NotFound("Quiz result not found.");
            }

            if (result.Quiz == null)
            {
                _logger.LogError("Quiz information not found for resultId: {ResultId}", resultId);
                return NotFound("Quiz information not found.");
            }

            return View(result);
        }

    }
}
