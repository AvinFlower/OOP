using Tickets_for_the_tour;

namespace form_Excursion
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Excursion form_Excursion = new Form_Excursion();
            form_Excursion.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string enteredLogin = textBox1.Text;
            string enteredPassword = textBox2.Text;

            // Check if an admin with the entered login and password exists
            Admin admin = ValidateAdmin(enteredLogin, enteredPassword);

            if (admin != null)
            {
                // Admin exists, open the Form_Admin form
                Form_Admin form_Admin = new Form_Admin();
                form_Admin.ShowDialog();
            }
            else
            {
                // Admin does not exist, show an error message or take appropriate action
                MessageBox.Show("Неверный логин или пароль");
            }
        }
        private Admin ValidateAdmin(string enteredLogin, string enteredPassword)
        {
            using (TourContext context = new TourContext())
            {
                // Check if an admin with the entered login and password exists
                return context.Admins.FirstOrDefault(admin =>
                    admin.login == enteredLogin && admin.password == enteredPassword);
            }
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            bd.ShowDialog();
        }
    }
}