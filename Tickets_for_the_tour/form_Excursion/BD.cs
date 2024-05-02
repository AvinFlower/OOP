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
using System.Xml.Linq;
using Tickets_for_the_tour;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace form_Excursion
{
    public partial class BD : Form
    {
        private string _connectionString;
        public BD()
        {
            InitializeComponent();
        }

        private void BD_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dbName = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            _connectionString = $"Server=localhost;Database={dbName};User Id={username};Password={password};";

            // Создаем опции контекста базы данных с нашей строкой подключения
            var optionsBuilder = new DbContextOptionsBuilder<TourDbContext>();
            optionsBuilder.UseNpgsql(_connectionString);

            // Создаем экземпляр контекста базы данных с опциями
            using (var dbContext = new TourDbContext(optionsBuilder.Options))
            {
                // Вызываем Migrate() для применения всех миграций и обновлений
                dbContext.Database.Migrate();

                // Дополнительный код, если необходимо
            }

            MessageBox.Show("База данных готова к использованию!");
        }
    }
}
