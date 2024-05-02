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
    public partial class Edit_Excurtions : Form
    {
        public string ExcursionNameS { get; set; }
        public Edit_Excurtions(string excursionName)
        {
            InitializeComponent();
            ExcursionNameS = excursionName;
        }

        private void Edit_Excurtions_Load(object sender, EventArgs e)
        {
            using (TourContext db = new TourContext())
            {
                textBox1.Text = ExcursionNameS;

                var excursions = db.Excursions.FirstOrDefault(ex => ex.ExcursionVariants == ExcursionNameS);
                numericUpDown1.Value = excursions.PriceExcursion;

                var rout = db.Routes.FirstOrDefault(r => r.Excursion.ExcursionVariants == ExcursionNameS);
                numericUpDown2.Value = (decimal)rout.Distance;
                textBox2.Text = rout.RouteName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TourContext db = new TourContext())
            {
                var excursions = db.Excursions.FirstOrDefault(ex => ex.ExcursionVariants == ExcursionNameS);
                var rout = db.Routes.FirstOrDefault(r => r.Excursion.ExcursionVariants == ExcursionNameS);

                excursions.ExcursionVariants = textBox1.Text;
                excursions.PriceExcursion = numericUpDown1.Value;
                rout.Distance = (double)numericUpDown2.Value;
                rout.RouteName = textBox2.Text;
                db.SaveChanges();
            }
        }
    }
}
