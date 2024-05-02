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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace form_Excursion
{
    public partial class Form_Ticket : Form
    {
        public int SelectedFlightNumber { get; set; }
        public string SelectedExcursionVariant { get; set; }

        private readonly TourContext _dbContext;
        public Form_Ticket()
        {
            InitializeComponent();
            _dbContext = new TourContext();

            textBoxFirstName.KeyPress += textBoxFirstName_KeyPress;
            textBoxLastName.KeyPress += textBoxFirstName_KeyPress;
            textBoxMiddleName.KeyPress += textBoxFirstName_KeyPress;
            textBoxPassportData.KeyPress += textBoxPassportData_KeyPress;
            textBox1.KeyPress += textBoxFirstName_KeyPress;

        }

        private void Form_Ticket_Load(object sender, EventArgs e)
        {
            decimal excursionPrice = GetExcursionPrice(SelectedExcursionVariant);
            label6.Text = "Стоимость билета на экскурсию - " + excursionPrice;

            comboBox1.DataSource = Enum.GetValues(typeof(PaymentMethod));
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = textBoxFirstName.Text;
            string LastName = textBoxLastName.Text;
            string MiddleName = textBoxMiddleName.Text;
            string PassportData = textBoxPassportData.Text;
            DateOnly BirthDate = DateOnly.FromDateTime(dateTimePickerBirthDate.Value.Date);
            string Grachdanstvo = textBox1.Text;

            Passenger passenger = new Passenger();
            passenger.Add(FirstName, LastName, MiddleName, PassportData, BirthDate, Grachdanstvo);
            _dbContext.Passes.Add(passenger);


            int Number = CountTicketsInDatabase();

            Flight selectedFlight = FindFlightByNumber(SelectedFlightNumber);
            decimal excursionPrice = GetExcursionPrice(SelectedExcursionVariant);
            PaymentMethod selectedPaymentMethod = (PaymentMethod)comboBox1.SelectedItem;

            Ticket ticket = new Ticket();
            ticket.Add(Number + 1, excursionPrice, DateTime.Now.ToUniversalTime(), selectedPaymentMethod.ToString(), passenger, selectedFlight);
            _dbContext.Tickets.Add(ticket);

            _dbContext.SaveChanges();

            MessageBox.Show("Билет №" + ticket.NumberTicket + " успешно куплен на рейс " + selectedFlight.NumberFlights + "\n" + "время отправления " + selectedFlight.DepartureDateTime + "\n" + "место отправления " + selectedFlight.DeparturePlace + "\n" + "пассажир " + passenger.FirstName + " " + passenger.LastName + " " + passenger.MiddleName + "\n\n" + "сохраните этот билет чтобы не потерять");
            this.Close();
            //Form_Excursion formExcursion = new Form_Excursion();
            //formExcursion.ShowDialog();


        }
        private int CountTicketsInDatabase()
        {
            return _dbContext.Tickets.Count();
        }

        private Flight FindFlightByNumber(int flightNumber)
        {
            return _dbContext.Flights.FirstOrDefault(f => f.NumberFlights == flightNumber);
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

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ буквой
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Если введенный символ не является буквой и не является управляющим, 
                // то отменяем его ввод
                e.Handled = true;
            }
        }

        private void textBoxPassportData_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или управляющим символом (например, Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Если введенный символ не является цифрой и не является управляющим, 
                // то отменяем его ввод
                e.Handled = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
