using Cinq.RentCar.Abstractions.Entities;
using System;

namespace Cinq.RentCar.Abstractions.DTOs
{
    public class BookDTO
    {
        public string BookReference { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropoffDate { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
        public bool HasAgeExtraFee { get; set; }
    }
}
