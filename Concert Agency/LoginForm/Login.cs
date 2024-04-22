using Client;
using Concert_Agency;
using System;
using System.Net;
using System.Windows.Forms;


namespace LoginForm
{
    public partial class LoginForm : Form
    {
        private readonly ConcertContext _dbContext;
        public LoginForm()
        {
            InitializeComponent();
            _dbContext = new ConcertContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // �������� ��������������
            bool isAuthenticated = Authenticate(username, password);

            if (isAuthenticated)
            {
                // ����������� ���� ������������
                bool isAdmin = CheckAdminRole(username);
                bool isManager = CheckManagerRole(username);

                // ��������������� ������������ � ��������������� �������
                if (isAdmin)
                {
                    // ���� ��� ��������������
                    Admin.Main main = new Admin.Main();
                    main.Show();
                }
                else if (isManager)
                {
                    // ���� ��� ���������
                    Manager.Form1 form1 = new Manager.Form1();
                    form1.Show();
                }
                else
                {
                    // ���� ��� �������
                    var user = _dbContext.Authentication.FirstOrDefault(a => a.username == username && a.password == password);
                    if (user != null)
                    {
                        Guid artistId = user.ArtistId;
                        // ���� ��� ������� � ��������� ArtistId
                        Client.FillRider artistIdentification = new Client.FillRider(artistId);
                        artistIdentification.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to retrieve ArtistId.");
                    }
                }

                Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        // ������� ��������������
        private bool Authenticate(string username, string password)
        {
            // ��������, �������� �� ��������� ����� � ������ ������������������
            if (username == "admin" && password == "adminp")
            {
                return true;
            }
            // ��������, �������� �� ��������� ����� � ������ �������������
            else if (username == "manager" && password == "managerp")
            {
                return true;
            }
            else
            {
                // ����� ������������ � ���� ������ �� ����� ������������ � ������
                var user = _dbContext.Authentication.FirstOrDefault(a => a.username == username && a.password == password);

                // ���� ������������ ������, ���������� true, ����� - false
                return user != null;
            }
        }

        // ������� �������� ���� ��������������
        private bool CheckAdminRole(string username)
        {
            // ���������, �������� �� ��� ������������ ���������������
            return username == "admin";
        }
        private bool CheckManagerRole(string username)
        {
            // ���������, �������� �� ��� ������������ ���������������
            return username == "manager";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // �������� ���������� ����� New
            NewClient newForm = new NewClient();
            // ����������� ����� New
            newForm.Show();
            Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}