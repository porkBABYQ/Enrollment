using System.ComponentModel.DataAnnotations;

namespace Enrollment.App.Models
{
    public class SubjectVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        [MinLength(7)]
        [MaxLength(7)]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Course Discription")]
        [MinLength(3)]
        [MaxLength(7)] /*Sir I can only input a maximum of 7 characters on my discription 
                    because for some reason my data base restrictes me from increasing the number.
                         If every I try to input 8 or more characters, an error will occur.*/
        public string Discription { get; set; }
        [Required]
        [Display(Name = "Course Units")]
        [MinLength(1)]
        [MaxLength(1)]
        public string Units { get; set; }
    }
}
