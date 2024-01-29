using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert_Agency
{
    public class ConcertArtist : Entity
    {
        public Guid ConcertId { get; set; }
        public Concert Concert { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }

        public void Add(Concert Concert, Artist Artist)
        {
            this.Concert = Concert;
            this.Artist = Artist;
        }
    }
}
