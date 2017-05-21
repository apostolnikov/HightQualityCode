namespace IssueTracker.Entity.User
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = HashPassword(password);
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public static string HashPassword(string password)
        {
            return string.Join(string.Empty, SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)).Select(x => x.ToString()));
        }
    }
}
