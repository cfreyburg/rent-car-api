using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Exceptions;
using Cinq.RentCar.Abstractions.Repositories;
using Cinq.RentCar.Abstractions.Services;
using System.Linq;

namespace Cinq.RentCar.Service
{
    public class RentValidationHelper : IRentValidationHelper
    {
        private readonly IRentRepository _repo;
        public RentValidationHelper(IRentRepository repo)
        {
            _repo = repo;
        }

        public void ValidateBook(BookDTO rent)
        {
            if (rent == null)
                throw new RentExceptions.RentBadRequest("Book cannot be empty");

            ValidateAvailability(rent);
        }

        private void ValidateAvailability(BookDTO rent)
        {
            var rented = _repo.GetRentedCars();
            if (rented.Any(q => 
                q.Category == rent.Car.Category &&
                q.Model == rent.Car.Model &&
                q.Year == rent.Car.Year))
                throw new RentExceptions.RentNotFound("Selected car is not available");

        }

        public void ValidateDelete(string bookReferenceNumber)
        {
            if (string.IsNullOrEmpty(bookReferenceNumber))
                throw new RentExceptions.RentBadRequest("Book reference number is not valid ");

            var reservation = _repo.FindReservation(bookReferenceNumber);
            if (reservation == null)
                throw new RentExceptions.RentBadRequest("Reservation is not available");
        }
    }
}
