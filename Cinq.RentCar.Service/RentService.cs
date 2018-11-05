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

        public RentService(IRentRepository repo, IRentHelper helper)
        {
            _repo = repo;
            _helper = helper;
        }

        public void Book(BookDTO rent)
        {
            var entity = _helper.GetBookEntity(rent);
            _repo.Book(entity);
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
