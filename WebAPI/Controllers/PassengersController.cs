using Business.Interface;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class PassengersController : ApiController
    {
       
        private readonly IPassengerManager _passengerManager;

        public PassengersController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }

        // GET: api/Passengers
        public List<PassengerViewModel> GetPassengers()
        {
            return _passengerManager.GetAllPassengers();
        }

        // GET: api/Passengers/5
        public PassengerViewModel GetPassenger(int id)
        {
            return _passengerManager.GetPassneger(id); ;
        }

        // PUT: api/Passengers/5
        public string PutPassenger(int id, PassengerViewModel passenger)
        {
            return _passengerManager.UpdatePassneger(id, passenger);
        }

        // POST: api/Passengers
        public string PostPassenger(PassengerViewModel passenger)
        {
            return _passengerManager.CreatePassneger(passenger);
        }

        // DELETE: api/Passengers/5
        public bool DeletePassenger(int id)
        {
            return _passengerManager.DeletePassneger(id);
        }

        
    }
}