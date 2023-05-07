namespace Server.Entities
{
    public class GetMessagesBody
    {
        public int UserId { get; set; } = 0;
        public int ChatId { get; set; } = 0;
        // public string AccessToken { get; set; } = string.Empty;
        public GetMessagesBody() { }

        public GetMessagesBody(int userId, int chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }
    }
}
