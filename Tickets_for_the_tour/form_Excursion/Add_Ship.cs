using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_for_the_tour;

namespace form_Excursion
{
    public partial class Add_Ship : Form
    {
        private TourContext db;
        public Add_Ship()
        {
            InitializeComponent();
            db = new TourContext();
        }

        private void Add_Ship_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(ComfortLevel));
            LoadShips();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadShips()
        {
            comboBox2.DataSource = db.Ships.Select(s => s.ShipName).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComfortLevel selectedComfortLevel = (ComfortLevel)comboBox1.SelectedItem;
            string name = textBox1.Text;
            double speed = Convert.ToDouble(numericUpDown1.Value);
            int max = Convert.ToInt32(numericUpDown2.Value);

            Ship ship = new Ship();
            ship.Add(name, speed, max, selectedComfortLevel.ToString());
            db.Ships.Add(ship);

            db.SaveChanges();

            MessageBox.Show("Судно добавлено");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string selectedShipName = comboBox2.SelectedItem.ToString();

            Ship shipToDelete = db.Ships.FirstOrDefault(s => s.ShipName == selectedShipName);

            if (shipToDelete != null)
            {
                db.Ships.Remove(shipToDelete);
                db.SaveChanges();
                MessageBox.Show("Судно удалено");
                LoadShips();
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выберите судно для удаления");
            }
        }
    }
}
