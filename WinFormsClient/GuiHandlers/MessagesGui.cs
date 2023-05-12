using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Api;
using Server.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Microsoft.VisualBasic;
using Server.Bodies;

namespace WinFormsClient.GuiHandlers
{
    public class MessagesGui : GuiHandler
    {
        public List<int> ChatIds = new();
        public Dictionary<int, Chat> Chats = new();
        public int CurrentChatId = 0;
        public List<Server.Entities.Message> CurrentMessages = new();

        public MessagesGui(Main main) : base(main)
        {
        }
        public async Task<int> CheckForUnreadChats()
        {
            using var res = await MessagesApi.CheckForNew(new CheckForNewBody(
                    MainForm.UsersHandler.CurrentUser.UserId,
                    0
                    ));
            switch (res.StatusCode)
            {
                case HttpStatusCode.OK:
                    return 1;
                case HttpStatusCode.NoContent:
                    return 0;
                case HttpStatusCode.ServiceUnavailable:
                    MainForm.ShowErrorAsync();
                    break;
                default:
                    MainForm.ShowErrorAsync(res.StatusCode.ToString());
                    break;
            }
            return 2;
        }
        public async Task<int> CheckForNewMessages()
        {
            using var res = await MessagesApi.CheckForNew(new CheckForNewBody(
                    MainForm.UsersHandler.CurrentUser.UserId,
                    CurrentChatId
                    ));
            switch (res.StatusCode)
            {
                case HttpStatusCode.OK:
                    return 1;
                case HttpStatusCode.NoContent:
                    return 0;
                case HttpStatusCode.ServiceUnavailable:
                    MainForm.ShowErrorAsync();
                    break;
                default:
                    MainForm.ShowErrorAsync(res.StatusCode.ToString());
                    break;
            }
            return 2;
        }
        public async Task<bool> UpdateChats()
        {
            ChatIds.Clear();
            Chats.Clear();
            var list = await ReadFromJson<List<Chat>>(
                    await MessagesApi.GetChats(MainForm.UsersHandler.CurrentUser.UserId));
            if (list is null) { return false; }
            foreach (var chat in list)
            {
                ChatIds.Add(chat.ChatId);
                Chats.Add(chat.ChatId, chat);
            }
            return true;
        }
        public async Task<bool> UpdateMessages()
        {
            CurrentMessages.Clear();
            var list = await ReadFromJson<List<Server.Entities.Message>>(
                await MessagesApi.GetMessages(MainForm.UsersHandler.CurrentUser.UserId, CurrentChatId)
                );
            if (list is null) { return false; }
            foreach (var msg in list)
            {
                msg.SentAt = msg.SentAt.ToLocalTime();
            }
            CurrentMessages = list;

            return true;
        }
        public async Task<bool> StartDialog(int secondId)
        {
            using var res = await MessagesApi.CreateChat(new Chat(
                MainForm.UsersHandler.CurrentUser.UserId,
                MainForm.UsersHandler.CurrentUser.UserId == secondId ?
                ChatType.SavedMessages : ChatType.DirectChat,
                secondId
                ));
            switch (res.StatusCode)
            {
                case HttpStatusCode.OK:
                    return true;
                case HttpStatusCode.NotFound:
                    MainForm.ShowError("Пользователь не найден");
                    break;
                case HttpStatusCode.Conflict:
                    MainForm.ShowError("Вы уже состоите в чате");
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    MainForm.ShowErrorAsync();
                    break;
                default:
                    MainForm.ShowErrorAsync(res.StatusCode.ToString());
                    break;
            }
            return false;
        }
        public async Task<bool> CreateGroupChat(string chatName)
        {
            using var res = await MessagesApi.CreateChat(new Chat(
                MainForm.UsersHandler.CurrentUser.UserId,
                ChatType.GroupChat,
                0,
                chatName
                ));
            switch (res.StatusCode)
            {
                case HttpStatusCode.OK:
                    return true;
                case HttpStatusCode.NotFound:
                    MainForm.ShowError("Пользователь не найден");
                    break;
                case HttpStatusCode.Conflict:
                    MainForm.ShowError("Вы уже состоите в чате");
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    MainForm.ShowErrorAsync();
                    break;
                default:
                    MainForm.ShowErrorAsync(res.StatusCode.ToString());
                    break;
            }
            return false;
        }
        public async Task<bool> JoinChat(int cid)
        {
            using var res = await MessagesApi.JoinChat(new JoinChatBody(
                    MainForm.UsersHandler.CurrentUser.UserId, cid));
            switch (res.StatusCode)
            {
                case HttpStatusCode.OK:
                    return true;
                case HttpStatusCode.ServiceUnavailable:
                    MainForm.ShowErrorAsync();
                    break;
                case HttpStatusCode.Conflict:
                    MainForm.ShowError("Вы уже в этом чате");
                    break;
                case HttpStatusCode.UnprocessableEntity:
                    MainForm.ShowError("Чат является приватным");
                    break;
                case HttpStatusCode.NotFound:
                    MainForm.ShowError("Чат не найден");
                    break;
                default:
                    MainForm.ShowErrorAsync(res.StatusCode.ToString());
                    break;
            }
            return false;
        }
        public async Task<bool> Send(Server.Entities.Message msg)
        {
            using var res = await MessagesApi.Send(msg);
            switch (res.StatusCode)
            {
                case HttpStatusCode.OK:
                    return true;
                case HttpStatusCode.ServiceUnavailable:
                    MainForm.ShowErrorAsync();
                    break;
                default:
                    MainForm.ShowErrorAsync(res.StatusCode.ToString());
                    break;
            }
            return false;
        }
    }
}
