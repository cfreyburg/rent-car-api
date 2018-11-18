using Cinq.RentCar.Abstractions.DTOs;
using Cinq.RentCar.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using static Cinq.RentCar.Abstractions.Exceptions.RentExceptions;

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

        //TODO create global filter for handling exceptions

        [HttpPost]
        public IActionResult Post([FromBody]BookDTO book)
        {
            try
            {
                _service.Book(book);
            }
            catch (RentBadRequest e)
            {
                return e.Result;
            }
            catch (RentNotFound e)
            {
                return e.Result;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

            return new OkResult();
        }

        [HttpDelete("{referenceNumber}/cancel")]
        public IActionResult Delete(string referenceNumber)
        {
            try
            {
                _service.CancelReservation(referenceNumber);
            }
            catch (RentBadRequest e)
            {
                return e.Result;
            }
            catch (RentNotFound e)
            {
                return e.Result;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

            return new OkResult();
        }
    }
}
