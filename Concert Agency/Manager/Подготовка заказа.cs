using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Manager
{
    public partial class Form2 : Form
    {
        private readonly ConcertContext _dbContext;
        private int selectedOrderNum;
        private Guid selectedVenueId;

        public Form2(int selectedOrderNum)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.selectedOrderNum = selectedOrderNum;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker1.MinDate = DateTime.Now;
            selectedVenueId = Guid.Empty;

            numericUpDown1.DecimalPlaces = 5; // Устанавливает два знака после запятой
            numericUpDown1.Increment = 0.1m;  // Устанавливает шаг
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var artistWithRiderRequest = _dbContext.Order
                .Where(order => order.OrderNum == selectedOrderNum)
                .Include(order => order.Artist)
                .ThenInclude(artist => artist.Riders)
                .FirstOrDefault();

            if (artistWithRiderRequest != null)
            {
                listView1.View = View.Details;
                listView1.GridLines = true;

                listView1.Columns.Add("Технические параметры");
                listView1.Columns.Add("Запрос Райдера");
                listView1.Columns.Add("Организационный запрос");

                var technicalParametersList = _dbContext.TechnicalParameter.ToList();

                foreach (var technicalParameter in technicalParametersList)
                {
                    var item = new ListViewItem(technicalParameter.AttributeParameters);

                    // Найти соответствующий RiderRequest для текущего TechnicalParameter
                    var riderRequest = _dbContext.RiderRequest
                        .Where(rr => rr.TechnicalParameters == technicalParameter &&
                                     rr.Rider.Artist == artistWithRiderRequest.Artist)
                        .FirstOrDefault();

                    // Найти соответствующий OrganizationalRequest для текущего TechnicalParameter и места проведения
                    var organizationalRequest = _dbContext.OrganizationalRequest
                        .Where(or => or.TechnicalParameters == technicalParameter &&
                                     or.VenueId == selectedVenueId)
                        .FirstOrDefault();

                    if (riderRequest != null)
                    {
                        item.SubItems.Add(riderRequest.RiderParameters);
                    }
                    else
                    {
                        item.SubItems.Add("");
                    }

                    if (organizationalRequest != null)
                    {
                        item.SubItems.Add(organizationalRequest.OrganizationParameters);
                    }
                    else
                    {
                        item.SubItems.Add("");
                    }

                    listView1.Items.Add(item);
                }

                listView1.Height = 270;
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = -2;
                }


                var venues = _dbContext.Venue.ToList();

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem is ComboBoxItem selectedVenueItem)
            {
                selectedVenueId = selectedVenueItem.Value;

                var organizationalRequests = _dbContext.OrganizationalRequest
                    .Where(or => or.VenueId == selectedVenueId)
                    .ToList();

                foreach (ListViewItem item in listView1.Items)
                {
                    var technicalParameter = _dbContext.TechnicalParameter
                        .FirstOrDefault(tp => tp.AttributeParameters == item.Text);

                    if (technicalParameter != null)
                    {
                        var correspondingOrganizationalRequest = organizationalRequests
                            .FirstOrDefault(or => or.TechnicalParameters == technicalParameter);

                        if (correspondingOrganizationalRequest != null)
                        {
                            // Update the OrganizationalRequest column
                            if (item.SubItems.Count > 2)
                            {
                                item.SubItems[2].Text = correspondingOrganizationalRequest.OrganizationParameters;
                            }
                            else
                            {
                                item.SubItems.Add(correspondingOrganizationalRequest.OrganizationParameters);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите место проведения перед обновлением организационных запросов.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteOrderFromDatabase();

            if (Owner is Form1 form1)
            {
                form1.RemoveOrderFromListView(selectedOrderNum);
            }
            Hide();
        }

        private void DeleteOrderFromDatabase()
        {
            var orderToDelete = _dbContext.Order.FirstOrDefault(order => order.OrderNum == selectedOrderNum);

            if (orderToDelete != null)
            {
                _dbContext.Order.Remove(orderToDelete);
                _dbContext.SaveChanges();
            }
        }
        private void button2_Click(object sender, EventArgs e)
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

            // Find VenueId based on the selected text
            Guid selectedVenueId = GetVenueIdFromText(selectedVenueText);

            if (selectedVenueId != Guid.Empty)
            {
                Venue selectedVenue = _dbContext.Venue.FirstOrDefault(v => v.Id == selectedVenueId);

                // Загрузка места проведения из базы данных
                Venue venue = _dbContext.Venue.FirstOrDefault(v => v.Id == selectedVenueId);

                bool isVenueOccupied = _dbContext.Concert.Any(c => c.Venue == selectedVenue && c.ConcertDate.Date == concertDate.Date);
                if (isVenueOccupied)
                {
                    MessageBox.Show($"В выбранном месте '{selectedVenue.VenueName}' концерт уже запланирован на {dateTimePicker1.Value}. Выберите другую дату или место.");
                    return;
                }

                if (venue != null)
                {
                    var orderToUpdate = _dbContext.Order.FirstOrDefault(order => order.OrderNum == selectedOrderNum);

                    orderToUpdate.OrderStatus = "In Process";

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

                    // Установка связи между Concert и Venue
                    newConcert.Venue = venue;

                    // Добавление нового концерта и связанных объектов в контекст базы данных
                    _dbContext.ConcertOrganization.Add(concertOrganization);
                    _dbContext.Concert.Add(newConcert);

                    // Сохранение изменений в базе данных
                    _dbContext.SaveChanges();

                    if (Owner is Form1 form1)
                    {
                        form1.RemoveOrderFromListView(selectedOrderNum);
                    }

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите место проведения.");
            }
        }


        // VenueId From comboBox1
        private Guid GetVenueIdFromText(string selectedVenueText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedVenueText.Split(',');

            if (parts.Length == 3)
            {
                // Извлекаем название места проведения, город и страну
                string venueName = parts[0].Trim();
                string city = parts[1].Trim();
                string country = parts[2].Trim();

                // Ищем в базе данных Venue с соответствующими значениями
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
