using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Models
{
    [Table("rooms")]
    public class Room
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("room_number")]
        [StringLength(10)]
        [Required]
        public required string RoomNumber { get; set; }
        
        [Column("price_per_night")]
        [Required]
        public required double PricePerNight { get; set; }

        [Column("availability")]
        [Required]
        public required bool Availability { get; set; }

        [Column("max_occupancy_persons")]
        [Range(0, 5)]
        [Required]
        public required int MaxOccupancyPersons { get; set; }

        [Column("room_type_id")]
        [Required]
        public int RoomTypeId { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        public RoomType? RoomType { get; set; }

    }
}