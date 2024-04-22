using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Admin.Delete
{
    public partial class DeleteConcert : Form
    {
        private readonly ConcertContext _dbContext;
        private DeleteValue mainForm;

        public DeleteConcert(DeleteValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void DeleteConcert_Load(object sender, EventArgs e)
        {
            // Устанавливаем вид и сетку для ListView
            listView1.View = View.Details;
            listView1.GridLines = true;

            // Добавляем колонки
            listView1.Columns.Add("Название Концерта", 150);
            listView1.Columns.Add("Дата проведения", 150);
            listView1.Columns.Add("Объявленная стоимость", 200);

            // Получаем все записи Concert из базы данных
            var concerts = _dbContext.Concert.Include(c => c.ConcertOrganization).ToList();

            // Добавляем каждую запись Concert в ListView
            foreach (var concert in concerts)
            {
                // Создаем новый элемент ListViewItem с атрибутами ConcertName и ConcertDate
                ListViewItem item = new ListViewItem(concert.ConcertName);
                item.SubItems.Add(concert.ConcertDate.ToString("yyyy-MM-dd HH:mm:ss"));

                // Получаем FinalReceipt из связанной таблицы ConcertOrganization
                string finalReceipt = concert.ConcertOrganization != null ? concert.ConcertOrganization.FinalReceipt.ToString() : "N/A";

                // Добавляем FinalReceipt в элемент ListViewItem
                item.SubItems.Add(finalReceipt);

                // Добавляем элемент в ListView
                listView1.Items.Add(item);
            }

            // Устанавливаем высоту ListView и ширину колонок
            listView1.Height = 270;
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // Автоматический размер колонки
            }

            // Заполняем comboBox1 названиями концертов
            FillConcertComboBox();
        }

        private void FillConcertComboBox()
        {
            // Очищаем элементы в comboBox1 перед добавлением новых
            comboBox1.Items.Clear();

            // Получаем все записи Concert из базы данных
            var concerts = _dbContext.Concert.ToList();

            // Добавляем названия концертов в comboBox1
            foreach (var concert in concerts)
            {
                // Добавляем название концерта в comboBox1
                comboBox1.Items.Add(concert.ConcertName);
            }

            // Если есть элементы в ComboBox, выбираем первый элемент
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        public class ComboBoxItem
        {
            public string Display { get; set; }
            public Guid Value { get; set; }

            public ComboBoxItem(string display, Guid value)
            {
                Display = display;
                Value = value;
            }

            public override string ToString()
            {
                return Display;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли элемент в ComboBox
            if (comboBox1.SelectedItem != null)
            {
                // Получаем название выбранного концерта из ComboBox
                string selectedConcertName = comboBox1.SelectedItem.ToString();

                // Находим выбранный концерт в базе данных по названию
                var selectedConcert = _dbContext.Concert.FirstOrDefault(c => c.ConcertName == selectedConcertName);

                // Проверяем, найден ли концерт
                if (selectedConcert != null)
                {
                    // Удаляем выбранный концерт из базы данных
                    _dbContext.Concert.Remove(selectedConcert);

                    // Получаем связанную с концертом ConcertOrganization (если она есть)
                    var concertOrganization = _dbContext.ConcertOrganization.FirstOrDefault(co => co.Concert.Id == selectedConcert.Id);

                    // Проверяем, найдена ли связанная ConcertOrganization
                    if (concertOrganization != null)
                    {
                        // Удаляем связанную ConcertOrganization из базы данных
                        _dbContext.ConcertOrganization.Remove(concertOrganization);
                    }

                    // Сохраняем изменения в базе данных
                    _dbContext.SaveChanges();

                    // Выводим сообщение об успешном удалении концерта
                    MessageBox.Show($"Концерт \"{selectedConcertName}\" успешно удален.");

                    // Обновляем список концертов в ComboBox
                    FillConcertComboBox();

                    // Удаляем выбранный элемент из ListView
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.Text == selectedConcertName)
                        {
                            listView1.Items.Remove(item);
                            break;
                        }
                    }
                }
                else
                {
                    // Выводим сообщение об ошибке, если концерт не найден
                    MessageBox.Show("Выбранный концерт не найден в базе данных.");
                }
            }
            else
            {
                // Выводим сообщение об ошибке, если концерт не выбран
                MessageBox.Show("Пожалуйста, выберите концерт для удаления.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
