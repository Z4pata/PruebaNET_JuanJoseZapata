using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<ICollection<Booking>> GetBookingsAsync();
        Task<bool> CheckExistById(int id);
        Task<bool> CreateAsync(Booking booking);
        Task<bool> DeleteAsync(Booking booking);
    }
}