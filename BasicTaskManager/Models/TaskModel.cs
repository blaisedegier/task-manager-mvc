using System.ComponentModel.DataAnnotations;

namespace BasicTaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string? Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Deadline is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime Deadline { get; set; }
    }
}
