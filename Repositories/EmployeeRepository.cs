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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                Console.WriteLine("The Employee could not be saved in the database.");

                return false;
            }
        }

        public async Task<ICollection<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> CheckExistByIdentification(string IdentificationNumber)
        {
            return await _context.Employees.AnyAsync(e => e.IdentificationNumber == IdentificationNumber);
        }
        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}