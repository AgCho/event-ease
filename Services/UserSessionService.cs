namespace event_ease.Services
{
    public class UserSessionService
    {
        public string UserName { get; private set; } = string.Empty;
        public bool IsLoggedIn { get; private set; } = false;

        public void Login(string userName)
        {
            UserName = userName;
            IsLoggedIn = true;
        }

        public void Logout()
        {
            UserName = string.Empty;
            IsLoggedIn = false;
        }
    }
}