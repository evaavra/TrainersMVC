using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainersMVC.Models
{
    public class Trainer
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CourseID { get; set; }

        public Course Course { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }
}