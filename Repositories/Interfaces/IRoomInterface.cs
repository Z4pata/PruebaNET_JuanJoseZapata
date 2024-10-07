using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IRoomInterface
    {
        Task<ICollection<Room>> GetRooms();
        Task<ICollection<Room>> GetAvailableRooms();
        Task<ICollection<Room>> GetOccupiedRooms();
        Task<string> GetSummaryRooms();
        Task<Room?> GetRoomById(int id);

    }
}