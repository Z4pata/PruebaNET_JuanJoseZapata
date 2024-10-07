using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.RoomTypes
{
    [ApiController]
    [Route("api/v1/room_types")]
    public partial class RoomTypesController : ControllerBase
    {
        protected readonly IRoomTypesInterface _service;

        public RoomTypesController(IRoomTypesInterface service)
        {
            _service = service;
        }
        
    }
}