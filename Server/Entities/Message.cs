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
        public DateTime SendAt { get; set; } = DateTime.MinValue;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
        public bool RemoveState { get; set; } = false;
        public Message() { }
        public Message(int chatId, int messageId, int senderId, string content, 
            DateTime sendAt, DateTime? updatedAt = null, bool removeState = false, int globalMessageId = 0)
        {
            GlobalMessageId = globalMessageId;
            ChatId = chatId;
            MessageId = messageId;
            SenderId = senderId;
            Content = content;
            SendAt = sendAt;
            UpdatedAt = updatedAt ?? DateTime.MinValue;
            RemoveState = removeState;
        }
        public override string ToString()
        {
            return $"<{SendAt}> {Sender}: {Content}";
        }
    }
}
