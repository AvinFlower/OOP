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
    public partial class Form_Excursion : Form
    {
        public Form_Excursion()
        {
            InitializeComponent();

            using (TourContext db = new())
            {
                var query1 = from Excursion in db.Excursions
                             orderby Excursion.ExcursionVariants
                             select new { Excursion.ExcursionVariants };


                foreach (var item in query1)
                {
                    comboBox1.Items.Add(item.ExcursionVariants);
                }

                comboBox1.Text = comboBox1.Items[0].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Rout form_rout = new Form_Rout();
            form_rout.SelectedExcursionVariant = comboBox1.SelectedItem.ToString();
            form_rout.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Flights form_flights = new Form_Flights();
            form_flights.SelectedExcursionVariant = comboBox1.SelectedItem.ToString();
            form_flights.ShowDialog();
        }

        private void Form_Excursion_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form_Flights form_flights = new Form_Flights();
            form_flights.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Employee form_employee = new Form_Employee();
            form_employee.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_Ships form_ships = new Form_Ships();
            form_ships.ShowDialog();
        }
    }
}
