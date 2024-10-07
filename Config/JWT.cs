using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Config
{
    public class JWT
    {
        public static string GenerateJwtToken(Employee employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Name, employee.FirstName)
            };

            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new InvalidOperationException("JWT Key no encontrada");
            var jwtExpire = Environment.GetEnvironmentVariable("JWT_EXPIRES_IN") ?? throw new InvalidOperationException("JWT Expire no encontrado");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new InvalidOperationException("JWT Issuer no encontrado");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(jwtExpire)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}