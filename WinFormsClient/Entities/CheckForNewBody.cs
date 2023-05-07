namespace Server.Entities
{
    public class CheckForNewBody
    {
        public int UserId { get; set; } = 0;
        // public string AccessToken { get; set; } = string.Empty;
        public CheckForNewBody() { }

        public CheckForNewBody(int userId)
        {
            UserId = userId;
        }
    }
}
