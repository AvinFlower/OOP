using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Concert_Agency
{
    public class RiderRequest : Entity
    {
        public string RiderNumber { get; set; }
        public string RiderParameters { get; set; }
        public Guid RiderId { get; set; }
        public Rider Rider { get; set; }

        public Guid TechnicalParametersId { get; set; }
        public TechnicalParameters TechnicalParameters { get; set; }
        public void Add(string RiderNumber, string RiderParameters, Rider Rider, TechnicalParameters TechnicalParameters)
        {
            this.RiderNumber = RiderNumber;
            this.RiderParameters = RiderParameters;
            this.Rider = Rider;
            this.TechnicalParameters = TechnicalParameters;
        }
    }
}
