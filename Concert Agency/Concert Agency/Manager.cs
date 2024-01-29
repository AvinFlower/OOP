using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class Manager : Person
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<ConcertManager> ConcertManagers { get; set; } = new List<ConcertManager>();
        public void Add(string PhoneNumber, string Email, string FirstName, string LastName, string MiddleName, string PassportData)
        {
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.PassportData = PassportData;
        }
    }
}