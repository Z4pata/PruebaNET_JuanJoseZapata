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
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings
            .Include(b => b.Employee)
            .Include(b => b.Guest)
            .Include(b => b.Room)
            .ToListAsync();
        }

        public async Task<bool> CheckExistById(int id)
        {
            return await _context.Bookings.AnyAsync(r => r.Id == id);
        }

        public async Task<bool> CreateAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                Console.WriteLine("The Booking could not be saved in the database.");

                return false;
            }
        }

        public async Task<bool> DeleteAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {

                Console.WriteLine("The Booking could not be removed from the database.");

                return false;

            }
        }
    }
}