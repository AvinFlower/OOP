using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Concert_Agency
{
    public class Rider : Entity
    {
        public string Requirements { get; set; }
        public DateTime RiderDate { get; set; }
        public ICollection<RiderRequest> RidersRequests { get; set; } = new List<RiderRequest>();
        public Artist Artist { get; set; }
        public void Add(string Requirements, DateTime RiderDate, Artist Artist)
        {
            this.Requirements = Requirements;
            this.RiderDate = RiderDate;
            this.Artist = Artist;
        }
    }
}
