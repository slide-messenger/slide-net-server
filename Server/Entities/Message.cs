using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Server.Entities
{
    // public для сериализации
    [Serializable]
    public class Message
    {
        public int GlobalMessageId { get; set; } = 0;
        public int ChatId { get; set; } = 0;
        public int MessageId { get; set; } = 0;
        public int SenderId { get; set; } = 0;
        public string Sender { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.MinValue;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
        public bool RemoveState { get; set; } = false;
        public Message() { }
        public Message(int chatId, int senderId, string content, DateTime sentAt)
        {
            ChatId = chatId;
            SenderId = senderId;
            Content = content;
            SentAt = sentAt;
        }
        public Message(int globalMessageId, int chatId, int messageId, int senderId, 
            string content, DateTime sentAt, DateTime updatedAt, bool removeState)
        {
            GlobalMessageId = globalMessageId;
            ChatId = chatId;
            MessageId = messageId;
            SenderId = senderId;
            Content = content;
            SentAt = sentAt;
            UpdatedAt = updatedAt;
            RemoveState = removeState;
        }
        public override string ToString()
        {
            return $"<{SentAt}> {Sender}: {Content}";
        }
    }
}
