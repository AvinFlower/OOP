using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class Venue : Entity
    {
        public string VenueName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<ConcertOrganization> ConcertOrganizations { get; set; } = new List<ConcertOrganization>();
        public ICollection<OrganizationalRequest> OrganizationalRequests { get; set; } = new List<OrganizationalRequest>();
        public void Add(string VenueName, string City, string Country)
        {
            this.VenueName = VenueName;
            this.City = City;
            this.Country = Country;
        }
    }
}
