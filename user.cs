namespace SauceDemoTestSuite.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsValid { get; set; }
    }

    public static class UserFactory
    {
        public static User ValidUser => new User
        {
            Username = "standard_user",
            Password = "secret_sauce",
            IsValid = true
        };

        public static User InvalidUser => new User
        {
            Username = "invalid_user",
            Password = "wrong_password",
            IsValid = false
        };
    }
}
