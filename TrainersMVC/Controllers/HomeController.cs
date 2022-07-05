using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainersMVC.Repositories;
using TrainersMVC.ViewModels;

namespace TrainersMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrainerRepository _trainerRepository;

        public HomeController()
        {
            _trainerRepository = new TrainerRepository();
        }

        public ActionResult Index()
        {
            var viewmodel = new HomeViewModel()
            {
                Trainers = _trainerRepository.GetFirstFour()
            };
            return View(viewmodel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}