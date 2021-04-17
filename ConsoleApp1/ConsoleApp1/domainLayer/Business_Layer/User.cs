using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    public class User : Person
    {
        private string username;
        private string password;
        private ShoppingCart cart;
        public List<Purchase> history { get; }
        private List<string> messages;
        public User(string username,string password)
        {
            this.username = username;
            this.password = password;
            cart = new ShoppingCart(username);
            history = new List<Purchase>();
            messages = new List<string>();
        }


        public void setShoppingchart(ShoppingCart cartt)
        {
            cart = cartt;
        }



        public string UserName { get => username; }
        public string Password { get => password; }
        public ShoppingCart Cart { get => cart;  }
        public void AddItemToBasket(string store_name,Product pr, int amount)
        {
            for (int i = 0; i < cart.baskets.Count; i++)
            {
                if (Cart.baskets[i].Storename.CompareTo(store_name) == 0)
                {
                    cart.baskets[i].addproduct(pr, amount);
                }
            }
        }



        public void RemoveItemFromBasket(string store_name, Product pr)
        {
            for (int i = 0; i < cart.baskets.Count; i++)
            {
                if (Cart.baskets[i].Storename.CompareTo(store_name) == 0)
                {
                    cart.baskets[i].Removeproduct(pr);
                }
            }
        }

        public string GetBasketInfo()
        {
            string output = "--------------------------";
            for (int i = 0; i < cart.baskets.Count; i++)
            {

                output += cart.baskets[i].ToString() + "/n---------------------/n";

            }
            return output;
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
