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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace form_Excursion
{
    public partial class Add_Excursion : Form
    {
        public Add_Excursion()
        {
            InitializeComponent();
            using (TourContext db = new())
            {
                var excursions = db.Excursions.Select(x => x.ExcursionVariants).ToList();
                comboBox1.DataSource = excursions;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TourContext db = new())
            {

                Excursion select_excursion(string ExcursionVariants)
                {
                    var SelectStudent = db.Excursions
                        .Where(b => b.ExcursionVariants == ExcursionVariants)
                        .FirstOrDefault();

                    return SelectStudent;
                }

                string name = textBox1.Text;
                int price = (int)numericUpDown1.Value;
                int distance = (int)numericUpDown2.Value;
                string rout = textBox2.Text;


                Excursion excursion = new Excursion();
                excursion.Add(name, price, distance, rout);
                db.Excursions.Add(excursion);

                Route select_route(Guid ID_Excursion)
                {
                    var selectVC = db.Routes
                        .Where(b => b.ID_Excursion == ID_Excursion)
                        .FirstOrDefault();
                    return selectVC;
                }
                db.SaveChanges();

                MessageBox.Show("Экскурсия добавлена");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TourContext db = new())
            {
                string selectedExcursion = comboBox1.SelectedItem?.ToString();

                if (selectedExcursion != null)
                {
                    // Get the excursion to delete
                    Excursion excursionToDelete = db.Excursions
                        .Where(ex => ex.ExcursionVariants == selectedExcursion)
                        .FirstOrDefault();

                    if (excursionToDelete != null)
                    {
                        // Delete related flights
                        var flightsToDelete = db.Flights
                            .Where(f => f.Excursion.Id == excursionToDelete.Id)
                            .ToList();
                        db.Flights.RemoveRange(flightsToDelete);

                        // Delete route and route points
                        var routeToDelete = db.Routes
                            .Where(r => r.ID_Excursion == excursionToDelete.Id)
                            .FirstOrDefault();
                        if (routeToDelete != null)
                        {
                            var routePointsToDelete = db.RoutePoints
                                .Where(rp => rp.Route.Id == routeToDelete.Id)
                                .ToList();
                            db.RoutePoints.RemoveRange(routePointsToDelete);

                            db.Routes.Remove(routeToDelete);
                        }

                        // Finally, delete the excursion
                        db.Excursions.Remove(excursionToDelete);

                        // Save changes
                        db.SaveChanges();

                        MessageBox.Show("Экскурсия удалена");
                    }
                    else
                    {
                        MessageBox.Show("Выбранная экскурсия не найдена");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите экскурсию для удаления");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string excursionName = (string)comboBox1.SelectedItem;
                Edit_Excurtions edit_Excurtions = new Edit_Excurtions(excursionName);
                edit_Excurtions.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите экскурсию для редактирования.");
            }
        }

        private void Add_Excursion_Load(object sender, EventArgs e)
        {

        }
    }
}
