using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Repositories;
using Cinq.RentCar.Abstractions.Services;
using Cinq.RentCar.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinq.RentCar.Services.Test
{
    [TestClass]
    public class RentServiceTest
    {
        private readonly Mock<IRentRepository> _repo;
        private readonly IRentService _service;
        public RentServiceTest()
        {
            _repo = new Mock<IRentRepository>();
            _service = new RentService(_repo.Object);
        }

        [TestMethod]
        public void rent_service_should_book()
        {
            var rent = new Book { BookReference = "1234"};
            _service.Book(rent);

            _repo.Verify(q => q.Book(rent), Times.Once);
        }

        [TestMethod]
        public void rent_service_should_cancel_book()
        {
            var reference = "1234";
            _service.CancelReservation(reference);

            _repo.Verify(q => q.CancelReservation(reference), Times.Once);
        }

        [TestMethod]
        public void rent_service_should_find_reservations()
        {
            var reference = "1234";
            var expected = new Book { BookReference = reference };
            _repo.Setup(q => q.FindReservation(reference)).Returns(expected);

            var actual = _service.FindReservation(reference);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void rent_service_should_get_available_cars()
        {
            var expected = new ICar[2] { new Car(), new Car() };
            _repo.Setup(q => q.GetAvailableCars()).Returns(expected);

            var actual = _service.GetAvailableCars();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void rent_service_should_get_reservations()
        {
            var expected = new IBook[1] { new Book() };
            _repo.Setup(q => q.GetReservations()).Returns(expected);

            var actual = _service.GetReservations();

            Assert.AreEqual(expected, actual);
        }
    }
}
