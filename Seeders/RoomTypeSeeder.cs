using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_JuanJoseZapata.Models;

namespace PruebaNET_JuanJoseZapata.Seeders
{
    public class RoomTypeSeeder : ModelBuilder
    {
        public static void Seeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType {Id = 1, Name = "single room", Description = "A cozy basic room with a single bed, ideal for single travelers."},
                new RoomType {Id = 2, Name = "Double Room", Description = "It offers flexibility with two single beds or a double bed, perfect for couples or friends."},
                new RoomType {Id = 3, Name = "Suite", Description = "Spacious and luxurious, with a king size bed and a separate living room, ideal for those seeking comfort and exclusivity."},
                new RoomType {Id = 4, Name = "Family Room", Description = "Designed for families, with additional space and several beds for a comfortable stay."}
            );
        }
        
    }
}