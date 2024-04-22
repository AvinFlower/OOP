using Concert_Agency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class AddConcert : Form
    {
        private readonly ConcertContext _dbContext;
        private AddValue mainForm;
        private int selectedOrderNum;

        public AddConcert(AddValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker1.MinDate = DateTime.Now;
            numericUpDown1.DecimalPlaces = 5; // Устанавливает два знака после запятой
            numericUpDown1.Increment = 0.1m;  // Устанавливает шаг
        }

        private void AddConcert_Load(object sender, EventArgs e)
        {
            var venues = _dbContext.Venue;

            foreach (var venue in venues)
            {
                string venueInfo = $"{venue.VenueName},{venue.City},{venue.Country}";
                comboBox1.Items.Add(new ComboBoxItem(venueInfo, venue.Id));
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string concertName = textBox1.Text;
            DateTime concertDate = dateTimePicker1.Value.ToUniversalTime();
            string selectedVenueText = comboBox1.Text;
            double finalReceipt = (double)numericUpDown1.Value;

            if (finalReceipt < 0)
            {
                MessageBox.Show("Сумма должна быть положительной. Пожалуйста, введите корректные данные.");
                return;
            }
            if (string.IsNullOrEmpty(concertName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            Guid selectedVenueId = GetVenueIdFromText(selectedVenueText);

            if (selectedVenueId != Guid.Empty)
            {

                Venue venue = _dbContext.Venue.FirstOrDefault(v => v.Id == selectedVenueId);

                bool isVenueOccupied = _dbContext.Concert.Any(c => c.Venue == venue && c.ConcertDate.Date == concertDate.Date);
                if (isVenueOccupied)
                {
                    MessageBox.Show($"В выбранном месте '{venue.VenueName}' концерт уже запланирован на {dateTimePicker1.Value}. Выберите другую дату или место.");
                    return;
                }

                if (venue != null)
                {
                    // Создание нового объекта ConcertOrganization
                    ConcertOrganization concertOrganization = new ConcertOrganization
                    {
                        FinalReceipt = finalReceipt,
                        Venue = venue,
                    };

                    // Создание нового объекта Concert
                    Concert newConcert = new Concert
                    {
                        ConcertName = concertName,
                        ConcertDate = concertDate,
                        ConcertOrganization = concertOrganization,
                    };

                    newConcert.Venue = venue;

                    _dbContext.ConcertOrganization.Add(concertOrganization);
                    _dbContext.Concert.Add(newConcert);
                    _dbContext.SaveChanges();

                    MessageBox.Show("Концерт и организация концерта успешно добавлены в БД.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите место проведения.");
            }
        }

        private Guid GetVenueIdFromText(string selectedVenueText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedVenueText.Split(',');

            if (parts.Length == 3)
            {
                string venueName = parts[0].Trim();
                string city = parts[1].Trim();
                string country = parts[2].Trim();

                Venue venue = _dbContext.Venue.FirstOrDefault(v =>
                    v.VenueName == venueName &&
                    v.City == city &&
                    v.Country == country);

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return venue?.Id ?? Guid.Empty;
            }

            // Если формат не соответствует ожидаемому, возвращаем Guid.Empty
            return Guid.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }

        public class ComboBoxItem
        {
            public string Display { get; set; }
            public Guid Value { get; set; }

            public ComboBoxItem(string display, Guid value)
            {
                Display = display;
                Value = value;
            }

            public override string ToString()
            {
                return Display;
            }
        }
    }
}
