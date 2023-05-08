namespace Server.Bodies
{
    public class CheckForNewBody
    {
        public int UserId { get; set; } = 0;
        public int ChatId { get; set; } = 0;
        // public string AccessToken { get; set; } = string.Empty;
        public CheckForNewBody() { }

        public CheckForNewBody(int userId, int chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }
    }
}
