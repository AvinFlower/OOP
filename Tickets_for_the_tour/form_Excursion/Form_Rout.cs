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
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace form_Excursion
{
    public partial class Form_Rout : Form
    {
        public string SelectedExcursionVariant { get; set; }

        public Form_Rout()
        {
            InitializeComponent();
        }

        private void Form_Rout_Load(object sender, EventArgs e)
        {
            using (TourContext db = new())
            {
                var selectedExcursion = db.Excursions
                    .Include(e => e.Route)
                    .ThenInclude(r => r.RoutePoints)
                    .ThenInclude(rp => rp.Attractions)
                    .FirstOrDefault(e => e.ExcursionVariants == SelectedExcursionVariant);


                int i = 1;
                if (selectedExcursion != null)
                {
                    textBox1.AppendText($"Маршрут: {selectedExcursion.Route.RouteName}\r\n");

                    foreach (var routePoint in selectedExcursion.Route.RoutePoints)
                    {
                        textBox1.AppendText($"Остановка " + i + "\r\n");
                        i++;
                        // Обращайтесь к Attractions через свойство RoutePoint
                        foreach (var attraction in routePoint.Attractions)
                        {
                            textBox1.AppendText($"Достопримечательность: {attraction.AttractionName}\r\n");
                        }

                        textBox1.AppendText("\r\n"); // Пустая строка между остановками
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
