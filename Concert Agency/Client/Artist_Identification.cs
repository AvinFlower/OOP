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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class ArtistIdentification : Form
    {
        private readonly ConcertContext _dbContext;
        private Guid artistId;

        public ArtistIdentification()
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = textBox7.Text;
            string PhoneNumber = maskedTextBox1.Text;
            DateTime DateOfBirth = DateTime.SpecifyKind(dateTimePicker1.Value.Date, DateTimeKind.Utc);
            string Country = textBox4.Text;
            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;
            string MiddleName = textBox3.Text;
            string PassportData = textBox5.Text;

            if (string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Country) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(PassportData))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }
            else if (string.IsNullOrEmpty(Email)) Email = "";
            else if (string.IsNullOrEmpty(MiddleName)) MiddleName = "";

            Artist existingArtist = _dbContext.Artist.FirstOrDefault(a =>
            a.Id == artistId ||
            (a.Email == Email &&
            a.PhoneNumber == PhoneNumber &&
            a.DateOfBirth == DateOfBirth &&
            a.Country == Country &&
            a.FirstName == FirstName &&
            a.LastName == LastName &&
            a.MiddleName == MiddleName &&
            a.PassportData == PassportData));

            if (existingArtist == null)
            {
                Artist newArtist = new Artist
                {
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    DateOfBirth = DateOfBirth,
                    Country = Country,
                    FirstName = FirstName,
                    LastName = LastName,
                    MiddleName = MiddleName,
                    PassportData = PassportData,
                };

                _dbContext.Artist.Add(newArtist);
                _dbContext.SaveChanges();

                artistId = newArtist.Id;
            }
            else
            {
                artistId = existingArtist.Id;

                existingArtist.Email = Email;
                existingArtist.PhoneNumber = PhoneNumber;
                existingArtist.DateOfBirth = DateOfBirth;
                existingArtist.Country = Country;
                existingArtist.FirstName = FirstName;
                existingArtist.LastName = LastName;
                existingArtist.MiddleName = MiddleName;
                existingArtist.PassportData = PassportData;

                _dbContext.SaveChanges();
            }

            FillRider FillRider = new FillRider(artistId);
            FillRider.Owner = this;
            FillRider.ShowDialog();
        }

        private void ArtistIdentification_Load(object sender, EventArgs e)
        {

        }
    }
}