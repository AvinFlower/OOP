using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert_Agency
{
    public class ConcertContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Rider> Rider { get; set; }
        public DbSet<Concert> Concert { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<RiderRequest> RiderRequest { get; set; }
        public DbSet<ConcertManager> ConcertManager { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<OrganizationalRequest> OrganizationalRequest { get; set; }
        public DbSet<ConcertOrganization> ConcertOrganization { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ConcertArtist> ConcertArtist { get; set; }
        public DbSet<TechnicalParameters> TechnicalParameter { get; set; }
        public DbSet<Authentication> Authentication { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=concert;Username=postgres;Password=299NhbnjY");
            //optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Concert>()
            .HasOne(e => e.ConcertOrganization)
            .WithOne(e => e.Concert)
            .HasForeignKey<ConcertOrganization>(e => e.ID_Concert)
            .IsRequired();


            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderNum)
                .IsUnique();

            modelBuilder.Entity<Venue>()
                .HasIndex(v => new { v.VenueName, v.City, v.Country })
                .IsUnique();
        }
    }
}
