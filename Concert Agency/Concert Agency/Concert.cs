using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Concert_Agency
{
    public class Concert : Entity
    {
        public string ConcertName { get; set; }
        public DateTime ConcertDate { get; set; }
        public ConcertOrganization ConcertOrganization { get; set; }
        public Venue Venue { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<ConcertArtist> ConcertArtists { get; set; } = new List<ConcertArtist>();
        public ICollection<ConcertManager> ConcertManagers { get; set; } = new List<ConcertManager>();
        public void Add(string ConcertName, DateTime ConcertDate, Venue Venue, double FinalReceipt)
        {
            this.ConcertName = ConcertName;
            this.ConcertDate = ConcertDate;
            this.Venue = Venue;
            ConcertOrganization = new ConcertOrganization();
            ConcertOrganization.Add(Id, FinalReceipt, Venue);
        }
    }
}
