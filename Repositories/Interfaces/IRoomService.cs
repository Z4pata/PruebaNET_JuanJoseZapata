using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IRoomService
    {
        Task<ICollection<Room>> GetRooms();
        Task<ICollection<Room>> GetAvailableRooms();
        Task<string> GetSummaryRooms();
        Task<Room?> GetRoomById(int id);

    }
}