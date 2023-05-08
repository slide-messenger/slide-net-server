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
    public class AuthApi
    {
        private const string ROUTE = "api/auth";
        public static async Task<HttpStatusCode> SignIn(Server.Entities.AuthData data)
        {
            return (await Client.PostAsJsonAsync(ROUTE, data)).StatusCode;
        }
    }
}
