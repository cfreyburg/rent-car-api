using Cinq.RentCar.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinq.RentCar.Repositories
{
    public class Driver : IDriver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
