using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Models.DTOs;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Service
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Create(EmployeeDTO dto)
        {
            var exist = await _repo.CheckExistByIdentification(dto.IdentificationNumber);

            if (exist)
            {
                Console.WriteLine("Employee already exist");
                return false;
            }

            var passwordHashed = HashPassword(dto.Password);
            var newEmployee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                IdentificationNumber = dto.IdentificationNumber,
                Password = passwordHashed
            };

            var created = await _repo.CreateAsync(newEmployee);

            return created;
        }

        public string HashPassword (string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        

    }
}