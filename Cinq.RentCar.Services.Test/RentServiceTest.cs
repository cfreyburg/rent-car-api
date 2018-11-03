﻿using System;
using Cinq.RentCar.Abstractions.Repositories;
using Cinq.RentCar.Abstractions.Services;
using Cinq.RentCar.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

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
        public void service_should_create_book()
        {
            var rent = new Book();
            _service.Book(rent);

            _repo.Verify(q => q.Book(rent), Times.Once);
        }

        [TestMethod]
        public void service_should_cancel_reservation()
        {
            var reference = "123456";
            _service.CancelReservation(reference);

            _repo.Verify(q => q.CancelReservation(reference), Times.Once);
        }

        [TestMethod]
        public void service_should_find_reservation()
        {
            var reference = "123456";
            var expected = new Book();
            _repo.Setup(q => q.FindReservation(reference)).Returns(expected);

            var actual =_service.FindReservation(reference);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void service_should_get_all_reservations()
        {
            var expected = new Book[] { new Book(), new Book() };
            _repo.Setup(q => q.GetReservations()).Returns(expected);

            var actual = _service.GetReservations();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void service_should_return_only_available_cars()
        {
            var rented = new Car[] { new Car { Year = 2017 }, new Car { Year = 2018 } };
            var notRented = new Car[] { new Car { Year= 2016 }, new Car { Year = 2015 }, new Car { Year = 2014 } };
            var allCars = rented.Concat(notRented).ToArray();

            _repo.Setup(q => q.GetAllCars()).Returns(allCars);
            _repo.Setup(q => q.GetRentedCars()).Returns(rented);

            var actual = _service.GetAvailableCars();

            Assert.AreEqual(actual.Count(), notRented.Count());
            CollectionAssert.AreEqual(actual, notRented);
        }
    }
}
