using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainersMVC.Models;

namespace TrainersMVC.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }
    }
}