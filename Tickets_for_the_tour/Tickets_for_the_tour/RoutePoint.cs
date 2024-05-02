using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_for_the_tour
{
    public class RoutePoint : Entity
    {
        public Route? Route { get; set; }
        public ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();
        public TimeSpan StopDuration { get; set; }
        public void Add(TimeSpan StopDuration, Route route)
        {
            this.StopDuration = StopDuration;
            this.Route = route;
        }
    }
}
