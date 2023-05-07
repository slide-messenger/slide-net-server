using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Api;
using Server.Entities;

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
            CurrentMessages = list;

            return true;
        }
    }
}
