using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class OrdersHistory : Form
    {
        private Form1 form1;
        private readonly ConcertContext _dbContext;

        public OrdersHistory(Form1 form1)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.form1 = form1;
        }

        private void OrdersHistory_Load(object sender, EventArgs e)
        {
            var ordersWithArtists = _dbContext.Order
                .Include(order => order.Artist)
                .Where(order => order.OrderStatus == "Completed")
                .ToList();


            listView1.View = View.Details;
            listView1.GridLines = true;

            listView1.Columns.Add("Номер заказа");
            listView1.Columns.Add("Дата заказа");
            listView1.Columns.Add("Email");
            listView1.Columns.Add("Номер телефона");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Паспортные данные");

            foreach (var order in ordersWithArtists)
            {
                var artist = order.Artist;

                ListViewItem item = new ListViewItem(order.OrderNum.ToString());
                item.SubItems.Add(order.OrderDate.ToString());
                item.SubItems.Add(artist.Email);
                item.SubItems.Add(artist.PhoneNumber);
                item.SubItems.Add(artist.FirstName);
                item.SubItems.Add(artist.LastName);
                item.SubItems.Add(artist.MiddleName);
                item.SubItems.Add(artist.PassportData);

                listView1.Items.Add(item);
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToСSV(saveFileDialog.FileName);
            }
        }

        private void ExportToСSV(string fileName)
        {
            // Устанавливаем контекст лицензирования
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // или LicenseContext.Commercial, в зависимости от вашего типа лицензии

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Записываем заголовки столбцов и данные из ListView
                for (int i = 0; i < listView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = listView1.Columns[i].Text;

                    for (int j = 0; j < listView1.Items.Count; j++)
                    {
                        worksheet.Cells[j + 2, i + 1].Value = listView1.Items[j].SubItems[i].Text;
                    }
                }

                // Автоподгон ширины столбцов к содержимому, включая заголовки
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Сохраняем книгу Excel
                FileInfo excelFile = new FileInfo(fileName);
                excelPackage.SaveAs(excelFile);
            }

            // Отображаем сообщение об успешном экспорте
            MessageBox.Show("Данные успешно экспортированы в Excel файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}