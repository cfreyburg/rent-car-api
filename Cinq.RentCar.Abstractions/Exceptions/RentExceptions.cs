using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinq.RentCar.Abstractions.Exceptions
{
    public class RentExceptions
    {
        public class RentBadRequest : Exception
        {
            public RentBadRequest() { }

            public RentBadRequest(string message)
                : base(message)
            {

            }

            public IActionResult Result => new BadRequestResult();
        }

        public class RentNotFound : Exception
        {
            public RentNotFound() { }

            public RentNotFound(string message)
                : base(message)
            {
            }

            public IActionResult Result => new NotFoundResult();
        }
    }
}
