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
using Tickets_for_the_tour;

namespace form_Excursion
{
    public partial class Add_Attractions : Form
    {
        private TourContext db;
        public Add_Attractions()
        {
            InitializeComponent();
            db = new TourContext();
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

        private void Add_Attractions_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected excursion
            string SelectedExcursionVariant = comboBox1.SelectedItem?.ToString();

            var selectedExcursion = db.Excursions
                    .Include(e => e.Route)
                    .ThenInclude(r => r.RoutePoints)
                    .ThenInclude(rp => rp.Attractions)
                    .FirstOrDefault(e => e.ExcursionVariants == SelectedExcursionVariant);


            int i = 1;
            if (selectedExcursion != null)
            {
                comboBox2.Items.Clear();
                foreach (var routePoint in selectedExcursion.Route.RoutePoints)
                {
                    comboBox2.Items.Add($"Остановка {i}: {routePoint.Id}");
                    i++;
                }
            }



            //Guid searchId = comboBox2.SelectedIndex.Equals(0) ? Guid.NewGuid() : Guid.NewGuid();
            //var foundRoutePoint = selectedExcursion.Route.RoutePoints.FirstOrDefault(rp => rp.Id == searchId);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Get the selected excursion
            string SelectedExcursionVariant = comboBox1.SelectedItem?.ToString();

            var selectedExcursion = db.Excursions
                    .Include(e => e.Route)
                    .ThenInclude(r => r.RoutePoints)
                    .ThenInclude(rp => rp.Attractions)
                    .FirstOrDefault(e => e.ExcursionVariants == SelectedExcursionVariant);

            string addres = textBox1.Text;
            string name = textBox2.Text;

            string selectedRoutePointInfo = comboBox2.SelectedItem?.ToString();

            string[] parts = selectedRoutePointInfo?.Split(':');
            if (parts.Length == 2 && Guid.TryParse(parts[1].Trim(), out Guid selectedId))
            {
                Guid selectedGuid = new Guid(selectedId.ToString());

                var selectedRoutePoint = selectedExcursion.Route.RoutePoints.FirstOrDefault(rp => rp.Id == selectedGuid);

                if (selectedRoutePoint != null)
                {
                    Attraction attraction = new Attraction();
                    attraction.Add(addres, name, selectedRoutePoint);
                    db.Attractions.Add(attraction);
                    db.SaveChanges();

                    MessageBox.Show("Достопримечательность добавлена");
                }
            }
        }
    }
}
