using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Admin.Delete
{
    public partial class DeleteRider_RiderRequest : Form
    {
        private readonly ConcertContext _dbContext;
        private DeleteValue mainForm;

        public DeleteRider_RiderRequest(DeleteValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void DeleteRider_RiderRequest_Load(object sender, EventArgs e)
        {
            // Устанавливаем вид и сетку для ListView
            listView1.View = View.Details;
            listView1.GridLines = true;

            // Добавляем колонки
            listView1.Columns.Add("Номер Райдера", 100);
            listView1.Columns.Add("Требования Райдера", 200);
            listView1.Columns.Add("Дата Райдера", 150);

            // Получаем все записи RiderRequest из базы данных
            var riderRequests = _dbContext.RiderRequest.Include(rr => rr.Rider).ToList();

            // Создаем словарь для отслеживания уникальных RiderNumber
            var uniqueRiderNumbers = new HashSet<string>();

            // Добавляем каждую запись RiderRequest в ListView
            foreach (var riderRequest in riderRequests)
            {
                // Получаем номер Rider из RiderRequest по внешнему ключу RiderId
                Guid riderId = riderRequest.RiderId;
                var rider = _dbContext.Rider.FirstOrDefault(r => r.Id == riderId);

                if (rider != null)
                {
                    // Проверяем, содержится ли RiderNumber в словаре уникальных номеров
                    if (!uniqueRiderNumbers.Contains(riderRequest.RiderNumber))
                    {
                        // Добавляем RiderNumber в словарь уникальных номеров
                        uniqueRiderNumbers.Add(riderRequest.RiderNumber);

                        // Создаем новый элемент ListViewItem с номером Rider из RiderRequest
                        ListViewItem item = new ListViewItem(riderRequest.RiderNumber.ToString());

                        // Добавляем требования и дату Rider из таблицы Rider
                        item.SubItems.Add(rider.Requirements);
                        item.SubItems.Add(rider.RiderDate.ToString("yyyy-MM-dd HH:mm:ss"));

                        // Добавляем элемент в ListView
                        listView1.Items.Add(item);

                        // Создаем текст элемента ComboBox
                        string comboBoxItemText = $"Райдер №{riderRequest.RiderNumber}"; // Используем TicketNumber

                        // Создаем новый объект ComboBoxItem
                        ComboBoxItem comboBoxItem = new ComboBoxItem(comboBoxItemText, riderRequest.Id);

                        // Добавляем элемент в ComboBox
                        comboBox1.Items.Add(comboBoxItem);
                    }
                }
            }
            // Устанавливаем высоту ListView и ширину колонок
            listView1.Height = 270;
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // Автоматический размер колонки
            }

            // Если есть элементы в ComboBox, выбираем первый элемент
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем выбранный элемент из ComboBox
            if (comboBox1.SelectedItem != null)
            {
                // Получаем выбранный RiderRequest Id из ComboBoxItem
                Guid selectedRiderRequestId = ((ComboBoxItem)comboBox1.SelectedItem).Value;

                // Находим RiderRequest, связанный с выбранным Id
                var riderRequest = _dbContext.RiderRequest.FirstOrDefault(rr => rr.Id == selectedRiderRequestId);

                if (riderRequest != null)
                {
                    // Получаем номер Rider из RiderRequest
                    string riderNumber = riderRequest.RiderNumber;

                    // Находим все RiderRequest, связанные с выбранным номером Rider
                    var riderRequests = _dbContext.RiderRequest.Where(rr => rr.RiderNumber == riderNumber).ToList();

                    // Удаляем каждый RiderRequest из базы данных
                    foreach (var rr in riderRequests)
                    {
                        _dbContext.RiderRequest.Remove(rr);
                    }

                    // Сохраняем изменения в базе данных
                    _dbContext.SaveChanges();

                    // Находим Rider, связанный с RiderRequest
                    var rider = _dbContext.Rider.FirstOrDefault(r => r.Id == riderRequest.RiderId);

                    if (rider != null)
                    {
                        // Удаляем Rider из базы данных
                        _dbContext.Rider.Remove(rider);

                        // Сохраняем изменения в базе данных
                        _dbContext.SaveChanges();

                        // Выводим сообщение об успешном удалении Rider
                        MessageBox.Show($"Райдер с номером {riderNumber} успешно удален.");
                    }

                    // Обновляем ComboBox после удаления
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        // Если больше нет элементов в ComboBox, очищаем ListView
                        listView1.Items.Clear();
                    }

                    // Обновляем ListView после удаления
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.Text == riderNumber)
                        {
                            listView1.Items.Remove(item);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите Rider для удаления.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}