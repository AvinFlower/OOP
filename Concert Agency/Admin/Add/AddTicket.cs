using Concert_Agency;
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
    public partial class AddTicket : Form
    {
        private readonly ConcertContext _dbContext;
        private AddValue mainForm;
        public AddTicket(AddValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void AddTicket_Load(object sender, EventArgs e)
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

            comboBox2.Items.Add("Стандарт, 199$");
            comboBox2.Items.Add("Комфорт, 399$");
            comboBox2.Items.Add("Первый класс, 699");
            comboBox2.Items.Add("VIP, 1249$");
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string typePrice = comboBox2.Text;
            string concert = comboBox1.Text;

            Guid selectedConcertId = GetConcertIdFromText(concert);

            if (selectedConcertId != Guid.Empty)
            {
                Concert selectedConcert = _dbContext.Concert.FirstOrDefault(c => c.Id == selectedConcertId);

                if (selectedConcert != null)
                {
                    Ticket ticket = new Ticket
                    {
                        TicketNumber = GenerateTicketNumber(), // Генерация номера билета
                        Concert = selectedConcert,
                        typePrice = typePrice,
                        buyDate = DateTime.UtcNow.ToUniversalTime()
                    };

                    _dbContext.Ticket.Add(ticket);
                    _dbContext.SaveChanges();

                    MessageBox.Show("Купленный билет добавлен в БД");
                }
                else
                {
                    MessageBox.Show("Концерт не найден");
                }
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

        private string GenerateTicketNumber()
        {
            // Генерируем случайное число для номера билета
            Random random = new Random();
            int ticketNumberInt = random.Next(1, 1000); // Генерация числа от 1 до 999

            // Преобразуем целое число в строку
            string ticketNumber = ticketNumberInt.ToString();

            // Проверяем, существует ли уже билет с таким номером в базе данных
            while (_dbContext.Ticket.Any(t => t.TicketNumber == ticketNumber))
            {
                // Если такой номер уже существует, генерируем новый
                ticketNumberInt = random.Next(1, 1000);
                ticketNumber = ticketNumberInt.ToString();
            }

            return ticketNumber;
        }
    }
}
