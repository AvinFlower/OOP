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
    public partial class Form_Admin : Form
    {
        private readonly TourContext dbContext;
        public Form_Admin()
        {
            InitializeComponent();
            dbContext = new TourContext();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Attractions add_attractions = new Add_Attractions();
            add_attractions.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Excursion add_excursion = new Add_Excursion();
            add_excursion.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_RoutPoint add_routpoint = new Add_RoutPoint();
            add_routpoint.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Ship add_ship = new Add_Ship();
            add_ship.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Employee add_employee = new Add_Employee();
            add_employee.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Flight add_flight = new Add_Flight();
            add_flight.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Ticket add_ticket = new Add_Ticket();
            add_ticket.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form_Excursion form_Excursion = new Form_Excursion();
            form_Excursion.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GenerateTicketStatistics();
        }

        private void GenerateTicketStatistics()
        {
            int totalTicketsSold = dbContext.Tickets.Count();
            decimal totalRevenue = dbContext.Tickets.Sum(ticket => ticket.TicketPrice);
            decimal averageTicketPrice = totalTicketsSold > 0 ? totalRevenue / totalTicketsSold : 0;

            // Получаем путь к папке "Загрузки"
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

            // Собираем полный путь к файлу
            string filePath = Path.Combine(downloadsFolder, "TicketStatistics.txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Ticket Sales Statistics");
                writer.WriteLine("------------------------");
                writer.WriteLine($"Total Tickets Sold: {totalTicketsSold}");
                writer.WriteLine($"Total Revenue: {totalRevenue} руб");
                writer.WriteLine($"Average Ticket Price: {averageTicketPrice:F2} руб");
            }

            MessageBox.Show("Ticket statistics generated and saved to file.");
        }
    }
}
