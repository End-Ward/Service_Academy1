using Service_Academy1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AssessmentModel
{
    public QuizModel Quiz { get; set; }
    [ForeignKey("ProgramsModel")]
    public int ProgramId { get; set; }
    public List<QuestionModel> Questions { get; set; }
    public List<UserResponseModel> UserResponses { get; set; }

    // You can also include additional properties related to assessments here
    public string Description { get; set; } // Optional: Description of the quiz
    public int Duration { get; set; } // Optional: Duration of the quiz in minutes
    public virtual ProgramsModel? ProgramsModel { get; set; } // Navigation property
}

public class QuizModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public virtual ICollection<QuestionModel> Questions { get; set; }
}

public class QuestionModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int QuizId { get; set; }
    public virtual QuizModel Quiz { get; set; }
    public virtual ICollection<AnswerModel> Answers { get; set; }
}

public class AnswerModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; } // Indicates if this is the correct answer
    public int QuestionId { get; set; }
    public virtual QuestionModel Question { get; set; }
}

public class UserResponseModel
{
    public int Id { get; set; }

    [ForeignKey("currentTrainee")]
    public string? TraineeId { get; set; }  // User ID (from AspNetUsers table if you use Identity)
    public int QuestionId { get; set; }
    public int SelectedAnswerId { get; set; }
    public virtual QuestionModel Question { get; set; }
    public virtual AnswerModel SelectedAnswer { get; set; }

    public virtual ApplicationUser? currentTrainee { get; set; }
}
