using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class DataHandler
    {
        public List<Person> Users { get; }
        public List<Business_Layer.Store> Stores { get; }
        private DataHandler() {
            Users = new List<Person>();
            Stores = new List<Business_Layer.Store>();
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
