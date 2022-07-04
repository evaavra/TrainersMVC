using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainersMVC.Models;
using System.Data.Entity;
using TrainersMVC.ViewModels;

namespace TrainersMVC.Repositories
{
    public class TrainerRepository : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public TrainerRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Trainer> GetAllWithCourses()
        {
            return _context.Trainers.Include(t => t.Course);
        }

        public void Create(TrainerFormViewModel viewModel)
        {
            var trainer = new Trainer()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                CourseID = viewModel.CourseID,
                Thumbnail = viewModel.Thumbnail
            };
            _context.Trainers.Add(trainer);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}