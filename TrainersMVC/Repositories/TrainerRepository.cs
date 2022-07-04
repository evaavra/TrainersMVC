using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainersMVC.Models;

namespace TrainersMVC.Repositories
{
    public class TrainerRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainerRepository()
        {
            _context = new ApplicationDbContext();
        }

    }
}