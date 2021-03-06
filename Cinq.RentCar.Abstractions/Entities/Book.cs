﻿using Cinq.RentCar.Abstractions.Models;
using System;

namespace Cinq.RentCar.Abstractions.Entities
{
    public class Book : IBook
    {
        public string BookReference { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropoffDate { get; set; }
        public ICar Car { get; set; }
        public IDriver Driver { get; set; }
        public bool HasAgeExtraFee { get; set; }
    }
}
