using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Models.DTOs
{
    public class GuestDTO
    {
        [StringLength(255, ErrorMessage = "Input too long")]
        public required string FirstName { get; set; }


        [StringLength(255, ErrorMessage = "Input too long")]
        public required string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Email Format is not valid")]
        public required string Email { get; set; }

        [StringLength(20, ErrorMessage = "Input too long")]
        public required string IdentificationNumber { get; set; }

        [Phone(ErrorMessage = "Phone format is not valid")]
        [StringLength(20, ErrorMessage = "Input too long")]
        public required string PhoneNumber { get; set; }

        
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$")] //regular expresion for the date yyyy-MM-dd
        public DateOnly? BirthDate { get; set; }
    }
}