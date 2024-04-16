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

namespace Admin
{
    public partial class AddArtist : Form
    {
        private readonly ConcertContext _dbContext;
        private Guid artistId;
        private Main mainForm;

        public AddArtist(Main mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;
            string MiddleName = textBox3.Text;
            DateTime DateOfBirth = DateTime.SpecifyKind(dateTimePicker1.Value.Date, DateTimeKind.Utc);
            string Country = textBox4.Text;
            string PassportData = textBox5.Text;
            string PhoneNumber = maskedTextBox1.Text;
            string Email = textBox7.Text;

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

            MessageBox.Show("Артист занесен в БД.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }
    }
}
