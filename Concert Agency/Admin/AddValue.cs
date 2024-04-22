using Concert_Agency;
using Microsoft.EntityFrameworkCore;

namespace Admin
{
    public partial class AddValue : Form
    {
        private readonly ConcertContext _dbContext;
        private Guid artistId;
        private Main mainForm;

        public AddValue(Main mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open(new AddArtist(this));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Open(new AddManager(this));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Open(new AddVenue(this));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Open(new AddConcert(this));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Open(new AddConcertManager(this));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Open(new AddOrder(this));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Open(new AddTicket(this));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Open(new AddConcertArtist(this));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Open(new AddRider_RiderRequest(this));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Open(new AddTechnicalParameters(this));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Open(new AddOrganizationalRequest(this));
        }

        private void Open(Form form)
        {
            Enabled = false;
            form.Owner = this;
            form.FormClosed += (s, args) => Enabled = true;
            form.Show();
        }

        public void EnableMainForm()
        {
            Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.Show();
        }
    }
}
