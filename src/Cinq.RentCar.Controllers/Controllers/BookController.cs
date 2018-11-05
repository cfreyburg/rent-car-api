using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinq.RentCar.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IRentService _service;
        public BookController(IRentService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Post([FromBody]BookDTO book)
        {
            _service.Book(book);
        }

        [HttpDelete("{referenceNumber}/cancel")]
        public void Delete(string referenceNumber)
        {
            _service.CancelReservation(referenceNumber);
        }
    }
}
