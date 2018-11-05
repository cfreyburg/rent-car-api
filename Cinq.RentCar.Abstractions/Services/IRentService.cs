using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Abstractions.Services
{
    public interface IRentService
    {
        ICar[] GetAvailableCars();
        void Book(BookDTO rent);
        IBook[] GetReservations();
        IBook FindReservation(string bookReferenceNumber);
        void CancelReservation(string bookReferenceNumber);
    }
}
