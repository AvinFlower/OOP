using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Tickets_for_the_tour
{
    public class Ship : Entity
    {
        public string ShipName { get; set; }
        public double Speed { get; set; }
        public int Capacity { get; set; }
        public string ComfortLevel { get; set; }
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
        public void Add(string ShipName, double Speed, int Capacity, string ComfortLevel)
        {
            this.ShipName = ShipName;
            this.Speed = Speed;
            this.Capacity = Capacity;
            this.ComfortLevel = ComfortLevel;
        }
    }
    public enum ComfortLevel
    {
        Low = 1,
        Medium,
        High
    }
}
