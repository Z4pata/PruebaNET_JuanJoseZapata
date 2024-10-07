using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IRoomsRepository
    {
        Task<ICollection<Room>> GetRoomsAsync();
        Task<bool> CheckExistById(int id);

    }
}