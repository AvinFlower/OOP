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
    public partial class Add_Employee : Form
    {
        private TourContext db;
        public Add_Employee()
        {
            InitializeComponent();
            db = new TourContext();
        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            comboBox1.DataSource = Enum.GetValues(typeof(Position));
        }
        private void LoadEmployees()
        {
            comboBox2.DataSource = db.Employees.Select(emp => $"{emp.LastName} {emp.FirstName}").ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            string i = textBox2.Text;
            string o = textBox3.Text;
            string pasport = textBox4.Text;
            Position dol = (Position)comboBox1.SelectedItem;
            DateOnly BirthDate = DateOnly.FromDateTime(dateTimePickerBirthDate.Value.Date);

            Employee employee = new Employee();
            employee.Add(f, i, o, pasport, BirthDate, dol.ToString());
            db.Employees.Add(employee);
            db.SaveChanges();

            MessageBox.Show("Человек принят на работу");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedEmployeeName = comboBox2.SelectedItem.ToString();

            Employee employeeToDelete = db.Employees.FirstOrDefault(emp => (emp.LastName + " " + emp.FirstName) == selectedEmployeeName);


            if (employeeToDelete != null)
            {
                db.Employees.Remove(employeeToDelete);
                db.SaveChanges();
                MessageBox.Show("Сотрудник удален");
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления");
            }
        }
    }
}
