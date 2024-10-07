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
    }
}