namespace Server.Entities
{
    public enum ChatType
    {
        DirectChat,
        GroupChat,
        SavedMessages
    }
    public class Chat
    {
        public int ChatId { get; set; } = 0;
        public ChatType Type { get; set; } = ChatType.DirectChat;
        public int FirstId { get; set; } = 0;
        public int SecondId { get; set; } = 0;
        public int LastMessageId { get; set; } = 0;
        public int ReadMessageId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public Chat() { }
        public Chat(int firstId, ChatType type = ChatType.DirectChat, 
            int secondId = 0, string name = "")
        {
            FirstId = firstId;
            Type = type;
            SecondId = secondId;
            Name = name;
        }
        public Chat(int chatId, ChatType type, int firstId, int secondId,
            int lastMessageId, int readMessageId, string name, DateTime createdAt)
        {
            ChatId = chatId;
            Type = type;
            FirstId = firstId;
            SecondId = secondId;
            LastMessageId = lastMessageId;
            ReadMessageId = readMessageId;
            Name = name;
            CreatedAt = createdAt;
        }
        public override string ToString()
        {
            return Name + " (" + (LastMessageId - ReadMessageId).ToString() + ")";
        }
    }
}
