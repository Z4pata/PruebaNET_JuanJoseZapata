using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_JuanJoseZapata.Models.DTOs
{
    public class BookingDTO
    {
        public required DateTime StartDate { get; set; }
        public required double TotalCost { get; set; }
        public DateTime? EndDate { get; set; }
    }
}