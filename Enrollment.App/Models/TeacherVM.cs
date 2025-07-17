﻿using System.ComponentModel.DataAnnotations;

namespace Enrollment.App.Models
{
    public class TeacherVM
    {
        public int Id { get; set; }
        [Required]
        [Display (Name = "Family Name")]
        [MinLength (2)]
        [MaxLength (30)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Given Name")]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }
    }
}
