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
    public partial class Add_Flight : Form
    {
        public Add_Flight()
        {
            InitializeComponent();
            using (TourContext db = new())
            {

                var excursions = db.Excursions.ToList();
                var ships = db.Ships.ToList();

                comboBox2.Items.Clear();
                comboBox1.Items.Clear();


                foreach (var excursion in excursions)
                {
                    comboBox1.Items.Add(excursion.ExcursionVariants);
                }
                foreach (var ship in ships)
                {
                    comboBox2.Items.Add(ship.ShipName);
                }

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";


                var flights = db.Flights.Select(x => x.NumberFlights).ToList();
                comboBox3.DataSource = flights;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Add_Flight_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TourContext db = new())
            {
                string otp = textBox1.Text;
                string prib = textBox2.Text;

                int time = (int)numericUpDown1.Value;

                DateTime departureTime = dateTimePicker1.Value;

                int numberOfShips = db.Ships.Count();
                numberOfShips = numberOfShips + 2;

                var selectedExcursionVariant = comboBox1.SelectedItem as string;
                var selectedExcursion = db.Excursions.FirstOrDefault(exc => exc.ExcursionVariants == selectedExcursionVariant);

                var selectedShipName = comboBox2.SelectedItem as string;
                var selectedShip = db.Ships.FirstOrDefault(ship => ship.ShipName == selectedShipName);


                if (selectedExcursion != null && selectedShip != null)
                {
                    var newFlight = new Flight();
                    newFlight.Add(numberOfShips, departureTime.ToUniversalTime(), otp, prib, TimeSpan.FromMinutes(time), selectedExcursion, selectedShip);

                    db.Flights.Add(newFlight);
                    db.SaveChanges();

                    MessageBox.Show("Рейс успешно добавлен.");
                }
                else
                {
                    MessageBox.Show("Выберите экскурсию и корабль.");
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли какой-либо элемент в ComboBox
            if (comboBox3.SelectedItem != null)
            {
                // Получаем выбранный номер рейса
                int selectedFlightNumber = (int)comboBox3.SelectedItem;

                // Используем контекст базы данных
                using (TourContext db = new TourContext())
                {
                    // Находим рейс для удаления по выбранному номеру
                    var flightToDelete = db.Flights.FirstOrDefault(f => f.NumberFlights == selectedFlightNumber);

                    // Проверяем, найден ли рейс
                    if (flightToDelete != null)
                    {
                        // Удаляем рейс из базы данных
                        db.Flights.Remove(flightToDelete);
                        db.SaveChanges();

                        // Обновляем ComboBox3, перезагружая данные из базы данных
                        var updatedFlights = db.Flights.Select(x => x.NumberFlights).ToList();
                        comboBox3.DataSource = updatedFlights;
                        comboBox3.SelectedIndex = -1; // Сбрасываем выбор после обновления

                        MessageBox.Show("Рейс успешно удален.");
                    }
                    else
                    {
                        MessageBox.Show("Выбранный рейс не найден.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите рейс для удаления.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                int selectedFlightNumber = (int)comboBox3.SelectedItem;
                Edit_Flights edit_Flights = new Edit_Flights(selectedFlightNumber);
                edit_Flights.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите рейс для редактирования.");
            }
        }
    }
}
