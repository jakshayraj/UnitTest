using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Data.Repository;
using WebAPI.Controllers;
using Business.Interface;
using BusinessEntities;
using System.Web.Http.Results;
using Data;

namespace UnitTest
{
    public class PassengerUnitTest
    {
        private readonly Mock<IPassengerManager> mockDtaRepository = new Mock<IPassengerManager>();
        private readonly PassengersController _passengerController;
        public PassengerUnitTest()
        {
            _passengerController = new PassengersController(mockDtaRepository.Object);
        }
        [Fact]
        public void Test_GetAllPassenger1()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.GetAllPassengers()).Returns(GetPassenger());

            // Act
            var response = _passengerController.GetPassengers();

            // Asert
            Assert.Equal(3, response.Count);

        }
        [Fact]
        public void Test_GetAllPassenger2()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.GetAllPassengers()).Returns(GetPassenger());

            // Act
            var response = _passengerController.GetPassengers();

            // Asert
            Assert.NotEqual(2, response.Count);

        }
        [Fact]
        public void Test_GetUserById1()
        {
            // Arrange
            var passenger = new PassengerViewModel();
            passenger.PassengerNumber = 1;
            passenger.FirstName = "Mukesh";
            passenger.LastName = "Shah";
            passenger.PhoneNo = "8695049876";

            // Act
            var responseObj = mockDtaRepository.Setup(x => x.GetPassneger(passenger.PassengerNumber)).Returns(passenger);
            var result = _passengerController.GetPassenger(passenger.PassengerNumber);
          
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Test_GetUserById2()
        {
            // Arrange
            var passenger = new PassengerViewModel();
            // Act
            var responseObj = mockDtaRepository.Setup(x => x.GetPassneger(4)).Returns(passenger);
            var result = _passengerController.GetPassenger(passenger.PassengerNumber);
            
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public void Test_AddUser1()
        {
            var newPassenger = new PassengerViewModel();
            newPassenger.PassengerNumber = 4;
            newPassenger.FirstName = "Vijay";
            newPassenger.LastName = "Sharma";
            newPassenger.PhoneNo = "8695049876";
            // Act
            var response = mockDtaRepository.Setup(x => x.CreatePassneger(newPassenger)).Returns("Added succeffuly");
            var result = _passengerController.PostPassenger(newPassenger);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Test_AddUser2()
        {
            var newPassenger = new PassengerViewModel();
           
            // Act
            var response = mockDtaRepository.Setup(x => x.CreatePassneger(newPassenger)).Returns("Model is null");
            var result = _passengerController.PostPassenger(newPassenger);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Test_UpdateUser1()
        {
            // Arrange
            var UpdatePassenger = new PassengerViewModel();
            UpdatePassenger.PassengerNumber = 4;
            UpdatePassenger.FirstName = "Ramesh";
            UpdatePassenger.LastName = "Sharma";
            UpdatePassenger.PhoneNo = "8695049876";

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.UpdatePassneger(4,UpdatePassenger)).Returns("Passenger updated");
            var response = _passengerController.PutPassenger(4,UpdatePassenger);
            // Assert
            Assert.Equal("Passenger updated",response);
        }
        [Fact]
        public void Test_UpdateUser2()
        {
            // Arrange
            var UpdatePassenger = new PassengerViewModel();

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.UpdatePassneger(5,UpdatePassenger)).Returns("Model is null");
            var response = _passengerController.PutPassenger(5,UpdatePassenger);
            // Assert
            Assert.NotEqual("Passenger updated", response);
        }
        [Fact]  
        public void Test_DeleteUser1()
        {
            var passenger = new PassengerViewModel();
            passenger.PassengerNumber = 1;
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.DeletePassneger(passenger.PassengerNumber)).Returns(true);

            // Act
            var response = _passengerController.DeletePassenger(passenger.PassengerNumber);

            //Assert
            Assert.True(response);

        }
        [Fact]
        public void Test_DeleteUser2()
        {
            var passenger = new PassengerViewModel();
            passenger.PassengerNumber = 4;
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.DeletePassneger(passenger.PassengerNumber)).Returns(false);

            // Act
            var response = _passengerController.DeletePassenger(passenger.PassengerNumber);

            //Assert
            Assert.False(response);

        }
        private static List<PassengerViewModel> GetPassenger()
        {
            List<PassengerViewModel> users = new List<PassengerViewModel>()
            {
                new PassengerViewModel() {PassengerNumber=1,FirstName="Mukesh",LastName="Shah",PhoneNo="8695049876"},
                new PassengerViewModel() {PassengerNumber=1,FirstName="Rajesh",LastName="Singh",PhoneNo="8695049876"},
                new PassengerViewModel() {PassengerNumber=1,FirstName="Aman",LastName="Gohel",PhoneNo="8695049876"},

            };
            return users;
        }
        
    }
}
