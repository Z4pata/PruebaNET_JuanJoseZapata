using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Service
{
    public class BookingService : IBookingInterface
    {
        private readonly IBookingRepository _repository;
        private readonly IGuestRepository _guestRepo;
        public BookingService(IBookingRepository repository, IGuestRepository guestRepo)
        {
            _repository = repository;
            _guestRepo = guestRepo;
        }

        public async Task<ICollection<Booking>?> AllBooksByIdentificationOfGuest(string IdentificationNumber)
        {
            var bookings = await _repository.GetBookingsAsync();

            var existGuest = await _guestRepo.CheckExistByIdentification(IdentificationNumber);

            if (!existGuest)
            {
                return null;
            }

            var matched = bookings.Where(b => b.Guest?.IdentificationNumber == IdentificationNumber).ToList();

            return matched;
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            var exist = await _repository.CheckExistById(id);

            if (!exist)
            {
                return null;
            }

            var bookings = await _repository.GetBookingsAsync();

            var bookingMatched = bookings.FirstOrDefault(r => r.Id == id);

            return bookingMatched;
        }

        public async Task<bool> DeleteBooking(int id)
        {
            var booking = await GetBookingById(id);

            if (booking == null)
            {
                Console.WriteLine("reservation could not be deleted");
                return false;
            }

            booking.Room.Availability = true;

            await _repository.DeleteAsync(booking);

            return true;
        }
    }
}