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
    public partial class Edit_Flights : Form
    {
        public int SelectedFlightNumber { get; set; }
        public Edit_Flights(int flightNumber)
        {
            InitializeComponent();
            SelectedFlightNumber = flightNumber;

            // Получаем информацию о рейсе из базы данных
            using (TourContext db = new TourContext())
            {
                var flight = db.Flights
                    .Where(f => f.NumberFlights == SelectedFlightNumber)
                    .FirstOrDefault();

                if (flight != null)
                {
                    // Заполняем контролы формы данными из базы данных
                    textBox1.Text = flight.DeparturePlace;
                    textBox2.Text = flight.DestinationPlace;
                    numericUpDown1.Value = (decimal)flight.Duration.TotalDays;

                    // Заполняем ComboBox1 всеми доступными экскурсиями
                    var excursions = db.Excursions.ToList();
                    foreach (var excursion in excursions)
                    {
                        comboBox1.Items.Add(excursion.ExcursionVariants);
                    }

                    // Устанавливаем выбранную экскурсию в ComboBox1 по умолчанию
                    comboBox1.SelectedItem = flight.Excursion?.ExcursionVariants;

                    // Заполняем ComboBox2 всеми доступными теплоходами
                    var ships = db.Ships.ToList();
                    foreach (var ship in ships)
                    {
                        comboBox2.Items.Add(ship.ShipName);
                    }

                    // Устанавливаем выбранный теплоход в ComboBox2 по умолчанию
                    comboBox2.SelectedItem = flight.Ship?.ShipName;
                }
                else
                {
                    MessageBox.Show("Информация о выбранном рейсе не найдена в базе данных.");
                }
            }
        }

        private void Edit_Flights_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем значения из контролов формы
            string departurePlace = textBox1.Text;
            string destinationPlace = textBox2.Text;
            int duration = (int)numericUpDown1.Value;
            string selectedExcursionVariant = comboBox1.SelectedItem as string;
            string selectedShipName = comboBox2.SelectedItem as string;
            DateTime departureDateTime = dateTimePicker1.Value;

            // Установим Kind для departureDateTime в DateTimeKind.Utc
            departureDateTime = DateTime.SpecifyKind(departureDateTime, DateTimeKind.Utc);

            // Проверяем, что все данные выбраны
            if (selectedExcursionVariant != null && selectedShipName != null)
            {
                // Обновляем данные в базе данных
                using (TourContext db = new TourContext())
                {
                    try
                    {
                        // Находим выбранный рейс
                        var flightToUpdate = db.Flights.FirstOrDefault(f => f.NumberFlights == SelectedFlightNumber);

                        if (flightToUpdate != null)
                        {
                            // Обновляем данные рейса
                            flightToUpdate.DeparturePlace = departurePlace;
                            flightToUpdate.DestinationPlace = destinationPlace;
                            flightToUpdate.Duration = TimeSpan.FromDays(duration);
                            flightToUpdate.DepartureDateTime = departureDateTime;

                            // Находим выбранную экскурсию
                            var selectedExcursion = db.Excursions.FirstOrDefault(exc => exc.ExcursionVariants == selectedExcursionVariant);
                            if (selectedExcursion != null)
                            {
                                flightToUpdate.Excursion = selectedExcursion;
                            }

                            // Находим выбранный теплоход
                            var selectedShip = db.Ships.FirstOrDefault(ship => ship.ShipName == selectedShipName);
                            if (selectedShip != null)
                            {
                                flightToUpdate.Ship = selectedShip;
                            }

                            // Сохраняем изменения в базе данных
                            db.SaveChanges();

                            MessageBox.Show("Данные рейса успешно обновлены.");
                        }
                        else
                        {
                            MessageBox.Show("Выбранный рейс не найден в базе данных.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}. Подробности: {ex.InnerException?.Message ?? "подробностей нет"}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите экскурсию и теплоход для рейса.");
            }
        }
    }
}
