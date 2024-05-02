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
    public partial class Form_Employee : Form
    {
        private readonly TourContext _dbContext;
        public Form_Employee()
        {
            InitializeComponent();
            _dbContext = new TourContext();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Employee_Load(object sender, EventArgs e)
        {
            //var employees = _dbContext.Employees.ToList();
            //textBox1.Text += "Работники:\r\n";

            //// Заполняем TextBox информацией о сотрудниках
            //foreach (var employee in employees)
            //{
            //    textBox1.Text += $"\r\n{employee.LastName} {employee.FirstName} {employee.MiddleName}, Должность: {employee.Grachdanstvo}\r\n";
            //}
            // Fetch employees from the database
            var employees = _dbContext.Employees.ToList();

            // Set up DataGridView columns
            dataGridView1.Columns.Add("LastName", "Фамилия");
            dataGridView1.Columns.Add("FirstName", "Имя");
            dataGridView1.Columns.Add("MiddleName", "Отчество");
            dataGridView1.Columns.Add("Position", "Должность");

            // Populate DataGridView with employee data
            foreach (var employee in employees)
            {
                dataGridView1.Rows.Add(employee.LastName, employee.FirstName, employee.MiddleName, employee.Grachdanstvo);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lastNameSearch = textBox1.Text.Trim();
            string firstNameSearch = textBox2.Text.Trim();

            // Search for employees matching the criteria
            var matchingEmployees = _dbContext.Employees
                .Where(emp => emp.LastName.Contains(lastNameSearch) && emp.FirstName.Contains(firstNameSearch))
                .ToList();

            // Display matching employees in textBox3
            textBox3.Text = "Найденные сотрудники:\r\n";
            foreach (var employee in matchingEmployees)
            {
                textBox3.Text += $"{employee.LastName} {employee.FirstName} {employee.MiddleName}, Должность: {employee.Grachdanstvo}\r\n";
            }
        }
    }
}
