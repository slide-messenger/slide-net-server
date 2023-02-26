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
    public class Client
    {
        private const string Address = "http://localhost";
        private const int Port = 5000;
        public static readonly HttpClient SharedClient = new()
        {
            BaseAddress = new Uri(Address + ":" + Port.ToString()),
        };
    }
}
