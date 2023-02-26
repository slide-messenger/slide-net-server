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
    public class Security
    {
        public static string GetSHA256(string str)
        {
            //Convert the string into an array of bytes.
            byte[] messageBytes = Encoding.UTF8.GetBytes(str);

            //Create the hash value from the array of bytes.
            byte[] hashValue = SHA256.HashData(messageBytes);

            return Convert.ToHexString(hashValue);
        }
    }
}
