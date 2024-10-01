using System.ComponentModel.DataAnnotations;

namespace Service_Academy1.Models
{
    public class ProgramCreateViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        public string InstructorId { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty; // This will be set in the controller
    }
}
