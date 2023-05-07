namespace Server.Entities
{
    public class Chat
    {
        public int ChatId { get; set; } = 0;
        public int FirstId { get; set; } = 0;
        public int SecondId { get; set; } = 0;
        public int LastMessageId { get; set; } = 0;
        public int ReadMessageId { get; set; } = 0;
        public string ChatName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public Chat() { }

        public Chat(int firstId, string chatName,
            int secondId = 0, int chatId = 0, int lastMessageId = 0,
            int readMessageId = 0, DateTime? createdAt = null)
        {
            ChatId = chatId;
            FirstId = firstId;
            SecondId = secondId;
            LastMessageId = lastMessageId;
            ReadMessageId = readMessageId;
            ChatName = chatName;
            CreatedAt = createdAt ?? DateTime.MinValue;
        }
        public override string ToString()
        {
            return ChatName + " (" + (LastMessageId - ReadMessageId).ToString() + ")";
        }
    }

}
