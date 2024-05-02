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
    public partial class Add_RoutPoint : Form
    {

        public Add_RoutPoint()
        {
            InitializeComponent();
            using (TourContext db = new())
            {
                // Retrieve all excursions from the database
                var excursions = db.Excursions.ToList();

                // Clear existing items in the ComboBox
                comboBox1.Items.Clear();

                // Add excursion names to the ComboBox
                foreach (var excursion in excursions)
                {
                    comboBox1.Items.Add(excursion.ExcursionVariants);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TourContext db = new())
            {
                string selectedExcursionName = comboBox1.SelectedItem?.ToString();

                int time = (int)numericUpDown1.Value;

                Excursion select_excursion(string ExcursionVariants)
                {
                    var SelectStudent = db.Excursions
                        .Where(b => b.ExcursionVariants == ExcursionVariants)
                        .FirstOrDefault();

                    return SelectStudent;
                }

                Route select_route(Guid ID_Excursion)
                {
                    var selectVC = db.Routes
                        .Where(b => b.ID_Excursion == ID_Excursion)
                        .FirstOrDefault();
                    return selectVC;
                }
                db.SaveChanges();


                RoutePoint routePoint = new RoutePoint();
                routePoint.Add(TimeSpan.FromMinutes(time), select_route(select_excursion(selectedExcursionName).Id));
                db.RoutePoints.Add(routePoint);
                db.SaveChanges();

                MessageBox.Show("Точка маршрута  добавлена");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_RoutPoint_Load(object sender, EventArgs e)
        {

        }
    }
}
