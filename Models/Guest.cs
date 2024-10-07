using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Models
{
    [Table("guests")]
    public class Guest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("first_name")]
        [Required]
        [StringLength(255)]
        public required string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [StringLength(255)]
        public required string LastName { get; set; }

        [Column("email")]
        [Required]
        public required string Email { get; set; }

        [Column("identification_number")]
        [Required]
        [StringLength(20)]
        public required string IdentificationNumber { get; set; }

        [Column("phone_number")]
        [Required]
        [StringLength(20)]
        public required string PhoneNumber { get; set; }

        [Column("birthdate")]
        [DataType(DataType.Date)]
        public DateOnly? BirthDate { get; set; }

    }
}