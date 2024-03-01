using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Carpool.Models;

namespace Carpool.Data
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext (DbContextOptions<CarpoolContext> options)
            : base(options)
        {
        }

        public DbSet<Carpool.Models.User> Users { get; set; } = default!;

        public DbSet<Carpool.Models.BookingRide>? BookingRide { get; set; }

        public DbSet<Carpool.Models.OfferRide>? OfferRide { get; set; }

        public DbSet<Carpool.Models.Location>? Location { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Cincinnati" },
                new Location { Id = 2, Name = "Indianapolis"},
                new Location { Id = 3, Name = "Chicago" },
                new Location { Id = 4, Name = "Madinson" },
                new Location { Id = 5, Name = "Minneapolis" }
                );
        }
    }
}
