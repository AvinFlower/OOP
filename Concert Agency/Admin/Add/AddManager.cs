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
    public partial class AddManager : Form
    {
        private readonly ConcertContext _dbContext;
        private Guid managerId;
        private AddValue mainForm;

        public AddManager(AddValue mainForm)
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
            string PhoneNumber = maskedTextBox1.Text;
            string Email = textBox5.Text;
            string PassportData = textBox6.Text;

            if (string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(PassportData))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }
            else if (string.IsNullOrEmpty(Email)) Email = "";
            else if (string.IsNullOrEmpty(MiddleName)) MiddleName = "";

            Manager existingManager = _dbContext.Manager.FirstOrDefault(a =>
            a.Id == managerId ||
            (a.Email == Email &&
            a.PhoneNumber == PhoneNumber &&
            a.FirstName == FirstName &&
            a.LastName == LastName &&
            a.MiddleName == MiddleName &&
            a.PassportData == PassportData));

            if (existingManager == null)
            {
                Manager newManager = new Manager
                {
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    FirstName = FirstName,
                    LastName = LastName,
                    MiddleName = MiddleName,
                    PassportData = PassportData,
                };

                _dbContext.Manager.Add(newManager);
                _dbContext.SaveChanges();

                managerId = newManager.Id;
            }
            else
            {
                // Use the existing manager's ID
                managerId = existingManager.Id;

                // Update existing manager's data
                existingManager.Email = Email;
                existingManager.PhoneNumber = PhoneNumber;
                existingManager.FirstName = FirstName;
                existingManager.LastName = LastName;
                existingManager.MiddleName = MiddleName;
                existingManager.PassportData = PassportData;

                _dbContext.SaveChanges();
            }

            MessageBox.Show("Менеджер занесен в БД.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }

        private void AddManager_Load(object sender, EventArgs e)
        {

        }
    }
}
