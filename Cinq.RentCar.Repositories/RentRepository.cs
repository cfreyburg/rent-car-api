using Cinq.RentCar.Abstractions.Models;
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
            if (reservation == null)
                throw new Exception("No reservation with this reference number");
            _repository.Books.Remove(reservation);
        }

        public IBook FindReservation(string bookReferenceNumber)
        {
            return _repository.Books.Where(q => q.BookReference == bookReferenceNumber).FirstOrDefault();
        }

        public ICar[] GetAvailableCars()
        {
            return _repository.Cars.ToArray();
        }

        public IBook[] GetReservations()
        {
            return _repository.Books.ToArray();
        }
    }
}
