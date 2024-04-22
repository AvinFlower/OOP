using Admin.Delete;
using Concert_Agency;
using Microsoft.EntityFrameworkCore;

namespace Admin
{
    public partial class DeleteValue : Form
    {
        private readonly ConcertContext _dbContext;
        private Guid artistId;
        private Main mainForm;

        public DeleteValue(Main mainForm)
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
            this.mainForm = mainForm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Open(new DeleteArtist(this));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Open(new DeleteConcert(this));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Open(new DeleteRider_RiderRequest(this));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Open(new DeleteTicket(this));
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

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.Show();
        }

        private void DeleteValue_Load(object sender, EventArgs e)
        {

        }
    }
}
