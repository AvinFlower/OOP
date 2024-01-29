using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class Artist : Person
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public ICollection<Rider> Riders { get; set; } = new List<Rider>();
        public ICollection<ConcertArtist> ConcertArtists { get; set; } = new List<ConcertArtist>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();


        public void Add(string? Email, string PhoneNumber, DateTime DateOfBirth, string Country, string FirstName, string LastName, string MiddleName, string PassportData)
        {
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.DateOfBirth = DateOfBirth;
            this.Country = Country;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.PassportData = PassportData;
        }
    }
}
