using System;
using System.Collections.Generic;
using Version1.domainLayer;
using Version1.domainLayer.UserRoles;

namespace Version1.DataAccessLayer
{
    public class UserSystemHandler
    {
        public User logged_in_user { get; }
        public ShoppingHandler shopping { get; }
        private DataHandler data;
        public UserSystemHandler()
        {
            logged_in_user = null;
            data = DataHandler.Instance;
            shopping = new ShoppingHandler();
        }
        private User get_Bussines_user()
        {
            return data.GetUser(logged_in_user.UserName);
            //equals null if user isnt found
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


        internal void checkout()
        {
            Console.WriteLine("bougth :");
            for (int i = 0; i < shopping.purchase.items.Count; i++)
            {
                Console.WriteLine(shopping.purchase.items[i].Key.Name+" with amount of "+ shopping.purchase.items[i].Value);
            }
            DataHandler.Instance.GetUser(logged_in_user.UserName).history.Add(shopping.purchase);
        }

        internal void showhistory()
        {
            User us = DataHandler.Instance.GetUser(logged_in_user.UserName);
            for (int i = 0; i < us.history.Count; i++)
            {
                Console.WriteLine(us.history[i].ToString());
            }
        }
    }
}
