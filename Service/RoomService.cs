using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Service
{
    public class RoomService : IRoomInterface
    {
        private readonly IRoomsRepository _repository;

        public RoomService(IRoomsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Room>> GetRooms()
        {
            var rooms = await _repository.GetRoomsAsync();
            var inOrder = rooms.OrderBy(r => r.Id).ToList();

            return inOrder ;
        }

        public async Task<ICollection<Room>> GetAvailableRooms()
        {
            var rooms = await _repository.GetRoomsAsync();

            var availables = rooms.Where(r => r.Availability == true).ToList();

            return availables;
        }

        public async Task<ICollection<Room>> GetOccupiedRooms()
        {
            var rooms = await _repository.GetRoomsAsync();

            var availables = rooms.Where(r => r.Availability == false).ToList();

            return availables;
        }

        public async Task<string> GetSummaryRooms()
        {
            var rooms = await _repository.GetRoomsAsync();

            var availables = await GetAvailableRooms();

            var occupied = await GetOccupiedRooms();

            return $@"In the hotel we have a total of {rooms.Count} registered rooms, of which:
{occupied.Count} are occupied.
{availables.Count} are available.";
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