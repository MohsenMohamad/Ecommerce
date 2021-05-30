using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Version1.domainLayer.DataStructures;

namespace Version1.DataAccessLayer
{
    public class DataHandler
    {
        public object InefficientLock { get; }
        private static readonly object Padlock = new object();

        private static DataHandler _instance = null;
        public ConcurrentDictionary<string, User> Users { get; }
        private ConcurrentDictionary<long, Guest> Guests { get; }
        private ConcurrentDictionary<string, Category> Categories;
        internal ConcurrentDictionary<string, Store> Stores { get; }
        private List<Review> Reviews { get; }
        public JavaScriptSerializer oJS;

        private DataHandler()
        {
            
            oJS = new JavaScriptSerializer();
            Users = new ConcurrentDictionary<string, User>();
            database db = database.GetInstance();
            //upload users
            if (db != null && db.getAllUsers() != null)
            {
                db.getAllUsers().ToList().ForEach((user) =>
                {
                    if (user != null)
                        Users.TryAdd(user.UserName, getUserFromUserDb(user));
                        //Users.TryAdd(user.UserName, new User(user.UserName,user.Password));
                        else
                        habal();

                });
            }




            Guests = new ConcurrentDictionary<long, Guest>();
            Stores = new ConcurrentDictionary<string, Store>();
            /*db.getAllStores().ToList().ForEach((store) => Stores.TryAdd(store.storeName, new Store(
                store.staff.key,
                store.storeName)));*/


            Reviews = new List<Review>();
            Categories = new ConcurrentDictionary<string, Category>();
            InefficientLock = new object();
            
        }

        private bool habal()
        {
            return true;
        }

        private User getUserFromUserDb(UserDB u)
        {
            User user = new User(u.UserName, u.Password);
            
            /*user.notifications = oJS.Deserialize<List<string>>(u.notifications);

            user.history = new List<Purchase>();
            if (u.history != null)
            {
                u.history.ToList().ForEach((p) =>
                {
                    if (p != null)
                        user.history.Add(getPurchaseFromPurchaseDB(p));
                });
            }

            user.shoppingCart = getShoppingCartFromshoppingCartDB(u.shoppingCart);
            */

            return user;
        }

        

        private Purchase getPurchaseFromPurchaseDB(PurchaseDB p)
        {
            Purchase purchase = new Purchase();

            purchase.purchaseId = p.purchaseId;
            purchase.purchaseType = oJS.Deserialize<Purchase.PurchaseType>(p.purchaseType);
            purchase.store = p.storeName;
            purchase.user = p.UserName;
            purchase.date = p.date;
            
            return purchase;
        }

        private ShoppingCart getShoppingCartFromshoppingCartDB(ShoppingCartDB sh)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            //shoppingCart.id = sh.ShoppingCartId;

            /*List<ShoppingBasketDB> ShoppingBasketHash = new List<ShoppingBasketDB>(sh.shoppingBaskets.values);
            List<string> hashStrings = oJS.Deserialize<List<string>>(sh.shoppingBaskets.keys);

            for(int i = 0; i < ShoppingBasketHash.Count; i++)
            {
                ShoppingBasket temp = getShopingBasketFromShopingBasketDB(ShoppingBasketHash[i]);
                shoppingCart.shoppingBaskets.Add(hashStrings[i], temp);
            }*/

            return shoppingCart;
        }

        private ShoppingBasket getShopingBasketFromShopingBasketDB(ShoppingBasketDB sh)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket(sh.StoreName);
            shoppingBasket.id = sh.id;
            shoppingBasket.Products = oJS.Deserialize<Dictionary<string, int>>(sh.Products);
            
            return shoppingBasket;
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
                if (db.db.UsersTable.Any(o => o.UserName == user.UserName))
                {
                    //alreadyExist
                     return false;
                }
                else
                {
                    //db.db.UsersTable.ToList().ForEach((u) => Console.WriteLine(u.UserName));
                    return db.InsertUser(user);
                    //return db.InsertUser(new User(user.UserName,user.Password));
                }
                
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
                if(Stores.TryAdd(store.GetName(), store))
                {
                    database db = database.GetInstance();
                    //db.InsertNode(store.staff);
                    db.InsertStore(store);
                    return true;
                }

                return false;
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