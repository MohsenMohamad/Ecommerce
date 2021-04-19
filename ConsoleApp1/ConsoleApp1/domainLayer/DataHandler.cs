using System;
using System.Collections.Generic;
using ConsoleApp1.DataAccessLayer;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;

namespace ConsoleApp1.domainLayer
{
    public class DataHandler
    {
        public List<User> Users { get; }
        public List<Product> Products { get; }
        public List<Business_Layer.Store> Stores { get; }
        public List<ReviewDao> reviews { get; }

        internal StoreDao GetStore(string storename)
        {
            for (int i = 0; i < Stores.Count; i++)
            {
                if (Stores[i].Name.CompareTo(storename) == 0)
                    return new StoreDao(storename);
            }
            return null;
        }
        internal Store GetBUSStore(string storename)
        {
            for (int i = 0; i < Stores.Count; i++)
            {
                if (Stores[i].Name.CompareTo(storename) == 0)
                    return Stores[i];
            }
            return null;
        }

        internal Product GetProduct(string barcode)
        {
            for (int i = 0; i < Stores.Count; i++)
            {
                if (Products[i].Barcode.CompareTo(barcode) == 0)
                    return Products[i];
            }
            return null;
        }

        private  DataHandler() {
            Users = new List<User>();
            Stores = new List<Business_Layer.Store>();
            Products = new List<Product>();
            reviews = new List<ReviewDao>();
        }
        private static readonly object padlock = new object();
        private static DataHandler instance = null;


        internal Business_Layer.User getUser(string username)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                Type t = Users[i].GetType();
                if (t.Equals(typeof(Business_Layer.User)))
                {
                    if (((Business_Layer.User)Users[i]).UserName.CompareTo(username) == 0)
                        return (Business_Layer.User)Users[i];
                }

            }
            return null;
        }

        public DAProduct GetproductByName(string name)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Product pr = Products[i];
                if (pr.Name.CompareTo(name) == 0)
                    return new DAProduct(name, pr.Description, pr.Barcode);
            }
            return null;
        }

        internal List<DAProduct> SearchProductByCategory(string category_name)
        {
            List<DAProduct> output = new List<DAProduct>();
            for (int i = 0; i < Products.Count; i++)
            {
                Product pr = Products[i];
                for (int j = 0; j < pr.Categories.Count; j++)
                {
                    if (pr.Categories[j].Name.CompareTo(category_name) == 0)
                        output.Add(new DAProduct(pr.Name, pr.Description, pr.Barcode));

                }
            }
          

            return output;
        }

        internal void SendMessageToStore(string msg, string storename)
        {
            for (int i = 0; i < Stores.Count; i++)
            {
                if (Stores[i].Name.CompareTo(storename) == 0)
                    Stores[i].ReceiveMsg(msg);
            }
        }

        internal void addStore(Store store)
        {
            Stores.Add(store);
        }
        
        
        public string GetStoresInfo()
        {
            string output = "the list of stores:";
            for (int i = 0; i < Stores.Count; i++)
            {
                output += "---------------------/n" + Stores[i].ToString();
            }
            return output;
        }

        public Store GetStoreinfo(string name)
        {
            for (int i = 0; i < Stores.Count; i++)
            {
                if (Stores[i].Name.CompareTo(name) == 0)
                {
                    return Stores[i];
                }

            }
            return null;
        }

        public string GetStoresInfo(string username)
        {
            string output = "the list of stores:";
            bool flag = false;
            for (int i = 0; i < Stores.Count; i++)
            {
                flag = false;
                for (int j = 0; j < Stores[i].managers.Count; j++)
                {
                    if (Stores[i].managers[i].UserName.CompareTo(username) == 0)
                        flag = true;
                }
                for (int j = 0; j < Stores[i].co_owners.Count; j++)
                {
                    if (Stores[i].co_owners[i].UserName.CompareTo(username) == 0)
                        flag = true;
                }
                if (Stores[i].Owner.UserName.CompareTo(username)==0||flag)
                    output += "---------------------/n" + Stores[i].ToString();
            }
            return output;
        }

        public string GetProductsInfo()
        {
            string output = "the list of products";
            for (int i = 0; i < Products.Count; i++)
            {
                output += "----------------/n" + Products[i].ToString();
            }
            return output;
        }



        internal void AddReview(string userName, string desc)
        {
            reviews.Add(new ReviewDao(userName, desc));

        }

        internal List<DAProduct> SearchProductByKeyWord(string key_word)
        {
            List<DAProduct> output = new List<DAProduct>();
            for (int i = 0; i < Products.Count; i++)
            {
                Product pr = Products[i];
                for (int j = 0; j < pr.Categories.Count; j++)
                {
                    if (pr.Categories[j].Name.Contains(key_word))
                        output.Add(new DAProduct(pr.Name, pr.Description, pr.Barcode));

                }
            }


            return output;
        }

        public static DataHandler Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DataHandler();
                    }
                    return instance;
                }
            }
        }
           
        public void register(string username,string password)
        {
            User us = new User(username, password);
            Users.Add(us);
        }

        public bool login(string username,string password)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName.CompareTo(username) == 0 && Users[i].Password.CompareTo(password) == 0)
                    return true;
            }
            return false;
        }

        public User loginuser(string username, string password)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName.CompareTo(username) == 0 && Users[i].Password.CompareTo(password) == 0)
                    return Users[i];
            }
            return null;
        }

        public  bool exist(string username)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName.CompareTo(username) == 0)
                    return true;
            }
            return false;
        }
    }
}
