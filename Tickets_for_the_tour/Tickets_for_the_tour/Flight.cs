using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Tickets_for_the_tour
{
    public class Flight : Entity
    {
        public int NumberFlights { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string DeparturePlace { get; set; }
        public string DestinationPlace { get; set; }
        public TimeSpan Duration { get; set; }
        public Ship Ship { get; set; }
        public Excursion Excursion { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public void Add(int NumberFlights, DateTime DepartureDateTime, string DeparturePlace, string DestinationPlace, TimeSpan Duration, Excursion Excursion,Ship Ship)
        {
            this.NumberFlights = NumberFlights;
            this.DepartureDateTime = DepartureDateTime;
            this.DeparturePlace = DeparturePlace;
            this.DestinationPlace = DestinationPlace;
            this.Duration = Duration;
            this.Excursion = Excursion;
            this.Ship = Ship;
        }

    }
}
