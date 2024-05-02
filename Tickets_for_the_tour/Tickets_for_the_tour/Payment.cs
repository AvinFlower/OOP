using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Tickets_for_the_tour
{
    public class Payment : Entity
    {
        public Guid ID_Ticket { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public string PaymentMethod { get; set; }
        public Ticket Ticket { get; set; }

        public void Add(DateTime PaymentDateTime, string PaymentMethod, Guid ID_Ticket)
        {
            this.PaymentDateTime = PaymentDateTime;
            this.PaymentMethod = PaymentMethod;
            this.ID_Ticket = ID_Ticket;
        }
    }
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        Cash,
        BankTransfer
    }
}
