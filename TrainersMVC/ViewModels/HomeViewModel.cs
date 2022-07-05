using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainersMVC.Models;

namespace TrainersMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Trainer> Trainers { get; set; }
    }
}