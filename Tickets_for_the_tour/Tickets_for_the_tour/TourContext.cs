using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_for_the_tour
{
    public class TourContext : DbContext
    {
        public TourContext() { }

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet <Excursion> Excursions { get; set;}
        public DbSet <Flight> Flights { get; set; }
        public DbSet <Passenger> Passes { get; set; }
        public DbSet <Payment> Payments { get; set; }
        public DbSet <Route> Routes { get; set; }
        public DbSet <RoutePoint> RoutePoints { get; set; }
        public DbSet <Ship> Ships { get; set; }
        public DbSet <Ticket> Tickets { get; set; }
        public DbSet <Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ticketstour;Username=postgres;Password=189176");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Excursion>()
            .HasOne(e => e.Route)
            .WithOne(e => e.Excursion)
            .HasForeignKey<Route>(e => e.ID_Excursion)
            .IsRequired();

            modelBuilder.Entity<Ticket>()
            .HasOne(e => e.Payment)
            .WithOne(e => e.Ticket)
            .HasForeignKey<Payment>(e => e.ID_Ticket)
            .IsRequired();
        }
    }
}
