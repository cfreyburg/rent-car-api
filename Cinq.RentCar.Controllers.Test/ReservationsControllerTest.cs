using Cinq.RentCar.Abstractions.Entities;
using Cinq.RentCar.Abstractions.Services;
using Cinq.RentCar.Controllers.Controllers;
using Cinq.RentCar.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinq.RentCar.Controllers.Test
{
    [TestClass]
    public class ReservationsControllerTest
    {
        private readonly Mock<IRentService> _service;
        private readonly ReservationsController _controller;
        public ReservationsControllerTest()
        {
            _service = new Mock<IRentService>();
            _controller = new ReservationsController(_service.Object);
        }

        [TestMethod]
        public void controller_should_return_reservations()
        {
            var expected = new Book[] { new Book(), new Book() };
            _service.Setup(q => q.GetReservations()).Returns(expected);

            var actual = _controller.Get();

            Assert.AreEqual(expected, actual);
        }
    }
}
