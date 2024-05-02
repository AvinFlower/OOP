using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_for_the_tour
{
    public abstract class Person : Entity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PassportData { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Grachdanstvo {  get; set; }

        public abstract void Add(string LastName, string FirstName, string MiddleName, string PassportData, DateOnly BirthDate, string Grachdanstvo);
    }
}
