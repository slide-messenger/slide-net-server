namespace Server.Bodies
{
    public class GetMembersBody
    {
        public int ChatId { get; set; } = 0;
        // public string AccessToken { get; set; } = string.Empty;
        public GetMembersBody() { }

        public GetMembersBody(int chatId)
        {
            ChatId = chatId;
        }
    }
}
