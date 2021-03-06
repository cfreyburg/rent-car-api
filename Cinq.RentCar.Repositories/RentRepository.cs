﻿using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Repositories;
using System;
using System.Linq;

namespace Cinq.RentCar.Repositories
{
    public class RentRepository : IRentRepository
    {
        private IRepository _repository;
        public RentRepository(IRepository repository)
        {
            _repository = repository;
        }

        public void Book(IBook rent)
        {
            _repository.Books.Add(rent);
        }

        public void CancelReservation(string bookReferenceNumber)
        {
            var reservation = FindReservation(bookReferenceNumber);
            _repository.Books.Remove(reservation);
        }

        public IBook FindReservation(string bookReferenceNumber)
        {
            return _repository.Books.Where(q => q.BookReference == bookReferenceNumber).FirstOrDefault();
        }

        public ICar[] GetAllCars()
        {
            return _repository.Cars.ToArray();
        }

        public ICar[] GetRentedCars()
        {
            return _repository.Books.Where(q => q.DropoffDate < DateTime.Now).Select(q => q.Car).ToArray();
        }

        public IBook[] GetReservations()
        {
            return _repository.Books.ToArray();
        }
    }
}
