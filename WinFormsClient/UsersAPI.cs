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
    public class UsersAPIRequest
    {
        public string Action { get; set; } = string.Empty;
        public User User { get; set; } = new();

        public UsersAPIRequest(string action, User user)
        {
            Action = action;
            User = user;
        }
        public UsersAPIRequest()
        {
            Action = "";
        }
    }
    public class UsersAPI
    {
        private const string route = "api/Users";
        public static async Task<User?> GetUserById(int userId)
        {
            User? res;
            try
            {
                res = await Client.SharedClient.GetFromJsonAsync<User>(
            route + "/" + userId.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            return res;
        }
        public static async Task<HttpStatusCode> SignUp(User user)
        {
            UsersAPIRequest data = new("signup", user);
            using HttpResponseMessage response = await Client.SharedClient.PostAsJsonAsync(
               route,
               data);
            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> SignIn(User user)
        {
            UsersAPIRequest data = new("signin", user);
            using HttpResponseMessage response = await Client.SharedClient.PostAsJsonAsync(
               route,
               data);
            return response.StatusCode;
        }
    }
}
