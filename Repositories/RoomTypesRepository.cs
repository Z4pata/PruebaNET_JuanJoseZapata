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
    public class RoomTypesRepository : IRoomTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<RoomType>> GetRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }
    }
}