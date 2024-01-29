using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class ConcertOrganization : Entity
    {
        public Guid ID_Concert { get; set; }
        public Concert Concert { get; set; }
        public double FinalReceipt { get; set; }
        public Venue Venue { get; set; }

        public void Add(Guid ID_Concert, double FinalReceipt, Venue Venue)
        {
            this.ID_Concert = ID_Concert;
            this.FinalReceipt = FinalReceipt;
            this.Venue = Venue;
        }
    }
}
