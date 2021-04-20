using System.Collections.Generic;

namespace ConsoleApp1.domainLayer
{
    public class User : Person
    {
        public string UserName { get; }
        public string Password { get; }
        public List<Purchase> history { get; }
        private List<string> messages;
        
        
        public User(string username,string password)
        {
            this.UserName = username;
            this.Password = password;
            shoppingCart = new ShoppingCart();
            history = new List<Purchase>();
            messages = new List<string>();
        }

        public Store OpenStore(string sellpol,string name)
        {
            Store newstore = new Store(this, sellpol, name);
            return newstore;
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

        internal void ReceiveMsg(string msg)
        {
            messages.Add(msg);
        }
    }
}
