using Cinq.RentCar.Abstractions.Entities;
using Cinq.RentCar.Abstractions.Services;
using Cinq.RentCar.Controllers.Controllers;
using Cinq.RentCar.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinq.RentCar.Controllers.Test
{
    [TestClass]
	public class CarsControllerTest
    {
        private readonly Mock<IRentService> _service;
        private readonly CarsController _controller;
        public CarsControllerTest()
        {
            _service = new Mock<IRentService>();
            _controller = new CarsController(_service.Object);
        }

        [TestMethod]
        public void controller_should_return_cars()
        {
            var expected = new Car[] { new Car (), new Car() };
            _service.Setup(q => q.GetAvailableCars()).Returns(expected);

            var actual = _controller.Get();

            Assert.AreEqual(expected, actual);
        }
    }
}
