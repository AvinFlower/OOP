using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin.Delete
{
    public partial class DeleteTicket : Form
    {
        private readonly ConcertContext _dbContext;
        private DeleteValue mainForm;
        public DeleteTicket(DeleteValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void DeleteTicket_Load(object sender, EventArgs e)
        {
            // Устанавливаем вид и сетку для ListView
            listView1.View = View.Details;
            listView1.GridLines = true;

            // Добавляем колонки
            listView1.Columns.Add("Требования Rider", 200);
            listView1.Columns.Add("Дата Rider", 150);

            // Получаем все билеты из базы данных
            var tickets = _dbContext.Ticket.Include(t => t.Concert).ToList();

            // Добавляем каждый билет в ListView
            foreach (var ticket in tickets)
            {
                // Создаем новый элемент ListViewItem
                ListViewItem item = new ListViewItem(ticket.TicketNumber.ToString()); // Используем TicketNumber

                // Добавляем остальные подэлементы
                item.SubItems.Add(ticket.typePrice);
                item.SubItems.Add(ticket.buyDate.ToString("yyyy-MM-dd HH:mm:ss"));

                // Проверяем, что концерт не null
                if (ticket.Concert != null)
                {
                    // Добавляем название концерта и его дату
                    item.SubItems.Add(ticket.Concert.ConcertName);
                    item.SubItems.Add(ticket.Concert.ConcertDate.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    item.SubItems.Add("Unknown"); // Если концерт не указан, отображаем "Unknown"
                    item.SubItems.Add("Unknown");
                }

                // Добавляем элемент в ListView
                listView1.Items.Add(item);

                // Создаем текст элемента ComboBox
                string comboBoxItemText = $"Билет №{ticket.TicketNumber}"; // Используем TicketNumber

                // Создаем новый объект ComboBoxItem
                ComboBoxItem comboBoxItem = new ComboBoxItem(comboBoxItemText, ticket.Id);

                // Добавляем элемент в ComboBox
                comboBox1.Items.Add(comboBoxItem);
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
            // Проверяем, есть ли выбранный элемент в ComboBox
            if (comboBox1.SelectedItem != null)
            {
                // Получаем выбранный элемент ComboBox
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox1.SelectedItem;

                // Получаем ID билета из выбранного элемента
                Guid selectedTicketId = selectedItem.Value;

                // Находим билет в базе данных по ID
                Ticket ticketToDelete = _dbContext.Ticket.FirstOrDefault(t => t.Id == selectedTicketId);

                // Проверяем, найден ли билет
                if (ticketToDelete != null)
                {
                    // Удаляем билет из базы данных и сохраняем изменения
                    _dbContext.Ticket.Remove(ticketToDelete);
                    _dbContext.SaveChanges();

                    // Удаляем соответствующий элемент из listView1
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.Text == ticketToDelete.TicketNumber.ToString())
                        {
                            listView1.Items.Remove(item);
                            break;
                        }
                    }

                    // Удаляем выбранный элемент из ComboBox
                    comboBox1.Items.Remove(selectedItem);

                    // Устанавливаем первый элемент в ComboBox выбранным, если есть элементы
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    MessageBox.Show("Билет успешно удален");
                }
                else
                {
                    MessageBox.Show("Выбранный билет не найден");
                }
            }
            else
            {
                MessageBox.Show("Выберите билет для удаления");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}