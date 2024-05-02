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
            var ordersWithArtistsAndConcerts = _dbContext.Order
                .Include(order => order.Artist)
                .ThenInclude(artist => artist.ConcertArtists)
                .ThenInclude(concertArtist => concertArtist.Concert)
                .ThenInclude(concert => concert.ConcertOrganization)
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
            listView1.Columns.Add("FinalReceipt");

            foreach (var order in ordersWithArtistsAndConcerts)
            {
                foreach (var concertArtist in order.Artist.ConcertArtists)
                {
                    var concert = concertArtist.Concert;
                    var concertOrganization = concert.ConcertOrganization;

                    ListViewItem item = new ListViewItem(order.OrderNum.ToString());
                    item.SubItems.Add(order.OrderDate.ToString());
                    item.SubItems.Add(order.Artist.Email);
                    item.SubItems.Add(order.Artist.PhoneNumber);
                    item.SubItems.Add(order.Artist.FirstName);
                    item.SubItems.Add(order.Artist.LastName);
                    item.SubItems.Add(order.Artist.MiddleName);
                    item.SubItems.Add(order.Artist.PassportData);
                    item.SubItems.Add(concertOrganization.FinalReceipt.ToString()); // Добавляем FinalReceipt

                    listView1.Items.Add(item);
                }
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

                // Вычисляем Max, Min и Avg значения из столбца FinalReceipt
                List<decimal> finalReceiptValues = new List<decimal>();
                foreach (ListViewItem item in listView1.Items)
                {
                    decimal finalReceipt;
                    if (item.SubItems.Count > 8 && decimal.TryParse(item.SubItems[8].Text, out finalReceipt))
                    {
                        finalReceiptValues.Add(finalReceipt);
                    }
                }

                decimal maxFinalReceipt = finalReceiptValues.Max();
                decimal minFinalReceipt = finalReceiptValues.Min();
                decimal avgFinalReceipt = finalReceiptValues.Count > 0 ? finalReceiptValues.Average() : 0;

                // Добавляем Max, Min и Avg значения к файлу Excel
                worksheet.Cells[listView1.Items.Count + 3, 1].Value = "Max FinalReceipt";
                worksheet.Cells[listView1.Items.Count + 3, 2].Value = maxFinalReceipt;
                worksheet.Cells[listView1.Items.Count + 4, 1].Value = "Min FinalReceipt";
                worksheet.Cells[listView1.Items.Count + 4, 2].Value = minFinalReceipt;
                worksheet.Cells[listView1.Items.Count + 5, 1].Value = "Avg FinalReceipt";
                worksheet.Cells[listView1.Items.Count + 5, 2].Value = avgFinalReceipt;

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