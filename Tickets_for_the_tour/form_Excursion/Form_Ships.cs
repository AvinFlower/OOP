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
    public partial class Form_Ships : Form
    {
        private readonly TourContext _dbContext;
        public Form_Ships()
        {
            InitializeComponent();
            _dbContext = new TourContext();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Ships_Load(object sender, EventArgs e)
        {
            var ships = _dbContext.Ships.ToList();

            // Очистка текстового поля перед добавлением новой информации
            textBox1.Clear();
            textBox1.Text += "Экскурсионные суда \r\n";
            // Вывод информации о каждом корабле в текстовое поле
            foreach (var ship in ships)
            {
                textBox1.Text += $"\r\nКорабль: {ship.ShipName}, Скорость: {ship.Speed}, Вместимость: {ship.Capacity}, Уровень комфорта: {ship.ComfortLevel}\r\n";
            }
        }
    }
}
