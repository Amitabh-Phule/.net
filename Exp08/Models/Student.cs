using System.ComponentModel.DataAnnotations;

namespace Exp08.Models
{
    // Beginner-level Student model
    public class Student
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        public string Name { get; set; } // Student name

        [Required]
        public string Course { get; set; } // Course enrolled
    }
}
