using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Column("email")]
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public required string Email { get; set; }

        [Column("identification_number")]
        [Required]
        [StringLength(20)]
        public required string IdentificationNumber { get; set; }

        [Column("password")]
        [Required]
        [StringLength(255)]
        public required string Password { get; set; }
    }
}