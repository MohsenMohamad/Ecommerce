using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.LogicLayer
{
    public static class UserLogic
    {
        private static List<string> _loggedInUsers = new List<string>();

        public static long GuestLogin()
        {
            var guest = new Guest();
            if (!DataHandler.Instance.AddGuest(guest)) return -1;

            return guest.GetId();
        }

        // 2.2) Exit as a guest

        public static bool GuestLogout(long guestId)
        {
            return DataHandler.Instance.RemoveGuest(guestId);
        }

        // 2.3) Register

        public static bool Register(string userName, string userPassword)
        {
            if (DataHandler.Instance.Exists(userName))
                return false;
            var user = new User(userName, userPassword);
            return DataHandler.Instance.AddUser(user);
        }

        // 2.4) Login as a user

        public static bool UserLogin(string name, string password)
        {
            var result = !_loggedInUsers.Contains(name) && DataHandler.Instance.Login(name, password);
            if (result)
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

        public static List<string> GetAllUserNamesInSystem()
        {
            return DataHandler.Instance.Users.Keys.ToList();
        }
        /*    
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
            */
        public static string GetHash(string inputString)
        {
            byte[] encrypted = Hashing.GetHash("password");
            var str = System.Text.Encoding.Default.GetString(encrypted);
            if (str != null && !str.Equals(""))
                return str;
            return null;

        }

        public static string GetHashString(string inputString)
        {
            try
            {
                var encrypt = Hashing.GetHashString(inputString);
                return encrypt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}