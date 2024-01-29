using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concert_Agency;
using static System.Windows.Forms.DataFormats;
using System.Collections;

namespace Manager
{
    public partial class Form1 : Form
    {
        private readonly ConcertContext _dbContext;

        public Form1()
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ordersWithArtists = _dbContext.Order
                .Include(order => order.Artist)
                .Where(order => order.OrderStatus == "Preparation")
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

            // Автоматическое изменение размеров столбцов на основе содержимого
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // -2 указывает, чтобы ширина была установлена автоматически
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

            // Проверить, что номер заказа был успешно получен
            if (selectedOrderNum != -1)
            {
                Form2 form2 = new Form2(selectedOrderNum);
                form2.Owner = this;
                form2.ShowDialog();
            }
            else
            {
                // Если номер заказа не выбран, показать диалоговое окно с ошибкой
                MessageBox.Show("Выберите номер заказа перед открытием второй формы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedOrderNum()
        {
            // Вернуть номер заказа из выбранного элемента в комбобоксе
            if (comboBox1.SelectedItem != null)
            {
                string selectedOrderText = comboBox1.SelectedItem.ToString();
                // Извлечь номер заказа из текста (пример: "Заказ №123")
                string orderNumString = selectedOrderText.Replace("Заказ №", "");
                if (int.TryParse(orderNumString, out int orderNum))
                {
                    return orderNum;
                }
            }

            // Вернуть значение по умолчанию, если не удалось получить номер заказа
            return -1;
        }

        public void RemoveOrderFromListView(int orderNum)
        {
            // Find and remove the corresponding row from ListView1
            var itemToRemove = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.SubItems[0].Text == orderNum.ToString());

            if (itemToRemove != null)
            {
                listView1.Items.Remove(itemToRemove);

                // Remove the order from comboBox1
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

        private void button2_Click(object sender, EventArgs e)
        {
            OrdersHistory OrdersHistory = new OrdersHistory();
            OrdersHistory.Owner = this;
            OrdersHistory.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrdersInProcess OrdersInProcess = new OrdersInProcess();
            OrdersInProcess.Owner = this;
            OrdersInProcess.ShowDialog();
        }

    }
}
