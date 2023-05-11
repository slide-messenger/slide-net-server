using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsClient.Api
{
    public class UsersApi
    {
        private const string ROUTE = "api/users";
        public static async Task<HttpResponseMessage> Get(string username)
        {
            return await Client.GetAsync(ROUTE + "/get/" + username);
        }
        public static async Task<HttpResponseMessage> Get(int id)
        {
            return await Client.GetAsync(ROUTE + "/get/" + id.ToString());
        }
        public static async Task<HttpStatusCode> SignUp(Server.Bodies.SignUpBody body)
        {
            return (await Client.PostAsJsonAsync(ROUTE + "/signup", body)).StatusCode;
        }
        public static async Task<HttpStatusCode> SignIn(Server.Entities.AuthData data)
        {
            return (await Client.PostAsJsonAsync(ROUTE + "/signin", data)).StatusCode;
        }
    }
}
