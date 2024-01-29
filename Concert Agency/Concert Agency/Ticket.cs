using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Concert_Agency
{
    public class Ticket : Entity
    {
        public string typePrice { get; set; }
        public DateTime buyDate { get; set; }
        public Concert Concert { get; set; }
        public void Add(string typePrice, DateTime buyDate, Concert Concert)
        {
            this.typePrice = typePrice;
            this.buyDate = buyDate;
            this.Concert = Concert;
        }
    }
}
