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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admin
{
    public partial class AddVenue : Form
    {
        private readonly ConcertContext _dbContext;
        private Guid venueId;
        private AddValue mainForm;

        public AddVenue(AddValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void Venue_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string VenueName = textBox1.Text;
            string City = textBox2.Text;
            string Country = textBox3.Text;

            if (string.IsNullOrEmpty(VenueName) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Country))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            Venue existingVenue = _dbContext.Venue.FirstOrDefault(a =>
            a.Id == venueId ||
            (a.VenueName == VenueName &&
            a.City == City &&
            a.Country == Country));

            if (existingVenue == null)
            {
                Venue newVenue = new Venue
                {
                    VenueName = VenueName,
                    City = City,
                    Country = Country,
                };

                _dbContext.Venue.Add(newVenue);
                _dbContext.SaveChanges();

                venueId = newVenue.Id;
            }
            else
            {
                venueId = existingVenue.Id;

                existingVenue.VenueName = VenueName;
                existingVenue.City = City;
                existingVenue.Country = Country;

                _dbContext.SaveChanges();
            }

            MessageBox.Show("Место занесено в БД.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Запретить ввод цифр
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Запретить ввод цифр
            }
        }
    }
}
