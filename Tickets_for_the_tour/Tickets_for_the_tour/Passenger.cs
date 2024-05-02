using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Tickets_for_the_tour
{
    public class Passenger : Person
    {
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public override void Add(string LastName, string FirstName, string MiddleName, string PassportData, DateOnly BirthDate, string Grachdanstvo)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.PassportData = PassportData;
            this.BirthDate = BirthDate;
            this.Grachdanstvo = Grachdanstvo;
        }
    }
}
