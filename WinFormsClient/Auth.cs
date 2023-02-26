using MyMessenger;
using System.Net;

namespace WinFormsClient
{
    public partial class Auth : Form
    {
        public Main? MainForm;
        public Auth()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            string login = TBLogin.Text;
            if (login.Length == 0)
            {
                MessageBox.Show("Логин не может быть пустым",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string password = TBPassword.Text;
            if (password.Length < 8)
            {
                MessageBox.Show("Неверный пароль",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User user = new(login, Security.GetSHA256(password), DateTime.UtcNow);
            HttpStatusCode res = await UsersAPI.SignIn(user);
            switch (res)
            {
                case HttpStatusCode.NotFound:
                    MessageBox.Show("Пользователь с таким логином не найден",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case HttpStatusCode.Unauthorized:
                    MessageBox.Show("Неверный пароль",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case HttpStatusCode.OK:
                    MainForm!.SwitchUser(login);
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    MessageBox.Show("Неизвестная ошибка",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Application.Exit();
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private async void ButtonRegister_Click(object sender, EventArgs e)
        {
            string login = TBLogin.Text;
            if (login.Length == 0)
            {
                MessageBox.Show("Логин не может быть пустым",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string password = TBPassword.Text;
            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать как минимум 8 символов",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User user = new(login, Security.GetSHA256(password), DateTime.UtcNow);
            HttpStatusCode res = await UsersAPI.SignUp(user);
            switch (res)
            {
                case HttpStatusCode.Unauthorized:
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case HttpStatusCode.OK:
                    MessageBox.Show("Вы успешно зарегистрированы!",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("Неизвестная ошибка",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ButtonShowPass_Click(object sender, EventArgs e)
        {
            TBPassword.PasswordChar = TBPassword.PasswordChar == '*' ? '\0' : '*';
        }
    }
}
