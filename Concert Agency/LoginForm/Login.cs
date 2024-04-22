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

            // Проверка аутентификации
            bool isAuthenticated = Authenticate(username, password);

            if (isAuthenticated)
            {
                // Определение роли пользователя
                bool isAdmin = CheckAdminRole(username);
                bool isManager = CheckManagerRole(username);

                // Перенаправление пользователя в соответствующее решение
                if (isAdmin)
                {
                    // Вход для администратора
                    Admin.Main main = new Admin.Main();
                    main.Show();
                }
                else if (isManager)
                {
                    // Вход для менеджера
                    Manager.Form1 form1 = new Manager.Form1();
                    form1.Show();
                }
                else
                {
                    // Вход для клиента
                    var user = _dbContext.Authentication.FirstOrDefault(a => a.username == username && a.password == password);
                    if (user != null)
                    {
                        Guid artistId = user.ArtistId;
                        // Вход для клиента с передачей ArtistId
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

        // Функция аутентификации
        private bool Authenticate(string username, string password)
        {
            // Проверка, является ли введенный логин и пароль администраторскими
            if (username == "admin" && password == "adminp")
            {
                return true;
            }
            // Проверка, является ли введенный логин и пароль менеджерскими
            else if (username == "manager" && password == "managerp")
            {
                return true;
            }
            else
            {
                // Поиск пользователя в базе данных по имени пользователя и паролю
                var user = _dbContext.Authentication.FirstOrDefault(a => a.username == username && a.password == password);

                // Если пользователь найден, возвращаем true, иначе - false
                return user != null;
            }
        }

        // Функция проверки роли администратора
        private bool CheckAdminRole(string username)
        {
            // Проверяем, является ли имя пользователя администратором
            return username == "admin";
        }
        private bool CheckManagerRole(string username)
        {
            // Проверяем, является ли имя пользователя администратором
            return username == "manager";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы New
            NewClient newForm = new NewClient();
            // Отображение формы New
            newForm.Show();
            Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}