using System.ComponentModel.DataAnnotations;

namespace Enrollment.App.Models
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
    }
}
