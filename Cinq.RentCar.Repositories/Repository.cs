using Cinq.RentCar.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinq.RentCar.Repositories
{
    public class Repository : IRepository
    {
        public List<ICar> Cars { get; set; } = new List<ICar> {
            new Car { Category = EnumCategory.Economy, Model =  EnumModel.Camaro, Year = 2000},
            new Car { Category = EnumCategory.Regular, Model =  EnumModel.Fusion, Year = 2010},
            new Car { Category = EnumCategory.Economy, Model =  EnumModel.Sentra, Year = 2015},
            new Car { Category = EnumCategory.Sport, Model =  EnumModel.Sonic, Year = 2004},
            new Car { Category = EnumCategory.Economy, Model =  EnumModel.Spark, Year = 2001}
        };

        public List<IBook> Books { get; set; } = new List<IBook>();

        public List<IDriver> Drivers { get; set; } = new List<IDriver> {
            new Driver { Age = 20, FirstName="Bruce", LastName="Wayne"},
            new Driver { Age = 22, FirstName="Peter", LastName="Parker"},
            new Driver { Age = 40, FirstName="Luke", LastName="Skywalker"}
        };
    }
}
