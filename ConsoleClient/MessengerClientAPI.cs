using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyMessenger
{
    public class MessengerClientAPI
    {
        private const string Address = "http://localhost";
        private const int Port = 5295;
        private static readonly HttpClient SharedClient = new()
        {
            BaseAddress = new Uri(Address + ":" + Port.ToString()),
        };
        public static async Task<Message?> GetMessage(int MessageId)
        {
            Message? res;
            try
            {
                res = await SharedClient.GetFromJsonAsync<Message>(
            "api/Messenger/" + MessageId.ToString());
            } catch (Exception)
            {
                return null;
            }
            return res;
        }
        public static async Task<string?> SendMessage(Message msg)
        {
            using HttpResponseMessage response = await SharedClient.PostAsJsonAsync(
                "api/Messenger",
                msg);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
    }
}
