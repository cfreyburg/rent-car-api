using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Entities;
using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Repositories;
using Cinq.RentCar.Abstractions.Services;
using System.Linq;

namespace Cinq.RentCar.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _repo;
        private readonly IRentHelper _helper;
        private readonly IRentValidationHelper _validation;


        public RentService(IRentRepository repo, IRentHelper helper, IRentValidationHelper validation)
        {
            _repo = repo;
            _helper = helper;
            _validation = validation;
        }

        public void Book(BookDTO rent)
        {
            _validation.ValidateBook(rent);

            var entity = _helper.GetBookEntity(rent);
            _repo.Book(entity);
        }

        public void CancelReservation(string bookReferenceNumber)
        {
            _validation.ValidateDelete(bookReferenceNumber);

            _repo.CancelReservation(bookReferenceNumber);
        }

        public IBook FindReservation(string bookReferenceNumber)
        {
            return _repo.FindReservation(bookReferenceNumber);
        }

        public ICar[] GetAvailableCars()
        {
            var rented = _repo.GetRentedCars();
            var all = _repo.GetAllCars();

            return all.Where(q => !rented.Contains(q)).ToArray();
        }

        public IBook[] GetReservations()
        {
            return _repo.GetReservations();
        }
    }
}
