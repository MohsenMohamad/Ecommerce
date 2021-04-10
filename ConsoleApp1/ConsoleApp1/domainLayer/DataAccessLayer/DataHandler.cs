using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class DataHandler
    {
        public List<Person> Users { get; }
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

        private DataHandler() {
            Users = new List<Person>();
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


    }
}
