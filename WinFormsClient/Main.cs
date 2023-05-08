using System.Net;
using System.Net.Http.Json;
using WinFormsClient.Api;
using WinFormsClient.GuiHandlers;
using Server.Entities;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsClient
{
    public partial class Main : Form
    {
        public Auth? AuthForm;
        public Registration? RegistrationForm;

        public readonly GeneralGui GeneralHandler;
        public readonly UsersGui UsersHandler;
        public readonly MessagesGui MessagesHandler;

        public Main()
        {
            InitializeComponent();

            GeneralHandler = new(this);
            UsersHandler = new(this);
            MessagesHandler = new(this);
        }
        public async void QuitUser()
        {
            UpdateTimer.Stop();

            UsersHandler.CurrentUser = new();
            MessagesHandler.CurrentChatId = 0;
            MessagesHandler.ChatIds.Clear();
            MessagesHandler.Chats.Clear();
            LBChats.Items.Clear();
            RTBTypeMessage.Clear();
            RTBMessages.Clear();

            if (AuthForm is null || AuthForm.IsDisposed)
            {
                AuthForm = new() { MainForm = this };
            }
            if (RegistrationForm is null || RegistrationForm.IsDisposed)
            {
                RegistrationForm = new() { MainForm = this };
            }

            Hide();
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

            Show();
            AuthForm.Close();
            if (!await UpdateUser()) { return; }
            if (!await UpdateChats()) { return; }
            UpdateTimer.Enabled = true;
        }
        public void ShowError(string desc = "Сервер недоступен!")
        {
            UpdateTimer.Stop();
            if (MessageBox.Show($"Произошла ошибка. Код: {desc}",
                "SlideMessenger", MessageBoxButtons.OK, MessageBoxIcon.Error) ==
                DialogResult.OK)
            {
                QuitUser();
            }
        }
        public void ShowErrorAsync(string desc = "Сервер недоступен!")
        {
            UpdateTimer.Stop();
            LabelChatname.Text = desc;
            LabelChatname.ForeColor = Color.Red;
        }
        public async Task<bool> UpdateUser(string? username = null)
        {
            var user = await GeneralHandler.ReadFromJson<User>(
                UsersApi.Get(username ?? UsersHandler.CurrentUser.UserId.ToString()));
            if (user is null) { return false; }

            UsersHandler.CurrentUser = user;
            LabelFirstName.Text = UsersHandler.CurrentUser.FirstName;
            LabelLastName.Text = UsersHandler.CurrentUser.LastName;
            LabelChatname.ForeColor = DefaultForeColor;
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
            if (MessagesHandler.CurrentChatId == 0) { return true; }
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

                RTBMessages.SelectionStart = RTBMessages.TextLength;
                RTBMessages.ScrollToCaret();

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
            if (await MessagesHandler.Send(new Server.Entities.Message
            (
                MessagesHandler.CurrentChatId,
                0,
                UsersHandler.CurrentUser.UserId,
                content,
                DateTime.UtcNow)))
            {
                RTBTypeMessage.Clear();
                await UpdateMessages();
                await UpdateChats();
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            var self = (System.Windows.Forms.Timer)sender;
            var get = new Func<Task>(async () =>
            {
                self.Stop();
                using (var res = await MessagesApi.CheckForNew(new Server.Bodies.CheckForNewBody(
                    UsersHandler.CurrentUser.UserId,
                    MessagesHandler.CurrentChatId
                    )))
                {
                    switch (res.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            if (!await UpdateMessages())
                            {
                                ShowErrorAsync("Не удалось обновить сообщения");
                                return;
                            }
                            break;
                        case HttpStatusCode.NotFound:
                            break;
                        case HttpStatusCode.ServiceUnavailable:
                            ShowErrorAsync();
                            return;
                        default:
                            ShowErrorAsync(res.StatusCode.ToString());
                            return;
                    }
                }
                using (var res = await MessagesApi.CheckForNew(new Server.Bodies.CheckForNewBody(
                    UsersHandler.CurrentUser.UserId,
                    0
                    )))
                {
                    switch (res.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            if (!await UpdateChats())
                            {
                                ShowErrorAsync("Не удалось обновить список чатов");
                                return;
                            }
                            break;
                        case HttpStatusCode.NotFound:
                            break;
                        case HttpStatusCode.ServiceUnavailable:
                            ShowErrorAsync();
                            return;
                        default:
                            ShowErrorAsync(res.StatusCode.ToString());
                            return;
                    }
                }
                self.Start();
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

        private void LinkQuit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuitUser();
        }

        private void ButtonProfileInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UsersHandler.CurrentUser.ToString(), "Мой профиль", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ButtonJoinChat_Click(object sender, EventArgs e)
        {
            using var dlg = new InputBox("Введите ссылку на чат:");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var link = dlg.Result;
                MessageBox.Show(link);
            }
        }

        private void ButtonCreateChat_Click(object sender, EventArgs e)
        {
            using var dlg = new InputBox("Введите название чата:");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var name = dlg.Result;
                MessageBox.Show(name);
            }
        }

        private void ButtonGetLink_Click(object sender, EventArgs e)
        {
            if (MessagesHandler.CurrentChatId == 0)
            {
                MessageBox.Show("Чат не выбран!",
                "SlideMessenger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var chat = MessagesHandler.Chats[MessagesHandler.CurrentChatId];
            string link;
            if (chat.SecondId == 0)
            {
                link = $"cid={chat.ChatId}";
                MessageBox.Show($"Ссылка на чат скопирована в буфер обмена:\n{link}", "Получить ссылку",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                link = $"uid={(UsersHandler.CurrentUser.UserId == chat.FirstId ? chat.SecondId : chat.FirstId)}";
                MessageBox.Show($"Ссылка на собеседника скопирована в буфер обмена:\n{link}", "Получить ссылку",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Clipboard.SetText(link);
        }
    }
}
