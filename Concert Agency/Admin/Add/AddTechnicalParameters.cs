using Concert_Agency;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
    public partial class AddTechnicalParameters : Form
    {
        private readonly ConcertContext _dbContext;
        private AddValue mainForm;
        public AddTechnicalParameters(AddValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void AddTechnicalParameters_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string attributeParameter = textBox1.Text;

            if (string.IsNullOrEmpty(attributeParameter))
            {
                MessageBox.Show("Вы не ввели параметр");
                return;
            }

            bool parameterExists = _dbContext.TechnicalParameter.Any(tp => tp.AttributeParameters == attributeParameter);

            if (parameterExists)
            {
                MessageBox.Show("Такой параметр уже существует в базе данных");
                return;
            }

            TechnicalParameters technicalParameters = new TechnicalParameters()
            {
                AttributeParameters = attributeParameter,
            };

            _dbContext.TechnicalParameter.Add(technicalParameters);
            _dbContext.SaveChanges();

            MessageBox.Show("Параметр занесен в БД");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }
    }
}
