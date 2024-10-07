using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.Bookings
{
    public partial class BookingsController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _service.GetBookingById(id);

            if (booking == null)
            {
                return NotFound();
            }

            var deleted = await _service.DeleteBooking(id);

            if (deleted == false)
            {
                return StatusCode(500, "An error occurred while creating the object.");
            }

            return Ok("The booking has been deleted");
        }
    }
}