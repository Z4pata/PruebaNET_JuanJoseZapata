using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Service
{
    public class RoomTypesService : IRoomTypesInterface
    {
        private readonly IRoomTypesRepository _repository;

        public RoomTypesService(IRoomTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<RoomType>> GetRoomTypes()
        {
            var roomsTypes = await _repository.GetRoomTypesAsync();
            var inOrder = roomsTypes.OrderBy(r => r.Id).ToList();

            return inOrder ;
        }

        public async Task<RoomType?> GetRoomTypesById(int id)
        {
            var exist = await _repository.CheckExistById(id);

            if (!exist)
            {
                return null;
            }

            var roomTypes = await _repository.GetRoomTypesAsync();

            var matched = roomTypes.FirstOrDefault(r => r.Id == id);

            return matched;
        }
        
    }
}