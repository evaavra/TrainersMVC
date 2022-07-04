﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainersMVC.Models;
using TrainersMVC.Repositories;
using TrainersMVC.ViewModels;

namespace TrainersMVC.Controllers
{
    public class TrainersController : Controller
    {
        public readonly TrainerRepository _trainersRepository;
        public readonly CourseRepository _coursesRepository;

        public TrainersController()
        {
            _trainersRepository = new TrainerRepository();
            _coursesRepository = new CourseRepository();
        }

        public ActionResult Index()
        {
            var trainers = _trainersRepository.GetAllWithCourses();
            return View(trainers);
        }

        public ActionResult Create()
        {
            var viewmodel = new TrainerFormViewModel()
            {
                Courses = _coursesRepository.GetAll()
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Courses = _coursesRepository.GetAll();
                return View(viewModel);
            }
            if(viewModel.ImageFile == null)
            {
                viewModel.Thumbnail = "im_av.png";
            }
            else
            {
                viewModel.Thumbnail = Path.GetFileName(viewModel.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img"), viewModel.Thumbnail);
                viewModel.ImageFile.SaveAs(fullPath);
            }
            _trainersRepository.Create(viewModel);
            _trainersRepository.Save();
            return RedirectToAction("Index");
        }
    }
}