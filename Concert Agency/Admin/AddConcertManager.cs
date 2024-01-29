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
    public partial class AddConcertManager : Form
    {
        private readonly ConcertContext _dbContext;
        private Main mainForm;
        public AddConcertManager(Main mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void AddConcertManager_Load(object sender, EventArgs e)
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

            var managers = _dbContext.Manager;

            foreach (var manager in managers)
            {
                string managerInfo = $"{manager.FirstName}, {manager.LastName}, {manager.MiddleName}, {manager.PassportData}";
                comboBox2.Items.Add(new ComboBoxItem(managerInfo, manager.Id));
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string concert = comboBox1.Text;
            string duties = textBox1.Text;
            string manager = comboBox2.Text;

            if (string.IsNullOrEmpty(duties))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            Guid selectedConcertId = GetConcertIdFromText(concert);
            Guid selectedManagerId = GetManagerIdFromText(manager);


            if (selectedConcertId != Guid.Empty && selectedManagerId != Guid.Empty)
            {
                Concert selectedConcert = _dbContext.Concert.FirstOrDefault(c => c.Id == selectedConcertId);
                Manager selectedManager = _dbContext.Manager.FirstOrDefault(m => m.Id == selectedManagerId);

                bool isManagerOccupied = _dbContext.ConcertManager.Any(c =>
                    c.Manager == selectedManager &&
                    c.Concert.ConcertDate == selectedConcert.ConcertDate);

                if (isManagerOccupied)
                {
                    MessageBox.Show($"Выбранный менеджер занят в это время и находится на концерте {selectedConcert.ConcertDate}.");
                    return;
                }

                ConcertManager concertManager = new ConcertManager
                {
                    Concert = selectedConcert,
                    ConcertDuties = duties,
                    Manager = selectedManager,
                };

                _dbContext.ConcertManager.Add(concertManager);
                _dbContext.SaveChanges();

                MessageBox.Show("Менеджер на концерт успешно добавлен");
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


        private Guid GetManagerIdFromText(string selectedManagerText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedManagerText.Split(',');

            if (parts.Length == 3 || parts.Length == 4)
            {
                string firstName = parts[0].Trim();
                string lastName = parts[1].Trim();
                string middleName = parts[2].Trim();
                string passportData = parts[3].Trim();

                Manager manager = _dbContext.Manager.FirstOrDefault(m =>
                    m.FirstName == firstName &&
                    m.LastName == lastName &&
                    m.MiddleName == middleName &&
                    m.PassportData == passportData);

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return manager?.Id ?? Guid.Empty;
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
