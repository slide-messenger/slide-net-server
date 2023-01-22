using Microsoft.VisualBasic;
using MyMessenger;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        private static int MessageId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            var username = UsernameTB.Text;
            var msg = MessageRTB.Text;
            if (username.Length > 0 && msg.Length > 0)
            {
                MyMessenger.Message m = new(username, msg, DateTime.UtcNow);
                string? res = await MessengerClientAPI.SendMessage(m);
                if (res != null && res.Length > 0)
                {
                    MessageBox.Show($"<Server>: {res}");
                }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            var get = new Func<Task>(async () =>
            {
                var msg = await MessengerClientAPI.GetMessage(MessageId);
                while (msg != null)
                {
                    MessagesRTB.AppendText(msg.ToString() + Environment.NewLine);
                    ++MessageId;
                    msg = await MessengerClientAPI.GetMessage(MessageId);
                }
            });
            get.Invoke();
        }
    }
}