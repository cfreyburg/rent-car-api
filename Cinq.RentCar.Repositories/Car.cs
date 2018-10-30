using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Repositories
{
    public class Car : ICar
    {
        public int Year { get; set; }
        public EnumModel Model { get; set; }
        public EnumCategory Category { get; set ; }
    }
}
