using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Abstractions.Services
{
    public interface IRentHelper
    {
        IBook GetBookEntity(BookDTO dto);
    }
}
