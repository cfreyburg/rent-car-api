using Cinq.RentCar.Abstractions.DTOs;

namespace Cinq.RentCar.Abstractions.Services
{
    public interface IRentValidationHelper
    {
        void ValidateBook(BookDTO rent);

        void ValidateDelete(string bookReferenceNumber);
    }
}
