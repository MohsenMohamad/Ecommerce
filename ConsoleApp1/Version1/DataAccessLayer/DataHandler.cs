using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.DataAccessLayer
{
    public class DataHandler
    {
        public object InefficientLock { get; set; }
        private static readonly object padlock = new object();
        private static DataHandler instance = null;
        internal ConcurrentDictionary<string, User> Users { get; }
        private ConcurrentDictionary<long, Guest> Guests { get; }
        internal ConcurrentDictionary<string,Category> Categories { get; }
        internal ConcurrentDictionary<string, Product> Products { get; }
        internal ConcurrentDictionary<string, Store> Stores { get; }
        private List<Review> Reviews { get; }


        private DataHandler()
        {
            Users = new ConcurrentDictionary<string, User>();
            Guests = new ConcurrentDictionary<long, Guest>();
            Stores = new ConcurrentDictionary<string, Store>();
            Products = new ConcurrentDictionary<string, Product>();
            Reviews = new List<Review>();
            InefficientLock = new object();
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

//------------------------------------------ User ------------------------------------------//

        internal bool AddGuest(Guest guest)
        {
            return Guests.TryAdd(guest.GetId(),guest);
        }
        
        internal bool AddUser(User user)
        {
            return Users.TryAdd(user.UserName, user);
        }

        internal bool RemoveUser(string userName)
        {
            return Users.TryRemove(userName, out _);
        }

        internal bool RemoveGuest(long guestId)
        {
            return Guests.TryRemove(guestId, out _);
        }

        internal Person GetUser(string username)
        {
            var id = IsGuest(username);
            if (id < 0 && Users.ContainsKey(username))
                return Users[username];
            if (id >= 0 && Guests.ContainsKey(id))
                return Guests[id];
            return null;
        }

        internal bool Login(string userName, string password)
        {
            if (!Exists(userName)) return false; 
            
            var user = (User)GetUser(userName);
            return user.Password.Equals(password);
        }

        internal bool Exists(string username)
        {
            return GetUser(username) != null;
        }
        
//------------------------------------------ Store ------------------------------------------//

        internal bool AddStore(Store store)
        {
            lock (Stores)
            {
                if (Stores.ContainsKey(store.GetName()))
                    return false;
                Stores.TryAdd(store.GetName(), store);
                return true;
            }
        }

        internal bool RemoveStore(string storeName)
        {
            lock (Stores)
            {
                return Stores.TryRemove(storeName, out _);
            }
        }

        internal Store GetStore(string storeName)
        {
            lock (Stores)
            {
                if (!Stores.ContainsKey(storeName))
                    return null;
                return Stores[storeName];
            }
        }

        internal bool SendMessageToStore(string msg, string storeName)
        {
            if (!Stores.ContainsKey(storeName))
                return false;

            Stores[storeName].ReceiveMsg(msg);
            return true;
        }

        public string GetStoresInfo()
        {
            var output = "the list of stores:";
            foreach(var store in Stores.Values)
            {
                output += "---------------------/n" + store.ToString();
            }

            return output;
        }

//------------------------------------------ Product ------------------------------------------//

        internal bool AddProduct(Product product)
        {
            lock (Products)
            {
                if (Products.ContainsKey(product.Barcode))
                    return false;
                Products.TryAdd(product.Barcode, product);
                return true;
            }
        }
        internal Product GetProduct(string barcode)
        {
            if (!Products.ContainsKey(barcode))
                return null;
            return Products[barcode];
        }
        
        
        internal void AddReview(string userName, string desc)
        {
            Reviews.Add(new Review(userName, desc));
        }
        
        internal long IsGuest(string userName)
        {
            var result = long.TryParse(userName, out var id);
            if (!result) return -1;
            return id;
        }
    }
}