using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Api
{
    public class MessagesApi
    {
        private const string ROUTE = "api/messages";

        public static async Task<HttpResponseMessage> GetChats(int userId)
        {
            return await Client.PostAsJsonAsync(
               ROUTE + "/getchats",
               new Server.Bodies.GetChatsBody(userId));
        }
        public static async Task<HttpResponseMessage> GetMessages(int userId, int chatId)
        {
            return await Client.PostAsJsonAsync(
               ROUTE + "/getmessages",
               new Server.Bodies.GetMessagesBody(userId, chatId));
        }
        public static async Task<HttpResponseMessage> GetMembers(int chatId)
        {
            return await Client.PostAsJsonAsync(
               ROUTE + "/getmessages",
               new Server.Bodies.GetMembersBody(chatId));
        }
        public static async Task<HttpResponseMessage> Send(Server.Entities.Message message)
        {
            return await Client.PostAsJsonAsync(
               ROUTE + "/send",
               message);
        }
        public static async Task<HttpResponseMessage> CheckForNew(Server.Bodies.CheckForNewBody body)
        {
            return await Client.PostAsJsonAsync(
               ROUTE + "/checkfornew",
               body);
        }
        public static async Task<HttpResponseMessage> CreateChat(Server.Entities.Chat body)
        {
            return await Client.PostAsJsonAsync(
               ROUTE + "/createchat",
               body);
        }
        public static async Task<HttpResponseMessage> JoinChat(Server.Bodies.JoinChatBody body)
        {
            return await Client.PostAsJsonAsync(
               ROUTE + "/joinchat",
               body);
        }
    }
}
