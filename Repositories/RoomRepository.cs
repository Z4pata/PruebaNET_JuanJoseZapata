using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_JuanJoseZapata.Data;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Repositories
{
    public class RoomRepository : IRoomsRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.Include(r => r.RoomType).ToListAsync();
        }
        public async Task<bool> CheckExistById(int id)
        {
            return await _context.Rooms.AnyAsync(r => r.Id == id);
        }

    }
}