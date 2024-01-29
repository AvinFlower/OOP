using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Concert_Agency
{
    public class Order : Entity
    {
        public uint OrderNum { get; set; }
        public DateTime OrderDate { get; set; }

        [OrderStatusValidation]
        public string OrderStatus { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }
        public void Add(uint OrderNum, DateTime OrderDate, string OrderStatus, Artist Artist, Manager Manager)
        {
            this.OrderNum = OrderNum;
            this.OrderDate = OrderDate;
            this.OrderStatus = OrderStatus;
            this.Artist = Artist;
            this.Manager = Manager;
        }
    }

    public class OrderStatusValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] allowedValues = { "Preparation", "In Process", "Completed" };
            string orderStatus = (string)value;

            if (Array.IndexOf(allowedValues, orderStatus) == -1)
            {
                return new ValidationResult("Invalid OrderStatus. Allowed values are Preparation, In Process, Completed.");
            }

            return ValidationResult.Success;
        }
    }
}
