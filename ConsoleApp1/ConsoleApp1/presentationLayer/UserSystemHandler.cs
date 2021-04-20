using System;
using System.Collections.Generic;
using ConsoleApp1.DataAccessLayer;
using ConsoleApp1.domainLayer;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.Business_Layer.UserRoles;

namespace ConsoleApp1.presentationLayer
{
    public class UserSystemHandler
    {
        public UserDao logged_in_user { get; }
        public ShoppingHandler shopping { get; }
        private DataHandler data;
        public UserSystemHandler(string username,string password)
        {
            this.logged_in_user = new UserDao(username, password);
            data = DataHandler.Instance;
            shopping = new ShoppingHandler(logged_in_user.UserName);
        }
        private domainLayer.Business_Layer.User get_Bussines_user()
        {
            return data.getUser(logged_in_user.UserName);
            //equals null if user isnt found
        }

        
        
        public DAProduct SearchProductByName(string name) {

            return data.GetproductByName(name);

        }

        public List<DAProduct> SearchProductsByCategory(string category_name)
        {
            List<DAProduct> output = data.SearchProductByCategory(category_name);

            return output;


        }
        public List<DAProduct> SearchProductByKeyWord(string key_word) {
            List<DAProduct> output = data.SearchProductByKeyWord(key_word);

            return output;

        }
        public void WriteReview(string desc)
        {
            data.AddReview(logged_in_user.UserName, desc);
        }

        public void RateProductAndStore()
        {
            throw new NotImplementedException();
        }

        public void SendMessageToStore(string msg,string storename)
        {
            SystemAdmin.RecieveComplainToStore(msg, storename);
        }

        public void SendMessageToUser(string msg, string username)
        {
            SystemAdmin.RecieveComplainToUser(msg, username);
        }

        internal string getbasketinfo()
        {
            domainLayer.Business_Layer.User us = DataHandler.Instance.getUser(logged_in_user.UserName);
            return us.GetBasketInfo();
        }

        internal void buyProduct(string barcode, string store, int amount)
        {
            domainLayer.Business_Layer.User us = DataHandler.Instance.getUser(logged_in_user.UserName);
            domainLayer.Business_Layer.Product pr = DataHandler.Instance.GetProduct(barcode);
            us.AddItemToBasket(store, pr, amount);
            shopping.buyProduct(barcode, amount, store);
        }

        internal void removeItemfromBasket(string store, string barcode)
        {
            User us = DataHandler.Instance.getUser(logged_in_user.UserName);
            us.RemoveItemFromBasket(store, DataHandler.Instance.GetProduct(barcode));
            shopping.removeProduct(barcode, 1, store);
        }

        internal void openStore(string name, string policy)
        {
            User us = DataHandler.Instance.getUser(logged_in_user.UserName);
            DataHandler.Instance.Stores.Add(us.OpenStore(policy, name));
        }

        internal void checkout()
        {
            Console.WriteLine("bougth :");
            for (int i = 0; i < shopping.purchase.items.Count; i++)
            {
                Console.WriteLine(shopping.purchase.items[i].Key.Name+" with amount of "+ shopping.purchase.items[i].Value);
            }
            DataHandler.Instance.getUser(logged_in_user.UserName).history.Add(shopping.purchase);
        }

        internal void showhistory()
        {
            User us = DataHandler.Instance.getUser(logged_in_user.UserName);
            for (int i = 0; i < us.history.Count; i++)
            {
                Console.WriteLine(us.history[i].ToString());
            }
        }
    }
}
