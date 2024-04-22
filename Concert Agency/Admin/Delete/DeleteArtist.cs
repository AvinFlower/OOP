using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Admin.Delete
{
    public partial class DeleteArtist : Form
    {
        private readonly ConcertContext _dbContext;
        private DeleteValue mainForm;

        public DeleteArtist(DeleteValue mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void DeleteArtist_Load(object sender, EventArgs e)
        {
            // Устанавливаем вид и сетку для ListView
            listView1.View = View.Details;
            listView1.GridLines = true;

            // Добавляем колонки
            listView1.Columns.Add("Электронная почта", 150);
            listView1.Columns.Add("Номер телефона", 150);
            listView1.Columns.Add("Дата рождения", 150);
            listView1.Columns.Add("Страна", 100);
            listView1.Columns.Add("Имя", 100);
            listView1.Columns.Add("Фамилия", 100);
            listView1.Columns.Add("Отчество", 100);
            listView1.Columns.Add("Паспортные данные", 200);

            // Получаем все записи Artist из базы данных
            var artists = _dbContext.Artist.ToList();

            // Добавляем каждую запись Artist в ListView
            foreach (var artist in artists)
            {
                // Создаем новый элемент ListViewItem с атрибутами Artist
                ListViewItem item = new ListViewItem(artist.Email);
                item.SubItems.Add(artist.PhoneNumber);
                item.SubItems.Add(artist.DateOfBirth.ToString("yyyy-MM-dd"));
                item.SubItems.Add(artist.Country);
                item.SubItems.Add(artist.FirstName);
                item.SubItems.Add(artist.LastName);
                item.SubItems.Add(artist.MiddleName);
                item.SubItems.Add(artist.PassportData);

                // Добавляем элемент в ListView
                listView1.Items.Add(item);
            }

            // Устанавливаем высоту ListView и ширину колонок
            listView1.Height = 270;
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // Автоматический размер колонки
            }

            // Заполняем comboBox1 именами, фамилиями и паспортными данными артистов
            FillArtistComboBox();
        }

        private void FillArtistComboBox()
        {
            // Очищаем элементы в comboBox1 перед добавлением новых
            comboBox1.Items.Clear();

            // Получаем все записи Artist из базы данных
            var artists = _dbContext.Artist.ToList();

            // Добавляем имена, фамилии и паспортные данные каждого артиста в comboBox1
            foreach (var artist in artists)
            {
                // Формируем строку с именем, фамилией и паспортными данными артиста
                string comboBoxItemText = $"{artist.FirstName} {artist.LastName} - {artist.PassportData}";

                // Создаем новый объект ComboBoxItem
                ComboBoxItem comboBoxItem = new ComboBoxItem(comboBoxItemText, artist.Id);

                // Добавляем элемент в ComboBox
                comboBox1.Items.Add(comboBoxItem);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли элемент в ComboBox
            if (comboBox1.SelectedItem != null)
            {
                // Получаем выбранный артист из ComboBoxItem
                ComboBoxItem selectedArtistItem = (ComboBoxItem)comboBox1.SelectedItem;

                // Получаем паспортные данные выбранного артиста
                string selectedPassportData = selectedArtistItem.Display.Split(new string[] { " - " }, StringSplitOptions.None)[1];

                // Находим артиста с выбранными паспортными данными в базе данных
                var selectedArtist = _dbContext.Artist.FirstOrDefault(a => a.PassportData == selectedPassportData);

                // Проверяем, найден ли артист
                if (selectedArtist != null)
                {
                    // Удаляем артиста из базы данных
                    _dbContext.Artist.Remove(selectedArtist);

                    // Сохраняем изменения в базе данных
                    _dbContext.SaveChanges();

                    // Выводим сообщение об успешном удалении артиста
                    MessageBox.Show($"Артист с паспортными данными \"{selectedPassportData}\" успешно удален.");

                    // Обновляем список артистов в ComboBox
                    FillArtistComboBox();

                    // Удаляем выбранный элемент из ListView
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[7].Text == selectedPassportData)
                        {
                            listView1.Items.Remove(item);
                            break;
                        }
                    }
                }
                else
                {
                    // Выводим сообщение об ошибке, если артист не найден
                    MessageBox.Show("Артист с выбранными паспортными данными не найден в базе данных.");
                }
            }
            else
            {
                // Выводим сообщение об ошибке, если артист не выбран
                MessageBox.Show("Пожалуйста, выберите артиста для удаления.");
            }
        }
    }
}
