using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_for_the_tour;

namespace form_Excursion
{
    public partial class Add_Ticket : Form
    {
        private readonly TourContext _dbContext;
        public int SelectedFlightNumber { get; private set; }
        public string SelectedExcursionVariant { get; set; }
        public Add_Ticket()
        {
            InitializeComponent();
            _dbContext = new TourContext();
            var excursions = _dbContext.Excursions.ToList();

            comboBox1.Items.Clear();

            foreach (var excursion in excursions)
            {
                comboBox1.Items.Add(excursion.ExcursionVariants);
            }

            var pessenger = _dbContext.Passes.ToList();
            foreach (var pesses in pessenger)
            {
                comboBox3.Items.Add($"{pesses.LastName} {pesses.FirstName} {pesses.MiddleName}");
            }
        }

        private void Add_Ticket_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal excursionPrice = GetExcursionPrice(SelectedExcursionVariant);
            int Number = CountTicketsInDatabase();
            Flight selectedFlight = FindFlightByNumber(SelectedFlightNumber);
            Passenger selectedPassenger = FindPassengerByName(comboBox3.SelectedItem.ToString());


            Ticket ticket = new Ticket();
            ticket.Add(Number + 1, excursionPrice, DateTime.Now.ToUniversalTime(), PaymentMethod.DebitCard.ToString(), selectedPassenger, selectedFlight);
            _dbContext.Tickets.Add(ticket);

            _dbContext.SaveChanges();
            MessageBox.Show("Билет №" + ticket.NumberTicket + " успешно куплен на рейс " + selectedFlight.NumberFlights + "\n" + "время отправления " + selectedFlight.DepartureDateTime + "\n" + "место отправления " + selectedFlight.DeparturePlace + "\n" + "пассажир " + selectedPassenger.FirstName + " " + selectedPassenger.LastName + " " + selectedPassenger.MiddleName + "\n\n");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedExcursionVariant = comboBox1.SelectedItem.ToString();

            var flights = _dbContext.Flights
                .Include(f => f.Ship)
                .Include(f => f.Tickets)
                .Include(f => f.Excursion)
                .Where(f => f.Excursion.ExcursionVariants == SelectedExcursionVariant)
                .ToList();

            flights = flights.Where(flight => flight.Ship.Capacity - flight.Tickets.Count > 0).ToList();

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(flights.Select(f => $"№{f.NumberFlights} - {f.DepartureDateTime.ToUniversalTime()}").ToArray());



        }
        private decimal GetExcursionPrice(string excursionVariant)
        {
            var excursion = _dbContext.Excursions
                .FirstOrDefault(e => e.ExcursionVariants == excursionVariant);

            if (excursion != null)
            {
                return excursion.PriceExcursion;
            }
            return 0;
        }
        private int CountTicketsInDatabase()
        {
            return _dbContext.Tickets.Count();
        }
        private Flight FindFlightByNumber(int flightNumber)
        {
            return _dbContext.Flights.FirstOrDefault(f => f.NumberFlights == flightNumber);
        }
        private Passenger FindPassengerByName(string passengerName)
        {
            string[] names = passengerName.Split(' ');

            if (names.Length == 3)
            {
                string lastName = names[0];
                string firstName = names[1];
                string middleName = names[2];

                return _dbContext.Passes.FirstOrDefault(p =>
                    p.LastName == lastName && p.FirstName == firstName && p.MiddleName == middleName);
            }

            return null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox2.SelectedItem.ToString();
            int indexOfSeparator = selectedItem.IndexOf('-');
            if (indexOfSeparator > 0 && int.TryParse(selectedItem.Substring(1, indexOfSeparator - 1), out int flightNumber))
            {
                SelectedFlightNumber = flightNumber;
            }
        }
    }
}
