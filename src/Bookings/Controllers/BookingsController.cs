using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookings.Models;
using System.Net.Http;
using Bookings.Helpers;

namespace Bookings.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController
    {
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Booking bookingMessage)
        {
            Guid returnValue = Guid.Empty;
            
            returnValue= BookingManagerProxyHelper.CallBooking(bookingMessage).Result;

            return new ObjectResult(returnValue);
        }


    }
}
