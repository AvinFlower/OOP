using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tickets_for_the_tour
{
    public class Employee : Person
    {
        //public string Position{ get; set; }
        public override void Add(string LastName, string FirstName, string MiddleName, string PassportData, DateOnly BirthDate, string Position)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.PassportData = PassportData;
            this.Grachdanstvo = Position;
            this.BirthDate = BirthDate;
        }
    }
    public enum Position
    {
        Сaptain,
        Сashier,
        Сleaner,
        Waiter
    }
}
