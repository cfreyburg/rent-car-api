using Cinq.RentCar.Abstractions.Services;
using Cinq.RentCar.Controllers.Controllers;
using Cinq.RentCar.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinq.RentCar.Controllers.Test
{
    [TestClass]
    public class BookControllerTest
    {
        private readonly Mock<IRentService> _service;
        private readonly BookController _controller;

        public BookControllerTest()
        {
            _service = new Mock<IRentService>();
            _controller = new BookController(_service.Object);
        }

        [TestMethod]
        public void controller_should_save()
        {
            var book = new Book();
            _controller.Post(book);

            _service.Verify(q => q.Book(book), Times.Once);
        }
    }
}
