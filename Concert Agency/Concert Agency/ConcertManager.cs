using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class ConcertManager : Entity
    {
        public Concert Concert { get; set; }
        public string ConcertDuties { get; set; }
        public Manager Manager { get; set; }
        public void Add(Concert Concert, string ConcertDuties, Manager Manager)
        {
            this.Concert = Concert;
            this.ConcertDuties = ConcertDuties;
            this.Manager = Manager;
        }
    }
}
