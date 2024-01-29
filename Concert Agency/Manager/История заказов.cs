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
    public partial class OrdersHistory : Form
    {
        private readonly ConcertContext _dbContext;
        public OrdersHistory()
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
        }

        private void OrdersHistory_Load(object sender, EventArgs e)
        {
            var ordersWithArtists = _dbContext.Order
                .Include(order => order.Artist)
                .Where(order => order.OrderStatus == "Completed")
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
        }
    }
}
