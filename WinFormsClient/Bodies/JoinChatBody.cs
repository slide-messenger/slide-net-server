namespace Server.Bodies
{
    public class JoinChatBody
    {
        public int UserId { get; set; } = 0;
        // public string AccessToken { get; set; } = string.Empty;
        public int ChatId { get; set; } = 0;
        public JoinChatBody() { }

        public JoinChatBody(int userId, int chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }
    }
}
