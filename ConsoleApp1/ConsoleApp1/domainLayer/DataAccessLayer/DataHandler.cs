using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
     public class DataHandler
    {
        public List<Person> Users { get; }
        public List<Product> Products { get; }
        public List<Business_Layer.Store> Stores { get; }

        public DataHandler() {
            Users = new List<Person>();
            Stores = new List<Business_Layer.Store>();
            Products = new List<Product>();
        }
        private static readonly object padlock = new object();
        private static DataHandler instance = null;
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
