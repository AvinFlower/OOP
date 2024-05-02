using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Tickets_for_the_tour
{
    public class Excursion : Entity
    {
        public decimal PriceExcursion { get; set; }
        public string ExcursionVariants { get; set; }
        public Route Route { get; set; }
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();

        public void Add(string ExcursionVariants, decimal PriceExcursion, double Distance, string RouteName)
        {
            this.ExcursionVariants = ExcursionVariants;
            this.PriceExcursion = PriceExcursion;
            Route = new Route();
            Route.Add(Distance, RouteName, Id);
        }
    }
}
