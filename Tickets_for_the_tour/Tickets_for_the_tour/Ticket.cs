using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Tickets_for_the_tour
{
    public class Ticket : Entity
    {
        public int NumberTicket { get; set; }
        public decimal TicketPrice { get; set; }
        //public int NumberTicket { get; set; }
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public Payment Payment { get; set; }
        public void Add(int NumberTicket,decimal TicketPrice, DateTime PaymentDateTime, string PaymentMethod, Passenger Passenger, Flight Flight)
        {
            this.NumberTicket = NumberTicket;
            this.TicketPrice = TicketPrice;
            Payment = new Payment();
            Payment.Add(PaymentDateTime, PaymentMethod, Id);
            this.Passenger = Passenger;
            this.Flight = Flight;
        }
    }
}
