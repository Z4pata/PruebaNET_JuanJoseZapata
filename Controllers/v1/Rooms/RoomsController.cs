using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.Rooms
{
    [ApiController]
    [Route("api/v1/rooms")]
    public partial class RoomsController : ControllerBase
    {
        protected readonly IRoomInterface _service;

        public RoomsController(IRoomInterface service)
        {
            _service = service;
        }
    }
}