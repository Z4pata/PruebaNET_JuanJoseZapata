using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Models.DTOs;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IEmployeeInterface
    {
        Task<bool> Create(EmployeeDTO dto);
        
        string HashPassword (string password);
    }
}