using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings")]
    public partial class BookingsController : ControllerBase
    {
        private readonly IBookingInterface _service;

        public BookingsController(IBookingInterface service)
        {
            _service = service;
        }
    }
}