using WinFormsClient;
using System.Net;
using WinFormsClient.Api;

namespace WinFormsClient
{
    public partial class Auth : Form
    {
        public Main? MainForm;
        public Auth()
        {
            InitializeComponent();
        }

        public void MoveAuthData(string login, string password)
        {
            TBLogin.Text = login;
            TBPassword.Text = password;
        }

        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            string login = TBLogin.Text.ToLower();
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
            Server.Entities.AuthData data = new(login, Security.GetSHA256(password));
            HttpStatusCode res = await UsersApi.SignIn(data);
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
                    DialogResult = await MainForm!.UpdateUser(login) ?
                        DialogResult.OK : DialogResult.Cancel;
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    MessageBox.Show("Сервер недоступен", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ButtonShowPass_Click(object sender, EventArgs e)
        {
            TBPassword.PasswordChar = TBPassword.PasswordChar == '•' ? '\0' : '•';
        }

        private void LinkToRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            MainForm!.RegistrationForm!.MoveAuthData(TBLogin.Text, TBPassword.Text);
            DialogResult = MainForm!.RegistrationForm.ShowDialog();
        }
    }
}
