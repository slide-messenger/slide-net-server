namespace Server.Entities
{
    public class AuthData
    {
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public AuthData() { }

        public AuthData(string username, string passwordHash)
        {
            UserName = username;
            PasswordHash = passwordHash;
        }
    }
}
