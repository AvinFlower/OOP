using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tickets_for_the_tour
{
    internal class TourDbContext : DbContext
    {
        public DbSet<Ship> YourEntities { get; set; } // Замените YourEntity на свои собственные сущности

        private string _connectionString;

        public TourDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TourDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
