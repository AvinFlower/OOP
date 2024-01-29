using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class OrganizationalRequest : Entity
    {
        public string OrganizationParameters { get; set; }
        public Guid TechnicalParametersId { get; set; }
        public TechnicalParameters TechnicalParameters { get; set; }
        public Guid VenueId { get; set; }
        public Venue Venue { get; set; }
        public void Add(string OrganizationParameters, TechnicalParameters TechnicalParameters, Venue Venue)
        {
            this.OrganizationParameters = OrganizationParameters;
            this.TechnicalParameters = TechnicalParameters;
            this.Venue = Venue;
        }
    }
}
