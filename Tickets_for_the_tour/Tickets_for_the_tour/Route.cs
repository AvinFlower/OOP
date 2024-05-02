using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Tickets_for_the_tour
{
    public class Route : Entity
    {
        public Guid ID_Excursion { get; set; }
        public double Distance { get; set; }
        public string RouteName { get; set; }
        public Excursion Excursion { get; set; }
        public ICollection<RoutePoint> RoutePoints { get; set; } = new List<RoutePoint>();

        public void Add(double Distance, string RouteName, Guid ID_Excursion)
        {
            this.Distance = Distance;
            this.RouteName = RouteName;
            this.ID_Excursion = ID_Excursion;
        }
    }
}
