using Business.Interface;
using BusinessEntities;
using Data;
using Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PassengerManager : IPassengerManager
    {
        private readonly IPassengerRepository _PassengerRepository;

        public PassengerManager(IPassengerRepository PassengerRepository)
        {
            _PassengerRepository = PassengerRepository;
        }

        public string CreatePassneger(PassengerViewModel model)
        {
            return _PassengerRepository.CreatePassneger(model);
        }

        public bool DeletePassneger(int? Id)
        {
            return _PassengerRepository.DeletePassneger(Id);
        }

        public List<PassengerViewModel> GetAllPassengers()
        {
            return _PassengerRepository.GetAllPassengers();
        }

        public PassengerViewModel GetPassneger(int? Id)
        {
            return _PassengerRepository.GetPassneger(Id);
        }

        public string UpdatePassneger(int id, PassengerViewModel model)
        {
            return _PassengerRepository.UpdatePassneger(id, model);
        }
    }
}
