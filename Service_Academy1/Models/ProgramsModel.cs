using System.ComponentModel.DataAnnotations;

namespace Service_Academy1.Models
{
    public class ProgramsModel
    {
        [Key]
        public int ProgramId { get; set; } 

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Instructor { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string PhotoPath { get; set; } = string.Empty;
    }
}
