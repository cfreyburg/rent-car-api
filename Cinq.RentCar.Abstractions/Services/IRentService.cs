using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Abstractions.Services
{
    public interface IRentService
    {
        ICar[] GetAvailableCars();
        void Book(IBook rent);
        IBook[] GetReservations();
        IBook FindReservation(string bookReferenceNumber);
        void CancelReservation(string bookReferenceNumber);
    }
}
