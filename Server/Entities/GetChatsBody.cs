namespace Server.Entities
{
    public class GetChatsBody
    {
        public int UserId { get; set; } = 0;
        // public string AccessToken { get; set; } = string.Empty;
        public GetChatsBody() { }

        public GetChatsBody(int userId)
        {
            UserId = userId;
        }
    }
}
