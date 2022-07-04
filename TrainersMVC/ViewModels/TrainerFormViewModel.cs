using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrainersMVC.Models;

namespace TrainersMVC.ViewModels
{
    public class TrainerFormViewModel
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseID { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }

        public string Thumbnail { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}