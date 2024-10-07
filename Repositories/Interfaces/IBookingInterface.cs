using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IBookingInterface
    {
        Task<ICollection<Booking>?> AllBooksByIdentificationOfGuest(string IdentificationNumber);
        Task<Booking?> GetBookingById(int id);
    }
}