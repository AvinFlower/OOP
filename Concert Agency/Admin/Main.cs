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

namespace Admin
{
    public partial class Main : Form
    {
        private readonly ConcertContext _dbContext;
        public Main()
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open(new AddValue(this));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Open(new DeleteValue(this));
        }

        private void Open(Form form)
        {
            Enabled = false;
            form.Owner = this;
            form.FormClosed += (s, args) => Enabled = true;
            form.Show();
            Hide();
        }

        public void EnableMainForm()
        {
            Enabled = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
