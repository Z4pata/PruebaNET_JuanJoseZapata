using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Models.DTOs;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Service
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _repository;
        public GuestService(IGuestRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(GuestDTO guest) 
        {
            var exist = await _repository.CheckExistByIdentification(guest.IdentificationNumber);

            if (exist)
            {
                Console.WriteLine("User already exist");
                return false;
            }


            var NewGuest = new Guest 
            {
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber,
                IdentificationNumber = guest.IdentificationNumber,
                BirthDate = guest.BirthDate

            };

            var created = await _repository.CreateAsync(NewGuest);

            return created;
        
        }
    }
}