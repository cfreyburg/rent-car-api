using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Abstractions.Repositories
{
    public interface IRentRepository
    {
        ICar[] GetAllCars();
        void Book(IBook rent);
        IBook[] GetReservations();
        IBook FindReservation(string bookReferenceNumber);
        ICar[] GetRentedCars();
        void CancelReservation(string bookReferenceNumber);
    }
}
