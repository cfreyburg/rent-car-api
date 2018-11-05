using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinq.RentCar.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly IRentService _service;
        public CarsController(IRentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ICar[] Get()
        {
            return _service.GetAvailableCars();
        }
    }
}
