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

namespace Manager
{
    public partial class OrdersInProcess : Form
    {

        private readonly ConcertContext _dbContext;
        public OrdersInProcess()
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
        }

        private void OrdersInProcess_Load(object sender, EventArgs e)
        {
            var ordersWithArtists = _dbContext.Order
                .Include(order => order.Artist)
                .Where(order => order.OrderStatus == "In Process")
                .ToList();

            listView1.View = View.Details;
            listView1.GridLines = true;

            listView1.Columns.Add("Номер заказа");
            listView1.Columns.Add("Дата заказа");
            listView1.Columns.Add("Email");
            listView1.Columns.Add("Номер телефона");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Паспортные данные");

            foreach (var order in ordersWithArtists)
            {
                var artist = order.Artist;

                ListViewItem item = new ListViewItem(order.OrderNum.ToString());
                item.SubItems.Add(order.OrderDate.ToString());
                item.SubItems.Add(artist.Email);
                item.SubItems.Add(artist.PhoneNumber);
                item.SubItems.Add(artist.FirstName);
                item.SubItems.Add(artist.LastName);
                item.SubItems.Add(artist.MiddleName);
                item.SubItems.Add(artist.PassportData);

                listView1.Items.Add(item);
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2;
            }

            comboBox1.Items.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                string orderNum = item.SubItems[0].Text;
                comboBox1.Items.Add("Заказ №" + orderNum);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получить номер заказа из выбранного элемента в комбобоксе
            int selectedOrderNum = GetSelectedOrderNum();

            if (selectedOrderNum != -1)
            {
                // Найти заказ в базе данных по номеру заказа
                var orderToUpdate = _dbContext.Order.FirstOrDefault(order => order.OrderNum == selectedOrderNum);

                if (orderToUpdate != null)
                {
                    // Установить новый статус заказа
                    orderToUpdate.OrderStatus = "Completed";

                    // Сохранить изменения в базе данных
                    _dbContext.SaveChanges();

                    var itemToRemove = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text == selectedOrderNum.ToString());
                    listView1.Items.Remove(itemToRemove);
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    MessageBox.Show($"Статус заказа №{selectedOrderNum} изменен на 'Выполнен'.");
                }
                else
                {
                    MessageBox.Show($"Заказ с номером {selectedOrderNum} не найден.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для изменения статуса.");
            }
        }


        private int GetSelectedOrderNum()
        {
            // Вернуть номер заказа из выбранного элемента в комбобоксе
            if (comboBox1.SelectedItem != null)
            {
                string selectedOrderText = comboBox1.SelectedItem.ToString();
                // Извлечь номер заказа из текста
                string orderNumString = selectedOrderText.Replace("Заказ №", "");
                if (int.TryParse(orderNumString, out int orderNum))
                {
                    return orderNum;
                }
            }

            // Вернуть значение по умолчанию, если не удалось получить номер заказа
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedOrderNum = GetSelectedOrderNum();

            if (selectedOrderNum != -1)
            {
                // Найти заказ в базе данных по номеру заказа
                var orderToDelete = _dbContext.Order.FirstOrDefault(order => order.OrderNum == selectedOrderNum);

                if (orderToDelete != null)
                {
                    _dbContext.Order.Remove(orderToDelete);
                    _dbContext.SaveChanges();

                    RemoveOrderFromListView(selectedOrderNum);

                    MessageBox.Show($"Заказ успешно удален и больше не обрабатывается!");
                }
                else
                {
                    MessageBox.Show($"Заказ с номером {selectedOrderNum} не найден.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для изменения статуса.");
            }
        }

        public void RemoveOrderFromListView(int orderNum)
        {
            var itemToRemove = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.SubItems[0].Text == orderNum.ToString());

            if (itemToRemove != null)
            {
                listView1.Items.Remove(itemToRemove);

                string orderToRemove = "Заказ №" + orderNum.ToString();
                if (comboBox1.Items.Contains(orderToRemove))
                {
                    comboBox1.Items.Remove(orderToRemove);
                }
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
        }
    }
}
