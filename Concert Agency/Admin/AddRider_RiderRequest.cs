using Concert_Agency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admin
{
    public partial class AddRider_RiderRequest : Form
    {
        private readonly ConcertContext _dbContext;
        private Main mainForm;
        private Rider existingRider;

        public AddRider_RiderRequest(Main mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void AddRider_RiderRequest_Load(object sender, EventArgs e)
        {
            var artists = _dbContext.Artist;

            foreach (var artist in artists)
            {
                string managerInfo = $"{artist.FirstName}, {artist.LastName}, {artist.MiddleName}, {artist.PassportData}";
                comboBox1.Items.Add(new ComboBoxItem(managerInfo, artist.Id));
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textFromTextBox1 = textBox1.Text;
            string textFromTextBox2 = textBox2.Text;
            string textFromTextBox3 = textBox3.Text;
            string textFromTextBox4 = textBox4.Text;
            string textFromTextBox5 = textBox5.Text;
            string textFromTextBox6 = textBox6.Text;
            string textFromTextBox7 = textBox7.Text;
            string textFromTextBox8 = textBox8.Text;
            string textFromTextBox9 = textBox9.Text;

            List<string> lines = new List<string>();

            AddLine(lines, "Звуковая система", textFromTextBox1);
            AddLine(lines, "Микшерный пульт", textFromTextBox2);
            AddLine(lines, "Микрофоны", textFromTextBox3);
            AddLine(lines, "Клавишные", textFromTextBox4);
            AddLine(lines, "Гитара", textFromTextBox5);
            AddLine(lines, "Декорации", textFromTextBox6);
            AddLine(lines, "Безопасность", textFromTextBox7);
            AddLine(lines, "Вместимость зала", textFromTextBox8);
            AddLine(lines, "Проживание", textFromTextBox9);

            string allRider = string.Join(", ", lines);
            string artist = comboBox1.Text;

            Guid selectedArtistId = GetArtistIdFromText(artist);

            if (selectedArtistId != Guid.Empty)
            {
                Artist selectedArtist = _dbContext.Artist.FirstOrDefault(m => m.Id == selectedArtistId);

                // Проверяем, существует ли уже Rider для данного артиста
                existingRider = _dbContext.Rider.FirstOrDefault(r => r.Artist.Id == selectedArtistId);

                existingRider = new Rider
                {
                    Requirements = allRider,
                    RiderDate = DateTime.UtcNow,
                    Artist = selectedArtist,
                };

                _dbContext.Rider.Add(existingRider);

                List<TechnicalParameters> technicalParametersList = GetExistingTechnicalParameters();

                List<RiderRequest> riderRequests = _dbContext.RiderRequest
                    .Where(rr => rr.Rider.Id == existingRider.Id)
                    .ToList();

                UpdateRiderRequest(riderRequests, "Звуковая система", textBox1.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Микшерный пульт", textBox2.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Микрофон", textBox3.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Клавишные", textBox4.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Гитара", textBox5.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Декорации", textBox6.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Безопасность", textBox7.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Вместимость зала", textBox8.Text, technicalParametersList);
                UpdateRiderRequest(riderRequests, "Проживание", textBox9.Text, technicalParametersList);

                if (riderRequests.Count > 0)
                {
                    _dbContext.RiderRequest.UpdateRange(riderRequests);
                }

                _dbContext.SaveChanges();

                MessageBox.Show("Райдер и запрос райдера успешно созданы в БД.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }

        private Guid GetArtistIdFromText(string selectedArtistText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedArtistText.Split(',');

            if (parts.Length >= 3)
            {
                string firstName = parts[0].Trim();
                string lastName = parts[1].Trim();
                string middleName = parts[2].Trim();
                string passportData = parts[3].Trim();

                Artist artist = _dbContext.Artist.FirstOrDefault(m =>
                    m.FirstName == firstName &&
                    m.LastName == lastName &&
                    m.MiddleName == middleName &&
                    m.PassportData == passportData);

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return artist?.Id ?? Guid.Empty;
            }

            // Если формат не соответствует ожидаемому, возвращаем Guid.Empty
            return Guid.Empty;
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

        private void AddLine(List<string> lines, string prefix, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                lines.Add($"{prefix}: {content}");
            }
        }

        private List<TechnicalParameters> GetExistingTechnicalParameters()
        {
            List<TechnicalParameters> existingTechnicalParameters = _dbContext.TechnicalParameter.ToList();
            return existingTechnicalParameters;
        }

        private void UpdateRiderRequest(List<RiderRequest> riderRequests, string parameter, string content, List<TechnicalParameters> technicalParametersList)
        {
            // Найдите соответствующий TechnicalParameters для параметра райдера
            TechnicalParameters technicalParameters = technicalParametersList.FirstOrDefault(tp => tp.AttributeParameters == parameter);

            // Проверить, что параметр в Rider не пуст
            if (!string.IsNullOrEmpty(content))
            {
                // Найти существующий RiderRequest по параметру
                var existingRequest = riderRequests.FirstOrDefault(rr => rr.RiderParameters.StartsWith($"{parameter}:"));

                if (existingRequest != null)
                {
                    // Обновить существующий RiderRequest
                    existingRequest.RiderParameters = $"{parameter}: {content}";
                    existingRequest.TechnicalParameters = technicalParameters;
                }
                else
                {
                    if (technicalParameters != null)
                    {
                        RiderRequest riderRequest = new RiderRequest
                        {
                            RiderParameters = $"{parameter}: {content}",
                            Rider = existingRider,
                            TechnicalParameters = technicalParameters
                        };

                        riderRequests.Add(riderRequest);
                    }
                }
            }
        }
    }
}
