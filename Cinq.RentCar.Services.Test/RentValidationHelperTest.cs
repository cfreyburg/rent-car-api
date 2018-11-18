using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Entities;
using Cinq.RentCar.Abstractions.Exceptions;
using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Repositories;
using Cinq.RentCar.Abstractions.Services;
using Cinq.RentCar.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinq.RentCar.Services.Test
{
    [TestClass]
    public class RentValidationHelperTest
    {
        private readonly Mock<IRentRepository> _repo;
        private readonly IRentValidationHelper _validator;

        public RentValidationHelperTest()
        {
            _repo = new Mock<IRentRepository>();
            _validator = new RentValidationHelper(_repo.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(RentExceptions.RentBadRequest))]
        public void validation_should_throw_bad_request()
        {
            BookDTO book = null;
            _validator.ValidateBook(book);
        }

        [TestMethod]
        [ExpectedException(typeof(RentExceptions.RentNotFound))]
        public void validation_should_throw_not_found()
        {
            var book = new BookDTO { Car = new Car { Category = EnumCategory.Economy, Model = EnumModel.Camaro, Year = 2018 } };
            var expected = new Car[] { book.Car };

            _repo.Setup(q => q.GetRentedCars()).Returns(expected);

            _validator.ValidateBook(book);
        }

        [TestMethod]
        public void validation_should_not_throw()
        {
            var book = new BookDTO { Car = new Car { Category = EnumCategory.Economy, Model = EnumModel.Camaro, Year = 2018 } };
            var expected = new Car[] { new Car { Category = EnumCategory.Economy, Model = EnumModel.Fusion, Year = 2018 } };

            _repo.Setup(q => q.GetRentedCars()).Returns(expected);

            _validator.ValidateBook(book);

            _repo.Verify(q => q.GetRentedCars(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(RentExceptions.RentBadRequest))]
        public void validation_cancel_should_throw_bad_request()
        {
            var reference = string.Empty;
            
            _validator.ValidateDelete(reference);
        }

        [TestMethod]
        [ExpectedException(typeof(RentExceptions.RentBadRequest))]
        public void validation_cancel_should_throw_bad_request_not_exists()
        {
            var reference = "123456";
            Book expected = null;
            _repo.Setup(q => q.FindReservation(reference)).Returns(expected);

            _validator.ValidateDelete(reference);
        }

        [TestMethod]
        public void validation_cancel_should_not_throw()
        {
            var reference = "123456";
            Book expected = new Book();
            _repo.Setup(q => q.FindReservation(reference)).Returns(expected);

            _validator.ValidateDelete(reference);
        }
    }
}
