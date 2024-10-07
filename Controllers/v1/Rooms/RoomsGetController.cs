using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.Rooms
{
    public partial class RoomsController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _service.GetRooms();

            if (rooms.Count == 0)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var availableRooms = await _service.GetAvailableRooms();

            if (availableRooms.Count == 0)
            {
                return NotFound();
            }

            return Ok(availableRooms);
        }

        [HttpGet("occupied")]
        public async Task<IActionResult> GetOccupiedRooms()
        {
            var occupiedRooms = await _service.GetOccupiedRooms();

            if (occupiedRooms.Count == 0)
            {
                return NotFound();
            }

            return Ok(occupiedRooms);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = await _service.GetSummaryRooms();

            return Ok(summary);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await  _service.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }
    }
}