using System.Collections.Generic;

namespace ServiceLogic.DataAccessLayer.DataStructures
{
    public class User : Person
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Purchase> history { get; set; }
        public List<string> notifications { get; set; }
        public List<string> notificationsoffer { get; set; }


        public User(string username,string password)
        {
            UserName = username;
            Password = password;
            shoppingCart = new ShoppingCart();
            history = new List<Purchase>();
            notifications = new List<string>();
            notificationsoffer = new List<string>();
        }

        
        public string GetPersonalPurchaseHistory()
        {
            string output = "history of "+UserName ;
            for (int i = 0; i < history.Count; i++)
            {
                output += "\n"+history[i].ToString();
            }
            return output;
        }

        public List<string> GetNotifications()
        {
            return notifications;
        }
        
        public List<string> GetNotificationsoffer()
        {
            return notificationsoffer;
        }

    }
}
