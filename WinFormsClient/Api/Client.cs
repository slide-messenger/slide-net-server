using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WinFormsClient.Api
{
    public class Client
    {
        private const string Address = "http://localhost";
        private const int Port = 5000;
        private static readonly HttpClient SharedClient = new()
        {
            BaseAddress = new Uri(Address + ":" + Port.ToString()),
        };
        public static async Task<HttpResponseMessage> PostAsJsonAsync<TValue>(string uri, TValue value)
        {
            try
            {
                return await SharedClient.PostAsJsonAsync(uri, value);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
        public static async Task<HttpResponseMessage> GetAsync(string uri)
        {
            try
            {
                return await SharedClient.GetAsync(uri);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
