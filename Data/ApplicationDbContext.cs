using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_JuanJoseZapata.Models;
using PruebaNET_JuanJoseZapata.Seeders;

namespace PruebaNET_JuanJoseZapata.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoomTypeSeeder.Seeder(modelBuilder);
        }
    }
}