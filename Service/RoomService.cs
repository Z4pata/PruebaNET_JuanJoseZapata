using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomsRepository _repository;

        public RoomService(IRoomsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Room>> GetRooms()
        {
            var rooms = await _repository.GetRoomsAsync();

            return rooms ;
        }

        public async Task<ICollection<Room>> GetAvailableRooms()
        {
            var rooms = await _repository.GetRoomsAsync();

            var availables = rooms.Where(r => r.Availability == true).ToList();

            return availables;
        }

        public async Task<string> GetSummaryRooms()
        {
            var rooms = await _repository.GetRoomsAsync();

            var availables = rooms.Where(r => r.Availability == true).Count();

            var unavailables = rooms.Count - availables;

            return $@"In the hotel we have a total of {rooms.Count} registered rooms, of which:
{unavailables} are occupied.
{availables} are available.";
        }

        public async Task<Room?> GetRoomById(int id)
        {
            var exist = await _repository.CheckExistById(id);

            if (!exist)
            {
                return null;
            }

            var rooms = await _repository.GetRoomsAsync();

            var roomMatched = rooms.FirstOrDefault(r => r.Id == id);

            return roomMatched;
        }


    }
}