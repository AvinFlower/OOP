using Concert_Agency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class FillRider : Form
    {
        private readonly ConcertContext _dbContext;
        private readonly Guid _artistId;
        private Rider existingRider;

        public FillRider(Guid artistId)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            _artistId = artistId;
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

            Artist currentArtist = _dbContext.Artist.FirstOrDefault(a => a.Id == _artistId);

            if (currentArtist != null)
            {
                // Проверяем, существует ли уже Rider для данного артиста
                existingRider = _dbContext.Rider.FirstOrDefault(r => r.Artist.Id == _artistId);

                if (existingRider == null)
                {
                    // Rider не существует, создаем новый
                    existingRider = new Rider
                    {
                        Requirements = allRider,
                        RiderDate = DateTime.UtcNow,
                        Artist = currentArtist,
                    };

                    _dbContext.Rider.Add(existingRider);
                }
                else
                {
                    // Rider существует, обновляем его данные
                    existingRider.Requirements = allRider;
                    existingRider.RiderDate = DateTime.UtcNow;
                }

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
            }

            Guid riderId = existingRider.Id;
            TotalInfo totalInfo = new TotalInfo(_artistId, riderId);
            totalInfo.Owner = this;
            totalInfo.ShowDialog();
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
            // Соответствующий TechnicalParameters для параметра райдера
            TechnicalParameters technicalParameters = technicalParametersList.FirstOrDefault(tp => tp.AttributeParameters == parameter);

            // Проверить, что параметр в Rider не пуст
            if (!string.IsNullOrEmpty(content))
            {
                // Найти существующий RiderRequest по параметру
                var existingRequest = riderRequests.FirstOrDefault(rr => rr.RiderParameters.StartsWith($"{parameter}:"));

                if (existingRequest != null)
                {
                    existingRequest.RiderParameters = $"{parameter}: {content}";
                    existingRequest.TechnicalParameters = technicalParameters;
                }
                else
                {
                    // Создать новый RiderRequest, только если есть TechnicalParameters
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillRider_Load(object sender, EventArgs e)
        {

        }
    }
}
