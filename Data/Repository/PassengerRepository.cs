using Data.Repository.Interface;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusinessEntities;

namespace Data.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly CLPMEntities _dbContext;
        public PassengerRepository()
        {
            _dbContext = new CLPMEntities();
        }
        public List<PassengerViewModel> GetAllPassengers()
        {
            var entity = _dbContext.Passengers.ToList();
            List<PassengerViewModel> list = new List<PassengerViewModel>();
            if (_dbContext != null)
            {
                foreach (var item in entity)
                {
                    PassengerViewModel passenger = new PassengerViewModel();
                    passenger.PassengerNumber = item.PassengerNumber;
                    passenger.FirstName = item.FirstName;
                    passenger.LastName = item.LastName;
                    passenger.PhoneNo = item.PhoneNo;
                    list.Add(passenger);
                }
            }
            return list;
        }
        public string CreatePassneger(PassengerViewModel model)
        {
            try
            {
                if (model != null)
                {
                    Passenger passenger = new Passenger();
                    passenger.PassengerNumber = model.PassengerNumber;
                    passenger.FirstName = model.FirstName;
                    passenger.LastName = model.LastName;
                    passenger.PhoneNo = model.PhoneNo;
                    _dbContext.Passengers.Add(passenger);
                    _dbContext.SaveChanges();
                    return "Added succeffuly";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeletePassneger(int? Id)
        {
            var entity = _dbContext.Passengers.Find(Id);
            if (entity != null)
            {
                _dbContext.Passengers.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;

        }
        public string UpdatePassneger(int id, PassengerViewModel model)
        {
            try
            {
                Passenger entity = _dbContext.Passengers.Find(id);
                if (model != null)
                {
                    entity.PassengerNumber = model.PassengerNumber;
                    entity.FirstName = model.FirstName;
                    entity.LastName = model.LastName;
                    entity.PhoneNo = model.PhoneNo;
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return "Passenger updated";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public PassengerViewModel GetPassneger(int? Id)
        {
            try
            {
                var entity = _dbContext.Passengers.Find(Id);
                PassengerViewModel passenger = new PassengerViewModel();
                passenger.PassengerNumber = entity.PassengerNumber;
                passenger.FirstName = entity.FirstName;
                passenger.LastName = entity.LastName;
                passenger.PhoneNo = entity.PhoneNo;
                return passenger;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
