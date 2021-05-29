using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Version1.domainLayer.DataStructures;

namespace Version1.DataAccessLayer
{
    public class DataHandler
    {
        public object InefficientLock { get; }
        private static readonly object Padlock = new object();
        private static DataHandler _instance = null;
        internal ConcurrentDictionary<string, User> Users { get; }
        private ConcurrentDictionary<long, Guest> Guests { get; }
        private ConcurrentDictionary<string, Category> Categories;
        internal ConcurrentDictionary<string, Store> Stores { get; }
        private List<Review> Reviews { get; }
        

        private DataHandler()
        {
            database db = database.GetInstance();
            
            Users = new ConcurrentDictionary<string, User>();
            //upload users
            db.getAllUsers().ToList().ForEach((user) => Users.TryAdd(user.UserName,new User(user.UserName, user.Password)));

            Guests = new ConcurrentDictionary<long, Guest>();
            Stores = new ConcurrentDictionary<string, Store>();
            Reviews = new List<Review>();
            Categories = new ConcurrentDictionary<string, Category>();
            InefficientLock = new object();
            
        }

        public static DataHandler Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new DataHandler();
                    }

                    return _instance;
                }
            }
        }

//------------------------------------------ User ------------------------------------------//

        internal bool AddGuest(Guest guest)
        {
            return Guests.TryAdd(guest.GetId(), guest);
        }

        internal bool AddUser(User user)
        {
            //return Users.TryAdd(user.UserName, user);
            if (Users.TryAdd(user.UserName, user))
            {
                database db = database.GetInstance();
                return db.InsertUser(user);
            }
            return true;
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

            var user = (User) GetUser(userName);
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

        public string GetStoresInfo()
        {
            var output = "the list of stores:";
            foreach (var store in Stores.Values)
            {
                output += "---------------------/n" + store.ToString();
            }

            return output;
        }

//------------------------------------------ Product ------------------------------------------//


        internal Product GetProduct(string barcode, string storeName)
        {
            var store = GetStore(storeName);
            if (store == null) return null;
            foreach (var product in store.GetInventory().Keys)
            {
                if (product.Barcode.Equals(barcode))
                    return product;
            }

            return null;
        }
        
        public bool RemoveProduct(string productBarcode, string storeName)
        {
            var store = GetStore(storeName);
            var product = GetProduct(storeName, productBarcode);
            if (store == null || product == null) return false;
            return store.GetInventory().TryRemove(product, out _);
        }

        internal Dictionary<string, List<Product>> GetAllProducts()
        {
            var products = new Dictionary<string, List<Product>>();
            foreach (var store in Stores.Values)
            {
                var storeProducts = store.GetInventory();
                products.Add(store.GetName(),storeProducts.Keys.ToList());
            }

            return products;
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