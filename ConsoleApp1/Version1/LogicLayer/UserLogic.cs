using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class UserLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        public static bool GuestLogin()
        {
            return true;
        }
        
        // 2.2) Exit as a guest

        public static bool GuestLogout()
        {
            Guest.Instance.Logout();
            return true;
        }
        
        // 2.3) Register

        public static bool Register(string userName, string userPassword)
        {
            if (DataHandler.Exists(userName))
                return false;
            var user = new User(userName, userPassword);
            return DataHandler.AddUser(user);
        }
        
        // 2.4) Login as a user

        public static User UserLogin(string name, string password)
        {
            return DataHandler.Login(name, password);
        }
        
        // 3.1 Logout as a user

        public static bool UserLogout()
        {
            return true;
        }
    }
}