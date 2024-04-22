using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admin
{
    public partial class AddConcertArtist : Form
    {
        private readonly ConcertContext _dbContext;
        private AddValue mainForm;
        public AddConcertArtist(AddValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void AddConcertArtist_Load(object sender, EventArgs e)
        {
            var concerts = _dbContext.Concert;

            foreach (var concert in concerts)
            {
                string concertInfo = $"{concert.ConcertName}, {concert.ConcertDate.ToString("yyyy-MM-dd HH:mm:ss")}";
                comboBox1.Items.Add(new ComboBoxItem(concertInfo, concert.Id));
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            var artists = _dbContext.Artist;

            foreach (var artist in artists)
            {
                string managerInfo = $"{artist.FirstName}, {artist.LastName}, {artist.MiddleName}, {artist.PassportData}";
                comboBox2.Items.Add(new ComboBoxItem(managerInfo, artist.Id));
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string concert = comboBox1.Text;
            string artist = comboBox2.Text;

            Guid selectedConcertId = GetConcertIdFromText(concert);
            Guid selectedArtistId = GetArtistIdFromText(artist);


            if (selectedConcertId != Guid.Empty && selectedArtistId != Guid.Empty)
            {
                Concert selectedConcert = _dbContext.Concert.FirstOrDefault(c => c.Id == selectedConcertId);
                Artist selectedArtist = _dbContext.Artist.FirstOrDefault(m => m.Id == selectedArtistId);

                bool isArtistOccupied = _dbContext.ConcertArtist.Any(c =>
                    c.Artist == selectedArtist &&
                    c.Concert.ConcertDate == selectedConcert.ConcertDate);

                if (isArtistOccupied)
                {
                    MessageBox.Show($"Выбранный артист занят в это время и выступает на концерте {selectedConcert.ConcertDate}.");
                    return;
                }

                ConcertArtist concertArtist = new ConcertArtist
                {
                    Concert = selectedConcert,
                    Artist = selectedArtist,
                };

                _dbContext.ConcertArtist.Add(concertArtist);
                _dbContext.SaveChanges();

                MessageBox.Show("Артист на концерт успешно добавлен");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }

        private Guid GetConcertIdFromText(string selectedConcertText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedConcertText.Split(',');

            if (parts.Length >= 2)
            {
                string concertName = parts[0].Trim();
                string concertDate = parts[1].Trim();

                // Парсим строку даты и времени в объект DateTime
                DateTime concertDateTime;
                if (!DateTime.TryParseExact(concertDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out concertDateTime))
                {
                    return Guid.Empty;
                }
                concertDateTime = concertDateTime.AddHours(3);

                Concert concert = _dbContext.Concert.FirstOrDefault(c =>
                    c.ConcertName == concertName &&
                    c.ConcertDate == concertDateTime.ToUniversalTime());

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return concert?.Id ?? Guid.Empty;
            }

            // Если формат не соответствует ожидаемому, возвращаем Guid.Empty
            return Guid.Empty;
        }


        private Guid GetArtistIdFromText(string selectedArtistText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedArtistText.Split(',');

            if (parts.Length >= 3)
            {
                string firstName = parts[0].Trim();
                string lastName = parts[1].Trim();
                string middleName = parts[2].Trim();
                string passportData = parts[3].Trim();

                Artist artist = _dbContext.Artist.FirstOrDefault(m =>
                    m.FirstName == firstName &&
                    m.LastName == lastName &&
                    m.MiddleName == middleName &&
                    m.PassportData == passportData);

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return artist?.Id ?? Guid.Empty;
            }

            // Если формат не соответствует ожидаемому, возвращаем Guid.Empty
            return Guid.Empty;
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
