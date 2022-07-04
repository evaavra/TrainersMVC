using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainersMVC.Models;
using System.Data.Entity;

namespace TrainersMVC.Repositories
{
    public class TrainerRepository
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

    }
}