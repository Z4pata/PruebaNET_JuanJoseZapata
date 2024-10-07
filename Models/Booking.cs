using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Models
{
    [Table("bookings")]
    public class Booking
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("start_date")]
        [Required]
        [DataType(DataType.DateTime)]
        public required DateTime StartDate { get; set; }

        [Column("total_cost")]
        [Required]
        public required double TotalCost { get; set; }
        
        [Column("end_date")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        // ---- Foreign Keys ----

        [Column("room_id")]
        [Required]
        public required int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room? Room { get; set; }

        // -------------

        [Column("guest_id")]
        [Required]
        public required int GuestId { get; set; }

        [ForeignKey(nameof(GuestId))]
        public Guest? Guest { get; set; }

        // -------------

        // -------------

        [Column("employee_id")]
        [Required]
        public required int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        // -------------

    }
}