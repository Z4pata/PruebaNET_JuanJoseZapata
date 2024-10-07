using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> CreateAsync(Employee employee);
        Task<ICollection<Employee>> GetEmployeesAsync();
        Task<Employee?> GetByEmailAsync(string email);
        Task<bool> CheckExistByIdentification(string IdentificationNumber);
    }
}