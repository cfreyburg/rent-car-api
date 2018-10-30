using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinq.RentCar.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly IRentService _service;
        public ReservationsController(IRentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IBook[] Get()
        {
            return _service.GetReservations();
        }
    }
}
