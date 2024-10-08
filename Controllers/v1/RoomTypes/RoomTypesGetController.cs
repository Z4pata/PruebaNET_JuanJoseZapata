using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.RoomTypes
{
    public partial class RoomTypesController 
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _service.GetRoomTypes();

            if (rooms.Count == 0)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await  _service.GetRoomTypesById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }
    }
}