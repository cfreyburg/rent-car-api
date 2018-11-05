using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Entities;
using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Services;

namespace Cinq.RentCar.Service
{
    public class RentHelper : IRentHelper
    {
        public IBook GetBookEntity(BookDTO dto)
        {
            return new Book
            {
                BookReference = dto.BookReference,
                Car = dto.Car,
                Driver = dto.Driver,
                DropoffDate = dto.DropoffDate,
                HasAgeExtraFee = dto.HasAgeExtraFee,
                PickupDate = dto.PickupDate
            };
        }
    }
}
