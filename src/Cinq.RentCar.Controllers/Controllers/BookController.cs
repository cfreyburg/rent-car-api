using Cinq.RentCar.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinq.RentCar.Controllers.Controllers
{
    public class BookController : Controller
    {
        [HttpPost]
        //public IBook Post(IBook book)
        public void Post()
        {
            //return _logic.Add(book);
        }

        [HttpDelete("{referenceNumber}/cancel")]
        public void Delete(int referenceNumber)
        {
            //_logic.Delete(book);
        }
    }
}
