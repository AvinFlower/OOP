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
    public partial class AddOrder : Form
    {
        private readonly ConcertContext _dbContext;
        private AddValue mainForm;
        public AddOrder(AddValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            var artists = _dbContext.Artist;

            foreach (var artist in artists)
            {
                string artistInfo;
                if (string.IsNullOrEmpty(artist.MiddleName)) artistInfo = $"{artist.FirstName}, {artist.LastName}, {artist.Country}";
                else artistInfo = $"{artist.FirstName}, {artist.LastName}, {artist.MiddleName}, {artist.Country}";
                comboBox1.Items.Add(new ComboBoxItem(artistInfo, artist.Id));
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            var managers = _dbContext.Manager;

            foreach (var manager in managers)
            {
                string managerInfo;
                if (string.IsNullOrEmpty(manager.MiddleName)) managerInfo = $"{manager.FirstName}, {manager.LastName}, {manager.PassportData}";
                else managerInfo = managerInfo = $"{manager.FirstName}, {manager.LastName}, {manager.MiddleName}, {manager.PassportData}";
                comboBox2.Items.Add(new ComboBoxItem(managerInfo, manager.Id));
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            comboBox3.Items.Add("Preparation");
            comboBox3.Items.Add("In Process");
            comboBox3.Items.Add("Completed");
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime orderDate = dateTimePicker1.Value.ToUniversalTime();
            string orderStatus = comboBox3.Text;
            string artist = comboBox1.Text;
            string manager = comboBox2.Text;

            if (string.IsNullOrEmpty(orderStatus))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            Guid selectedArtistId = GetArtistIdFromText(artist);
            Guid selectedManagerId = GetManagerIdFromText(manager);


            if (selectedArtistId != Guid.Empty && selectedManagerId != Guid.Empty)
            {
                Artist selectedArtist = _dbContext.Artist.FirstOrDefault(a => a.Id == selectedArtistId);
                Manager selectedManager = _dbContext.Manager.FirstOrDefault(m => m.Id == selectedManagerId);

                uint maxOrderNum = _dbContext.Order.Any() ? _dbContext.Order.Max(o => o.OrderNum) : 0;
                Order order = new Order
                {
                    OrderNum = maxOrderNum + 1,
                    OrderDate = orderDate,
                    OrderStatus = orderStatus,
                    Artist = selectedArtist,
                    Manager = selectedManager,
                };

                _dbContext.Order.Add(order);
                _dbContext.SaveChanges();

                MessageBox.Show("Заказ добавлен в БД");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }

        private Guid GetArtistIdFromText(string selectedArtistText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedArtistText.Split(',');

            if (parts.Length == 3 || parts.Length == 4)
            {
                string firstName = parts[0].Trim();
                string lastName = parts[1].Trim();
                string middleName = parts[2].Trim();
                string country = parts[3].Trim();

                Artist artist = _dbContext.Artist.FirstOrDefault(m =>
                    m.FirstName == firstName &&
                    m.LastName == lastName &&
                    m.MiddleName == middleName &&
                    m.Country == country);

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return artist?.Id ?? Guid.Empty;
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
