using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tickets_for_the_tour
{
    public class Attraction : Entity
    {
        public string AttractionAddress { get; set; }
        public string AttractionName { get; set; }
        //public RoutePoint? RoutePoint { get; set; }

        public ICollection<RoutePoint> RoutePoints { get; set; } = new List<RoutePoint>();

        public void Add(string AttractionAddress, string AttractionName, RoutePoint RoutePoint)
        {
            this.AttractionAddress = AttractionAddress;
            this.AttractionName = AttractionName;
            this.RoutePoints.Add(RoutePoint);
        }
    }
}
