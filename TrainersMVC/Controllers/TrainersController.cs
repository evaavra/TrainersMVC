using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainersMVC.Repositories;

namespace TrainersMVC.Controllers
{
    public class TrainersController : Controller
    {
        public readonly TrainerRepository _trainersRepository;

        public TrainersController()
        {
            _trainersRepository = new TrainerRepository();
        }

        public ActionResult Index()
        {
            var trainers = _trainersRepository.GetAllWithCourses();
            return View(trainers);
        }
    }
}