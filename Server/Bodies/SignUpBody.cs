namespace Server.Bodies
{
    public class SignUpBody
    {
        public Entities.User User { get; set; } = new Entities.User();
        public string PasswordHash { get; set; } = string.Empty;
        public SignUpBody() { }

        public SignUpBody(Entities.User user, string passwordHash)
        {
            User = user;
            PasswordHash = passwordHash;
        }
    }
}
