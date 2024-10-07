using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Models.DTOs
{
    public class EmployeeDTO
    {
        [StringLength(50, ErrorMessage = "Input too long")]
        public required string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Input too long")]
        public required string LastName { get; set; }

        [StringLength(255, ErrorMessage = "Input too long")]
        [EmailAddress(ErrorMessage = "Email format is not valid")]
        public required string Email { get; set; }

        [StringLength(20, ErrorMessage = "Input too long")]
        public required string IdentificationNumber { get; set; }

        [StringLength(255, ErrorMessage = "Input too long")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?])(?=.*[a-zA-Z0-9]).{8,}$", ErrorMessage = "The password needs: 8 characters, 1 special character, 1 char in upper case")]
        public required string Password { get; set; }
    }
}