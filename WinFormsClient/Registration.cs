using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.Api;

namespace WinFormsClient
{
    public partial class Registration : Form
    {
        public Main? MainForm;
        public Registration()
        {
            InitializeComponent();
        }

        public void MoveAuthData(string login, string password)
        {
            TBUserName.Text = login;
            TBPassword.Text = password;
        }

        private void LinkToAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm!.AuthForm!.MoveAuthData(TBUserName.Text, TBPassword.Text);
            DialogResult = DialogResult.Continue;
        }

        private async void ButtonRegister_Click(object sender, EventArgs e)
        {
            string firstName = TBFirstName.Text;
            string lastName = TBLastName.Text;
            string userName = TBUserName.Text;
            string password = TBPassword.Text;
            string repeatPassword = TBRepeatPassword.Text;

            if (firstName.Length == 0 || lastName.Length == 0 || userName.Length == 0)
            {
                MessageBox.Show("Заполните все поля",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать как минимум 8 символов",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HttpStatusCode res = await UsersApi.SignUp(new Server.Bodies.SignUpBody(
                new Server.Entities.User(
                    firstName,
                    lastName,
                    userName
                    ),
                Security.GetSHA256(password)
                ));
            switch (res)
            {
                case HttpStatusCode.Unauthorized:
                    MessageBox.Show("Пользователь с таким логином уже существует",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case HttpStatusCode.Created:
                    MessageBox.Show("Вы успешно зарегистрированы!",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ButtonShowPass_Click(object sender, EventArgs e)
        {
            TBPassword.PasswordChar = TBPassword.PasswordChar == '•' ? '\0' : '•';
        }

        private void ButtonShowRepeatPass_Click(object sender, EventArgs e)
        {
            TBRepeatPassword.PasswordChar = TBRepeatPassword.PasswordChar == '•' ? '\0' : '•';
        }

        private void TBLastName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
