using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_JuanJoseZapata.Config;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Service
{
    public class AuthService : IAuth
    {
        private readonly IEmployeeRepository _repo;
        public AuthService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var employee = await _repo.GetByEmailAsync(email);

            if (employee == null || !VerifyPasswordHash(password, employee.Password))
            {
                return null;
            }


            var token = JWT.GenerateJwtToken(employee);

            return $"Welcome your token is: {token}";
        }

        private bool VerifyPasswordHash(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}