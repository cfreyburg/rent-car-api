using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Abstractions.Entities
{
    public class Driver : IDriver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
