using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                Heading = "Create a Trainer",
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
                viewModel.Heading = "Create a Trainer";
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

        public ActionResult Details(int id)
        {
            try
            {
                var trainer = _trainersRepository.GetByIdWithCourse(id);
                if (trainer == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var viewModel = new TrainerDetailsViewModel()
                    {
                        Trainer = trainer
                    };
                    return View(viewModel);
                }
                    
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var trainer = _trainersRepository.GetByIdWithCourse(id);
                if (trainer == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var viewModel = new TrainerFormViewModel()
                    {
                        ID = trainer.ID,
                        FirstName = trainer.FirstName,
                        LastName = trainer.LastName,
                        CourseID = trainer.CourseID,
                        Thumbnail = trainer.Thumbnail,
                        Courses = _coursesRepository.GetAll(),
                        Heading = "Edit the Trainer"
                    };
                    return View("Create",viewModel);
                }

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult Edit(TrainerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Edit the Trainer";
                viewModel.Courses = _coursesRepository.GetAll();
                return View("Create",viewModel);
            }
            if (viewModel.ImageFile != null)
            {
                viewModel.Thumbnail = Path.GetFileName(viewModel.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img"), viewModel.Thumbnail);
                viewModel.ImageFile.SaveAs(fullPath);
            }
            _trainersRepository.Edit(viewModel);
            
            return RedirectToAction("Index");
        }
    }

    
}