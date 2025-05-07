namespace event_ease.Services
{
    public class UserSessionService
    {
        private readonly List<User> _users = new()
        {
            new User { Name = "super", Email = "super@gmail.com", IsLoggedIn = false },
            new User { Name = "admin", Email = "admin@gmail.com", IsLoggedIn = false },
            new User { Name = "user", Email = "user@gmail.com", IsLoggedIn = false }        
        };

        private string? _sessionEmail;

        public event Action? OnChange;

        public string? GetSessionEmail()
        {
            Console.WriteLine($"Session Email: {_sessionEmail}");
            return _sessionEmail;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
        public void AddUser(User newUser)
        {
            if (!_users.Any(u => u.Email == newUser.Email))
            {
                _users.Add(newUser);
            }
        }

        public void DeleteUser(string email)
        {
            var userToDelete = _users.FirstOrDefault(u => u.Email == email);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
            }
        }

        public bool Login(string email)
        {
            var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.IsLoggedIn = true;
                _sessionEmail = email; // Set session email
                NotifyStateChanged();
                return true;
            }
            return false;
        }

        public void Logout()
        {
            if (_sessionEmail != null)
            {
                var user = _users.FirstOrDefault(u => u.Email.Equals(_sessionEmail, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    user.IsLoggedIn = false;
                }
                _sessionEmail = null; // Clear session email
                NotifyStateChanged();
            }
        }

        public bool IsUserLoggedIn(string email)
        {
            var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return user?.IsLoggedIn ?? false;
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}