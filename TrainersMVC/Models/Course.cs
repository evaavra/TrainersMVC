using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainersMVC.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public IEnumerable<Trainer> Trainers { get; set; }
    }
}