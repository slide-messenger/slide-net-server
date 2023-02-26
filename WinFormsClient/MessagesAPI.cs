using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMessenger
{
    public class MessagesAPI
    {
        private const string route = "api/Messages";
        public static async Task<Message?> GetMessage(int messageId)
        {
            Message? res;
            try
            {
                res = await Client.SharedClient.GetFromJsonAsync<Message>(
            route + "/" + messageId.ToString());
            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message);
                return null;
            }
            return res;
        }
        public static async Task<HttpStatusCode> SendMessage(Message msg)
        {
            using HttpResponseMessage response = await Client.SharedClient.PostAsJsonAsync(
                route,
                msg);
            return response.StatusCode;
/*            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;*/
        }
    }
}
