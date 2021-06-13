using System;
using System.Collections.Generic;
using System.Linq;
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
                throw new Exception(Errors.UserNameNotAvailable);
            
            var user = new User(userName, userPassword);
            if (DataHandler.Instance.AddUser(user)) {
                AddUserNotification(userName, "Welcome  "+ userName+" To Market");
                return true;
            }

            return false;
        }

        // 2.4) Login as a user

        public static bool UserLogin(string name, string password)
        {
            var result = DataHandler.Instance.Login(name, password);
            if (!result)
                throw new Exception(Errors.UserNotFound);
            if (_loggedInUsers.Contains(name)) throw new Exception(Errors.UserAlreadyLoggedIn);
            
            _loggedInUsers.Add(name);
            return true;
        }
        //here shady
        public static void removeuserNotification(string userName, string notification)
        {
            var user =(User)DataHandler.Instance.GetUser(userName);
            for (int i = 0; i < user.GetNotifications().Count; i++)
            {
                if (user.GetNotifications()[i].CompareTo(notification) == 0)
                    user.GetNotifications().RemoveAt(i);
            }
            for (int i = 0; i < user.GetNotificationsoffer().Count; i++)
            {
                if (user.GetNotificationsoffer()[i].CompareTo(notification) == 0)
                    user.GetNotificationsoffer().RemoveAt(i);
            }
            //here shady
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

        public static List<string> GetUserNotifications(string userName)
        {
            var user = DataHandler.Instance.GetUser(userName);
            if (DataHandler.Instance.IsGuest(userName)==-1) {
                return ((User)user)?.GetNotifications();
            }
            return null;
        }

        public static List<string> GetUserNotificationsoffer(string userName)
        {
            var user = DataHandler.Instance.GetUser(userName);
            if (DataHandler.Instance.IsGuest(userName) == -1)
            {
                return ((User)user)?.GetNotificationsoffer();
            }
            return null;
        }
        //here shady
        public static bool AddUserNotification(string userName, string notification)
        {
            var user = DataHandler.Instance.GetUser(userName);
            if (user == null) return false;
            ((User)user).GetNotifications().Add(notification);
            return true;
        }
        //here shady
        public static bool AddUserNotificationoffer(string userName, string notification)
        {
            var user = DataHandler.Instance.GetUser(userName);
            if (user == null) return false;
            ((User)user).GetNotificationsoffer().Add(notification);
            return true;
        }

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