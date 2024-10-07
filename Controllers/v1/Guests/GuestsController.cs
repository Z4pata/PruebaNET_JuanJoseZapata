using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests")]
    public partial class GuestsController : ControllerBase
    {
        protected readonly IGuestService _service;

        public GuestsController(IGuestService service)
        {
            _service = service;
        }
    }
}