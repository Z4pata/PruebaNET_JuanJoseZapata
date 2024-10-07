using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Repositories.Interfaces
{
    public interface IAuth
    {
        Task<string?> AuthenticateAsync(string email, string password);
    }
}