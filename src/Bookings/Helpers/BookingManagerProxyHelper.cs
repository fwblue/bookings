using Bookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Bookings.Helpers
{
    public static class BookingManagerProxyHelper
    {
        public static async Task<Guid> CallBooking(Booking booking)
        {
            Guid returnValue = Guid.Empty;

            var baseAddress = new Uri("http://localhost:50164/api/BookingManager");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                var stringBuffer = JsonConvert.SerializeObject(booking);
                using (var content = new StringContent(stringBuffer, System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync(baseAddress, content))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseTask = await response.Content.ReadAsStringAsync();

                        returnValue = Guid.Parse(responseTask);
                    }
                }
            }

            return returnValue;
        }
    }
}
