using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admin
{
    public partial class AddOrganizationalRequest : Form
    {
        private readonly ConcertContext _dbContext;
        private Main mainForm;
        public AddOrganizationalRequest(Main mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void AddOrganizationalRequest_Load(object sender, EventArgs e)
        {
            var technicalParameters = _dbContext.TechnicalParameter;

            foreach (var technicalParameter in technicalParameters)
            {
                string technicalParameterInfo = $"{technicalParameter.AttributeParameters}";
                comboBox1.Items.Add(new ComboBoxItem(technicalParameterInfo, technicalParameter.Id));
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            var venues = _dbContext.Venue;

            foreach (var venue in venues)
            {
                string managerInfo = $"{venue.VenueName}, {venue.City}, {venue.Country}";
                comboBox2.Items.Add(new ComboBoxItem(managerInfo, venue.Id));
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string technicalParameter = comboBox1.Text;
            string venue = comboBox2.Text;
            string organizationParameters = textBox1.Text;

            Guid selectedTechnicalParameterId = GetTechnicalParameterIdFromText(technicalParameter);
            Guid selectedVenueId = GetVenueIdFromText(venue);


            if (selectedTechnicalParameterId != Guid.Empty && selectedVenueId != Guid.Empty)
            {
                OrganizationalRequest existingRequest = _dbContext.OrganizationalRequest
            .FirstOrDefault(or =>
                or.TechnicalParameters.Id == selectedTechnicalParameterId &&
                or.Venue.Id == selectedVenueId);

                if (existingRequest != null)
                {
                    existingRequest.OrganizationParameters = organizationParameters;
                }
                else
                {
                    TechnicalParameters selectedTechnicalParameter = _dbContext.TechnicalParameter.FirstOrDefault(tp => tp.Id == selectedTechnicalParameterId);
                    Venue selectedVenue = _dbContext.Venue.FirstOrDefault(v => v.Id == selectedVenueId);

                    OrganizationalRequest organizationalRequest = new OrganizationalRequest
                    {
                        TechnicalParameters = selectedTechnicalParameter,
                        Venue = selectedVenue,
                        OrganizationParameters = organizationParameters,
                    };

                    _dbContext.OrganizationalRequest.Add(organizationalRequest);
                }

                _dbContext.SaveChanges();

                MessageBox.Show("Организационный запрос успешно добавлен");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.EnableMainForm();
        }

        private Guid GetTechnicalParameterIdFromText(string selectedConcertText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedConcertText.Split(',');

            if (parts.Length >= 1)
            {
                string technicalParameterName = parts[0].Trim();

                TechnicalParameters technicalParameter = _dbContext.TechnicalParameter.FirstOrDefault(tp =>
                    tp.AttributeParameters == technicalParameterName);

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return technicalParameter?.Id ?? Guid.Empty;
            }

            // Если формат не соответствует ожидаемому, возвращаем Guid.Empty
            return Guid.Empty;
        }


        private Guid GetVenueIdFromText(string selectedArtistText)
        {
            // Разбиваем текст на части, используя запятые
            string[] parts = selectedArtistText.Split(',');

            if (parts.Length >= 3)
            {
                string venueName = parts[0].Trim();
                string city = parts[1].Trim();
                string country = parts[2].Trim();

                Venue venue = _dbContext.Venue.FirstOrDefault(v =>
                    v.VenueName == venueName &&
                    v.City == city &&
                    v.Country == country);

                // Возвращаем Id места проведения, если найдено, иначе - Guid.Empty
                return venue?.Id ?? Guid.Empty;
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
    }
}
