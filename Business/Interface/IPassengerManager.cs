using BusinessEntities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IPassengerManager
    {
        List<PassengerViewModel> GetAllPassengers();
        string CreatePassneger(PassengerViewModel model);
        bool DeletePassneger(int? Id);
        PassengerViewModel GetPassneger(int? Id);
        string UpdatePassneger(int id, PassengerViewModel model);
    }
}
