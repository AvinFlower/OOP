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

            listView1.Columns.Add("����� ������");
            listView1.Columns.Add("���� ������");
            listView1.Columns.Add("Email");
            listView1.Columns.Add("����� ��������");
            listView1.Columns.Add("���");
            listView1.Columns.Add("�������");
            listView1.Columns.Add("��������");
            listView1.Columns.Add("���������� ������");

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

            // �������������� ��������� �������� �������� �� ������ �����������
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // -2 ���������, ����� ������ ���� ����������� �������������
            }


            comboBox1.Items.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                string orderNum = item.SubItems[0].Text;
                comboBox1.Items.Add("����� �" + orderNum);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // �������� ����� ������ �� ���������� �������� � ����������
            int selectedOrderNum = GetSelectedOrderNum();

            // ���������, ��� ����� ������ ��� ������� �������
            if (selectedOrderNum != -1)
            {
                Form2 form2 = new Form2(selectedOrderNum);
                form2.Owner = this;
                form2.ShowDialog();
            }
            else
            {
                // ���� ����� ������ �� ������, �������� ���������� ���� � �������
                MessageBox.Show("�������� ����� ������ ����� ��������� ������ �����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedOrderNum()
        {
            // ������� ����� ������ �� ���������� �������� � ����������
            if (comboBox1.SelectedItem != null)
            {
                string selectedOrderText = comboBox1.SelectedItem.ToString();
                // ������� ����� ������ �� ������ (������: "����� �123")
                string orderNumString = selectedOrderText.Replace("����� �", "");
                if (int.TryParse(orderNumString, out int orderNum))
                {
                    return orderNum;
                }
            }

            // ������� �������� �� ���������, ���� �� ������� �������� ����� ������
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
                string orderToRemove = "����� �" + orderNum.ToString();
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
