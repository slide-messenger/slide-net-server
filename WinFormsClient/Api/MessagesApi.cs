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
            return await Client.SharedClient.PostAsJsonAsync(
               ROUTE + "/getchats",
               new Server.Entities.GetChatsBody(userId));
        }
        public static async Task<HttpResponseMessage> GetMessages(int userId, int chatId)
        {
            return await Client.SharedClient.PostAsJsonAsync(
               ROUTE + "/getmessages",
               new Server.Entities.GetMessagesBody(userId, chatId));
        }
        public static async Task<HttpResponseMessage> GetMembers(int chatId)
        {
            return await Client.SharedClient.PostAsJsonAsync(
               ROUTE + "/getmessages",
               new Server.Entities.GetMembersBody(chatId));
        }
        public static async Task<HttpResponseMessage> Send(Server.Entities.Message message)
        {
            return await Client.SharedClient.PostAsJsonAsync(
               ROUTE + "/send",
               message);
        }
        public static async Task<HttpResponseMessage> CheckForNew(int userId)
        {
            return await Client.SharedClient.PostAsJsonAsync(
               ROUTE + "/checkfornew",
               new Server.Entities.CheckForNewBody(userId));
        }
    }
}
