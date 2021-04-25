using System.Collections.Generic;

namespace Version1.domainLayer
{
    public class User : Person
    {
        public string UserName { get; }
        public string Password { get; }
        public List<Purchase> history { get; }
        private List<string> notifications { get; }
        
        
        public User(string username,string password)
        {
            UserName = username;
            Password = password;
            shoppingCart = new ShoppingCart();
            history = new List<Purchase>();
            notifications = new List<string>();
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

        internal void AddNotification(string notification)
        {
            notifications.Add(notification);
        }
    }
}
