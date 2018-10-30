using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinq.RentCar.Abstractions.Models
{
    public interface IRepository
    {
        List<ICar> Cars { get; set; }
        List<IBook> Books { get; set; }
        List<IDriver> Drivers { get; set; }
    }
}
