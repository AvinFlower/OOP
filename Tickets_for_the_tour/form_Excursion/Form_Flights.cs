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
    public partial class Form_Flights : Form
    {
        public int SelectedFlightNumber { get; private set; }
        public string SelectedExcursionVariant { get; set; }
        private readonly TourContext _dbContext;
        public DateTime SelectedDepartureDateTime { get; private set; }
        public Form_Flights()
        {
            InitializeComponent();
            _dbContext = new TourContext();
        }

        private void Form_Flights_Load(object sender, EventArgs e)
        {
            var flights = _dbContext.Flights
                .Include(f => f.Ship)
                .Include(f => f.Tickets)
                .Include(f => f.Excursion)
                .Where(f => f.Excursion.ExcursionVariants == SelectedExcursionVariant)
                .ToList();
            int i = 1;
            flights = flights.Where(flight => flight.Ship.Capacity - flight.Tickets.Count > 0).ToList();

            foreach (var flight in flights)
            {
                int availableTickets = flight.Ship.Capacity - flight.Tickets.Count;

                if (availableTickets > 0)
                {
                    textBox1.Text += $"\r\nРейс №{flight.NumberFlights}: Время отправления: {flight.DepartureDateTime}, " +
                                     $"Место отправления: {flight.DeparturePlace}, Место назначения: {flight.DestinationPlace}, " +
                                     $"Продолжительность: {flight.Duration}, Доступные билеты: {availableTickets}\r\n";
                    i++;
                }
            }



            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(flights.Select(f => $"№{f.NumberFlights} - {f.DepartureDateTime.ToUniversalTime()}").ToArray());

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
            int indexOfSeparator = selectedItem.IndexOf('-');
            if (indexOfSeparator > 0 && int.TryParse(selectedItem.Substring(1, indexOfSeparator - 1), out int flightNumber))
            {
                SelectedFlightNumber = flightNumber;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                // Рейс не выбран, отобразить сообщение или выполнить подходящее действие
                MessageBox.Show("Пожалуйста, выберите рейс перед продолжением.");
                return;
            }

            _dbContext.SaveChanges();
            RefreshFlightsData();
            Form_Ticket formTicket = new Form_Ticket();
            formTicket.SelectedFlightNumber = SelectedFlightNumber;
            formTicket.SelectedExcursionVariant = SelectedExcursionVariant;
            formTicket.ShowDialog();
            this.Close();
        }
        private void RefreshFlightsData()
        {
            // Повторно загружаем данные рейсов
            var flights = _dbContext.Flights
                .Include(f => f.Excursion)
                .Where(f => f.Excursion.ExcursionVariants == SelectedExcursionVariant)
                .ToList();

            textBox1.Clear();
            textBox1.Text += "Рейсы:\r\n";

            foreach (var flight in flights)
            {
                textBox1.Text += $"\r\nРейс №{flight.NumberFlights}: Время отправления: {flight.DepartureDateTime}, " +
                                 $"Место отправления: {flight.DeparturePlace}, Место назначения: {flight.DestinationPlace}, " +
                                 $"Продолжительность: {flight.Duration}\r\n";


            }
        }
    }
}
