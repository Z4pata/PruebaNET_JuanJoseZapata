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
    public class GuestRepository : IGuestRepository
    {
        private readonly ApplicationDbContext _context;

        public GuestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Guest guest)
        {
            try
            {
                _context.Guests.Add(guest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                Console.WriteLine("The Guest could not be saved in the database.");

                return false;
            }
        }

        public async Task<bool> CheckExistByIdentification(string IdentificationNumber)
        {
            return await _context.Guests.AnyAsync(g => g.IdentificationNumber == IdentificationNumber);
        }
    }
}