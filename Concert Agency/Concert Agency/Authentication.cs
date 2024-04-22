using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class Authentication : Entity
    {
        public string username { get; set; }
        public string password { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }

        public void Add(string username, string password, Artist Artist)
        {
            this.username = username;
            this.password = password;
            this.Artist = Artist;
        }
    }
}
