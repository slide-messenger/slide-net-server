using Microsoft.VisualBasic;
using MyMessenger;
using System.Net;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsClient
{
    public partial class Main : Form
    {
        private static string Login = "";
        private static int MessageId = 0;

        private readonly Auth AuthForm;

        public Main()
        {
            InitializeComponent();
            AuthForm = new() { MainForm = this };
        }
        public void SwitchUser(string login)
        {
            Login = login;
            Text = "Сообщения (" + login + ")";
            MessageId = 0;
        }
        private async void SendButton_Click(object sender, EventArgs e)
        {
            var username = Login;
            var msg = MessageRTB.Text;
            if (username.Length > 0 && msg.Length > 0)
            {
                MyMessenger.Message m = new(username, msg, DateTime.UtcNow);
                HttpStatusCode res = await MessagesAPI.SendMessage(m);
                switch(res)
                {
                    case HttpStatusCode.OK:
                        MessageRTB.Clear();
                        break;
                    default:
                        MessageBox.Show("Произошла неизвестная ошибка при отправке сообщения",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            var get = new Func<Task>(async () =>
            {
                var msg = await MessagesAPI.GetMessage(MessageId);
                while (msg != null)
                {
                    MessagesRTB.AppendText(msg.ToString() + Environment.NewLine);
                    ++MessageId;
                    msg = await MessagesAPI.GetMessage(MessageId);
                }
            });
            get.Invoke();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (AuthForm.ShowDialog() == DialogResult.OK)
            {
                AuthForm.Close();
                UpdateTimer.Enabled = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void MessageRTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButton_Click(sender, e);
            }
        }
    }
}
