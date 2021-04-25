using System.Collections.Generic;
using Version1.domainLayer;

namespace Version1.DataAccessLayer
{
    public class DataHandler
    {
        private static readonly object padlock = new object();
        private static DataHandler instance = null;
        internal Dictionary<string, User> Users { get; }
        internal Dictionary<string,Category> Categories { get; }
        internal Dictionary<string, Product> Products { get; }
        internal Dictionary<string, Store> Stores { get; }
        private List<ReviewDao> Reviews { get; }


        private DataHandler()
        {
            Users = new Dictionary<string, User>();
            Stores = new Dictionary<string, Store>();
            Products = new Dictionary<string, Product>();
            Reviews = new List<ReviewDao>();
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


        internal bool AddUser(User user)
        {
            Users.Add(user.UserName, user);
            return true;
        }

        internal bool RemoveUser(string userName)
        {
            Users.Remove(userName);
            return true;
        }

        internal User GetUser(string username)
        {
            if (Users.ContainsKey(username))
                return Users[username];
            return null;
        }

        internal User Login(string userName, string password)
        {
            var user = GetUser(userName);
            if (user != null)
            {
                if (user.Password.Equals(password))
                    return user;
            }
            return null;
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
                Stores.Add(store.GetName(), store);
                return true;
            }
        }

        internal bool RemoveStore(string storeName)
        {
            lock (Stores)
            {
                return Stores.Remove(storeName);
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
                Products.Add(product.Barcode, product);
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
            Reviews.Add(new ReviewDao(userName, desc));
        }
    }
}