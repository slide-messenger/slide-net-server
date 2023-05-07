using System.Net;
using System.Net.Http.Json;
using WinFormsClient.Api;
using WinFormsClient.GuiHandlers;
using Server.Entities;
using System.Collections.Generic;
using System;

namespace WinFormsClient
{
    public partial class Main : Form
    {
        public readonly Auth AuthForm;
        public readonly Registration RegistrationForm;

        public readonly GeneralGui GeneralHandler;
        public readonly UsersGui UsersHandler;
        public readonly MessagesGui MessagesHandler;

        public Main()
        {
            InitializeComponent();
            AuthForm = new() { MainForm = this };
            RegistrationForm = new() { MainForm = this };
            GeneralHandler = new(this);
            UsersHandler = new(this);
            MessagesHandler = new(this);
        }
        public async void QuitUser()
        {
            LBChats.Items.Clear();
            RTBTypeMessage.Clear();
            RTBMessages.Clear();
            UpdateTimer.Stop();

            DialogResult res = AuthForm.ShowDialog();
            while (res != DialogResult.OK)
            {
                if (res != DialogResult.Continue)
                {
                    Application.Exit();
                    return;
                }
                res = AuthForm.ShowDialog();
            }

            AuthForm.Close();
            if (!await UpdateUser()) { return; }
            if (!await UpdateChats()) { return; }
            UpdateTimer.Enabled = true;
        }
        public void RaiseErrorAndQuit(string description = "")
        {
            UpdateTimer.Stop();
            if (MessageBox.Show($"Произошла ошибка. Код: {description}",
                "SlideMessenger", MessageBoxButtons.OK, MessageBoxIcon.Error) ==
                DialogResult.OK)
            {
                QuitUser();
            }
        }
        public async Task<bool> UpdateUser(string? username = null)
        {
            var user = await GeneralHandler.ReadFromJson<User>(
                UsersApi.Get(username ?? UsersHandler.CurrentUser.UserId.ToString()));
            if (user is null) { return false; }

            UsersHandler.CurrentUser = user;
            LabelFirstName.Text = UsersHandler.CurrentUser.FirstName;
            LabelLastName.Text = UsersHandler.CurrentUser.LastName;
            LabelChatname.Text = "Выберите чат";

            return true;
        }
        public async Task<bool> UpdateChats()
        {
            LBChats.Items.Clear();
            if (await MessagesHandler.UpdateChats())
            {
                foreach (var chat in MessagesHandler.Chats)
                {
                    LBChats.Items.Add(chat.Value.ToString());
                }
                return true;
            }
            return false;
        }
        private async Task<bool> UpdateMessages()
        {
            if (MessagesHandler.CurrentChatId == 0) { return false; }
            RTBMessages.Clear();
            if (await MessagesHandler.UpdateMessages())
            {
                foreach (var msg in MessagesHandler.CurrentMessages)
                {
                    RTBMessages.AppendText(msg.ToString() + Environment.NewLine);
                    if (msg.SenderId == UsersHandler.CurrentUser.UserId)
                    {
                        int lineIdx = RTBMessages.Lines.Length - 2;
                        RTBMessages.Select(RTBMessages.
                            GetFirstCharIndexFromLine(lineIdx),
                            RTBMessages.Lines[lineIdx].Length);
                        RTBMessages.SelectionColor = Color.DodgerBlue;
                    }
                }

                LabelChatname.Text = MessagesHandler.
                    Chats[MessagesHandler.CurrentChatId].ChatName;

                return true;
            }
            return false;
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            var content = RTBTypeMessage.Text;
            if (content.Length == 0 || MessagesHandler.CurrentChatId == 0) { return; }
            var body = new Server.Entities.Message
            (
                MessagesHandler.CurrentChatId,
                0,
                UsersHandler.CurrentUser.UserId,
                content
            );

            var res = await MessagesApi.Send(body);
            if (res.IsSuccessStatusCode)
            {
                RTBTypeMessage.Clear();
                await UpdateMessages();
                await UpdateChats();
            }
            else
            {
                RaiseErrorAndQuit(res.StatusCode.ToString());
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            var get = new Func<Task>(async () =>
            {
                var res = await MessagesApi.CheckForNew(UsersHandler.CurrentUser.UserId);
                switch (res.StatusCode)
                {
                    case HttpStatusCode.OK:
                        await UpdateMessages();
                        await UpdateChats();
                        break;
                    case HttpStatusCode.NotFound:
                        break;
                    default:
                        RaiseErrorAndQuit(res.StatusCode.ToString());
                        break;
                }
            });
            get.Invoke();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            QuitUser();
        }

        private void MessageRTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButton_Click(sender, e);
            }
        }

        private async void LBChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBChats.SelectedIndex >= 0)
            {
                MessagesHandler.CurrentChatId = MessagesHandler.ChatIds[LBChats.SelectedIndex];
            }
            await UpdateMessages();
            await UpdateChats();
        }
        private void MessageRTB_Click(object sender, EventArgs e)
        {
            var self = (RichTextBox)sender;
            if (self.Text == "Написать сообщение...")
            {
                self.Clear();
            }
        }
    }
}
