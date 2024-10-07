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
        [MinLength(6, ErrorMessage = "The document number should be at least 6 digits long.")]
        public required string IdentificationNumber { get; set; }

        [Phone(ErrorMessage = "Phone format is not valid")]
        [StringLength(20, ErrorMessage = "Input too long")]
        public required string PhoneNumber { get; set; }

        
        [DataType(DataType.Date)]
        public DateOnly? BirthDate { get; set; }
    }
}