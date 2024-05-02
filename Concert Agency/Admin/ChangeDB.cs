using Concert_Agency;
using Microsoft.EntityFrameworkCore;

namespace Admin
{
    public partial class ChangeDB : Form
    {
        private readonly ConcertContext _dbContext;

        public ChangeDB()
        {
            InitializeComponent();
            _dbContext = new ConcertContext(); // Инициализация контекста вашей базы данных
        }

        private void ChangeDB_Load(object sender, EventArgs e)
        {
            // Загрузка и отображение списка баз данных при загрузке формы
            LoadDatabases();

            // Устанавливаем высоту ListView и ширину колонок
            listView1.View = View.Details; // Устанавливаем вид ListView как детальный, чтобы можно было видеть только один столбец
            listView1.Columns.Add("Название БД");
            listView1.Columns.Add("Владелец");

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2;
            }

        }

        private async void LoadDatabases()
        {
            try
            {
                // Получаем список всех баз данных
                var databases = await _dbContext.Database.GetDbConnection().GetSchemaAsync("Databases");

                // Очищаем список в ListView и ComboBox перед добавлением новых элементов
                listView1.Items.Clear();
                comboBox1.Items.Clear();

                // Добавляем названия баз данных и их владельцев в ListView и ComboBox
                foreach (System.Data.DataRow row in databases.Rows)
                {
                    string databaseName = row["database_name"].ToString();
                    string owner = row["owner"].ToString(); // Предполагаем, что владелец базы данных доступен в столбце "owner"

                    ListViewItem item = new ListViewItem(databaseName);
                    item.SubItems.Add(owner); // Добавляем владельца базы данных во второй столбец

                    listView1.Items.Add(item);

                    comboBox1.Items.Add(databaseName); // Добавление в ComboBox
                }

                // Если в comboBox1 есть элементы, выбираем первый элемент
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении списка баз данных: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем выбранный элемент из comboBox1
            string selectedDatabase = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedDatabase))
            {
                MessageBox.Show("Выберите базу данных из списка.");
                return;
            }

            try
            {
                // Подключение к выбранной базе данных
                string connectionString = "Host=localhost;Port=5432;Database=concert;Username=postgres;Password=299NhbnjY";
                _dbContext.Database.GetDbConnection().ConnectionString = connectionString;
                _dbContext.Database.EnsureCreated(); // Проверка и создание базы данных, если не существует

                MessageBox.Show($"Подключение к базе данных '{selectedDatabase}' установлено успешно.");


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении к базе данных '{selectedDatabase}': {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            Hide();
        }
    }
}
