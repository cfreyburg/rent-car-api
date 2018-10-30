using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Repositories;
using Cinq.RentCar.Abstractions.Services;
using System;

namespace Cinq.RentCar.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _repo;
        public RentService(IRentRepository repo)
        {
            _repo = repo;
        }

        public void Book(IBook rent)
        {
            _repo.Book(rent);
        }

        public void CancelReservation(string bookReferenceNumber)
        {
            _repo.CancelReservation(bookReferenceNumber);
        }

        public IBook FindReservation(string bookReferenceNumber)
        {
            return _repo.FindReservation(bookReferenceNumber);
        }

        public ICar[] GetAvailableCars()
        {
            return _repo.GetAvailableCars();
        }

        public IBook[] GetReservations()
        {
            return _repo.GetReservations();
        }
    }
}
