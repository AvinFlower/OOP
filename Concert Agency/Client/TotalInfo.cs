using Concert_Agency;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class TotalInfo : Form
    {
        private readonly ConcertContext _dbContext;
        private readonly Guid _artistId;
        private readonly Guid _riderId;

        private Artist _originalArtist;
        private Rider _originalRider;

        public TotalInfo(Guid artistId, Guid riderId)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            _artistId = artistId;
            _riderId = riderId;
        }

        private void TotalInfo_Load(object sender, EventArgs e)
        {
            _originalArtist = _dbContext.Artist.FirstOrDefault(a => a.Id == _artistId);

            _originalRider = _dbContext.Rider.FirstOrDefault(r => r.Id == _riderId);

            if (_originalArtist != null && _originalRider != null)
            {
                listView1.View = View.Details;
                listView1.GridLines = true;

                listView1.Columns.Add("Email");
                listView1.Columns.Add("PhoneNumber");
                listView1.Columns.Add("DateOfBirth");
                listView1.Columns.Add("Country");
                listView1.Columns.Add("FirstName");
                listView1.Columns.Add("LastName");
                listView1.Columns.Add("MiddleName");
                listView1.Columns.Add("PassportData");
                listView1.Columns.Add("RiderDate");
                listView1.Columns.Add("Requirements");

                ListViewItem item = new ListViewItem(_originalArtist.Email);
                item.SubItems.Add(_originalArtist.PhoneNumber);
                item.SubItems.Add(_originalArtist.DateOfBirth.ToString());
                item.SubItems.Add(_originalArtist.Country);
                item.SubItems.Add(_originalArtist.FirstName);
                item.SubItems.Add(_originalArtist.LastName);
                item.SubItems.Add(_originalArtist.MiddleName);
                item.SubItems.Add(_originalArtist.PassportData);
                item.SubItems.Add(_originalRider.RiderDate.ToString());
                item.SubItems.Add(_originalRider.Requirements);


                listView1.Items.Add(item);
                listView1.Height = 75;
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = -2;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Последний заказ из БД
            Order lastOrder = _dbContext.Order
                .OrderByDescending(o => o.OrderNum)
                .FirstOrDefault();

            // Порядковый номер нового заказа
            uint orderNum = (lastOrder != null) ? lastOrder.OrderNum + 1 : 1;

            DateTime orderDate = DateTime.UtcNow;

            Manager defaultManager = _dbContext.Manager
                .FirstOrDefault(m => m.PassportData == "1213_345678");

            Artist artistForOrder = _originalArtist;

            Order newOrder = new Order
            {
                OrderNum = orderNum,
                OrderDate = orderDate,
                OrderStatus = "Preparation",
                Artist = artistForOrder,
                Manager = defaultManager
            };

            _dbContext.Order.Add(newOrder);
            _dbContext.SaveChanges();

            MessageBox.Show("The rider has been successfully sent!");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
