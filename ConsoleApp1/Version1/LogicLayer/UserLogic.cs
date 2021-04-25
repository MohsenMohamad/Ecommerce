using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class UserLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;
        private static List<string> _loggedInUsers = new List<string>(); 

        public static long GuestLogin()
        {
            var guest = new Guest();
            if (!DataHandler.AddGuest(guest)) return -1;
            
            return guest.GetId();

        }
        
        // 2.2) Exit as a guest

        public static bool GuestLogout(long guestId)
        {
            return DataHandler.RemoveGuest(guestId);
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

        public static bool UserLogin(string name, string password)
        {   
            var result = DataHandler.Login(name, password);
            if(result)
                _loggedInUsers.Add(name);
            return result;
        }
        
        // 3.1 Logout as a user

        public static bool UserLogout(string userName)
        {
            return _loggedInUsers.Remove(userName);
        }
        
        
//------------------------------------ Others ------------------------------------

        public static bool IsLoggedIn(string userName)
        {
            return _loggedInUsers.Contains(userName);
        }

        public static List<string> GetAllLoggedInUsers()
        {
            return _loggedInUsers;
        }
        
        public static List<string> GetUserNotifications(string userName)
        {
            var user = DataHandler.GetUser(userName);
            return user?.GetNotifications();
        }

        public static bool AddUserNotification(string userName, string notification)
        {
            var user = DataHandler.GetUser(userName);
            if (user == null) return false;
            user.AddNotification(notification);
            return true;
        }
    }
}