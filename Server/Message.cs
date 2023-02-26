using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessenger
{
    // public для сериализации
    [Serializable]
    public class Message
    {
        public Message(string userName, string messageText, DateTime timeStamp)
        {
            UserName = userName;
            MessageText = messageText;
            TimeStamp = timeStamp;
        }

        public Message()
        {
            UserName = "Server";
            MessageText = "Server is running...";
            TimeStamp = DateTime.Now;
        }

        public string UserName { get; set; } = string.Empty;
        public string MessageText { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            string output = $"{UserName} <{TimeStamp}>: {MessageText}";
            return output;
        }
    }
}
