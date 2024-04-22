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
            // Собираем данные из текстовых полей
            List<string> lines = new List<string>();

            AddLine(lines, "Звуковая система", textBox1.Text);
            AddLine(lines, "Микшерный пульт", textBox2.Text);
            AddLine(lines, "Микрофоны", textBox3.Text);
            AddLine(lines, "Клавишные", textBox4.Text);
            AddLine(lines, "Гитара", textBox5.Text);
            AddLine(lines, "Декорации", textBox6.Text);
            AddLine(lines, "Безопасность", textBox7.Text);
            AddLine(lines, "Вместимость зала", textBox8.Text);
            AddLine(lines, "Проживание", textBox9.Text);

            string allRider = string.Join(", ", lines);

            // Получаем текущего артиста
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

                // Обновляем или создаем RiderRequest'ы
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

                // Генерируем и присваиваем новый номер RiderRequest
                string newRiderNumber = GenerateRiderNumber(existingRider.Id);

                foreach (var riderRequest in riderRequests)
                {
                    riderRequest.RiderNumber = newRiderNumber;
                }

                _dbContext.SaveChanges();
            }

            // Открываем окно с общей информацией
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



        private void FillRider_Load(object sender, EventArgs e)
        {
            // Проверяем, существует ли уже Rider для данного артиста
            existingRider = _dbContext.Rider.FirstOrDefault(r => r.Artist.Id == _artistId);

            if (existingRider != null)
            {
                // Разбиваем требования райдера на отдельные строки
                string[] requirements = existingRider.Requirements.Split(new string[] { ", " }, StringSplitOptions.None);

                // Заполняем текстовые поля значениями из требований райдера
                foreach (string requirement in requirements)
                {
                    string[] parts = requirement.Split(':');

                    // Проверяем, что строка успешно разделена на параметр и содержимое
                    if (parts.Length == 2)
                    {
                        string parameter = parts[0].Trim();
                        string content = parts[1].Trim();

                        switch (parameter)
                        {
                            case "Звуковая система":
                                textBox1.Text = content;
                                break;
                            case "Микшерный пульт":
                                textBox2.Text = content;
                                break;
                            case "Микрофоны":
                                textBox3.Text = content;
                                break;
                            case "Клавишные":
                                textBox4.Text = content;
                                break;
                            case "Гитара":
                                textBox5.Text = content;
                                break;
                            case "Декорации":
                                textBox6.Text = content;
                                break;
                            case "Безопасность":
                                textBox7.Text = content;
                                break;
                            case "Вместимость зала":
                                textBox8.Text = content;
                                break;
                            case "Проживание":
                                textBox9.Text = content;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Закрываем текущую форму FillRider
            Close();

            // Создаем экземпляр формы ArtistIdentification и передаем в конструктор _artistId
            ArtistIdentification artistIdentification = new ArtistIdentification(_artistId);

            // Открываем форму ArtistIdentification
            artistIdentification.Show();
        }




        private Dictionary<Guid, string> riderNumbers = new Dictionary<Guid, string>();
        private string GenerateRiderNumber(Guid riderId)
        {
            // Проверяем, есть ли уже сгенерированный номер для данного RiderId
            if (riderNumbers.ContainsKey(riderId))
            {
                // Возвращаем существующий номер
                return riderNumbers[riderId];
            }
            else
            {
                // Генерируем случайное число для номера райдера
                Random random = new Random();
                int riderNumberInt = random.Next(1000, 10000); // Генерация числа от 1000 до 9999

                // Преобразуем целое число в строку
                string riderNumber = riderNumberInt.ToString();

                // Проверяем, существует ли уже райдер с таким номером в базе данных
                while (_dbContext.RiderRequest.Any(rr => rr.RiderNumber == riderNumber))
                {
                    // Если такой номер уже существует, генерируем новый
                    riderNumberInt = random.Next(1, 1000);
                    riderNumber = riderNumberInt.ToString();
                }

                // Сохраняем сгенерированный номер в словаре
                riderNumbers[riderId] = riderNumber;

                return riderNumber;
            }
        }
    }
}
