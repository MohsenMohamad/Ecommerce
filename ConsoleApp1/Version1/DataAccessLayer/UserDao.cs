namespace Version1.DataAccessLayer
{
    public class UserDao
    {
        public string UserName { get; }
        public string Password { get; }

        public UserDao(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

 
    }
}
