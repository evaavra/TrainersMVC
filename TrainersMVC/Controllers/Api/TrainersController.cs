using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainersMVC.Repositories;

namespace TrainersMVC.Controllers.Api
{
    public class TrainersController : ApiController
    {
        private readonly TrainerRepository _trainerRepository;

        public TrainersController()
        {
            _trainerRepository = new TrainerRepository();
        }

        //[HttpPost]
        //public IHttpActionResult Hello(int id)
        //{
        //    Console.WriteLine("Hello");
        //    return Ok();
        //}

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            Console.WriteLine("Hello");
            var trainer = _trainerRepository.GetById(id);
            if (trainer == null)
                return NotFound();

            _trainerRepository.Delete(trainer);
            return Ok();
        }
    }
}
