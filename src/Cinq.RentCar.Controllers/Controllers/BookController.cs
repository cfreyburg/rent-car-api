using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinq.RentCar.Controllers.Controllers
{
    public class BookController : Controller
    {
        private readonly IRentService _service;
        public BookController(IRentService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Post(IBook book)
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
