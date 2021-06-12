using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.StorePolicies;

namespace Version1.DataAccessLayer
{
    public class DataHandler
    {
        public object InefficientLock { get; }
        private static readonly object Padlock = new object();

        private static DataHandler _instance = null;
        public ConcurrentDictionary<string, User> Users { get; }
        internal ConcurrentDictionary<string, Store> Stores { get; }
        private ConcurrentDictionary<long, Guest> Guests { get; }
        private ConcurrentDictionary<string, Category> Categories;
        public List<PurchaseOffer> Offers { get; set; }
        
        private List<Review> Reviews { get; }
        public JavaScriptSerializer oJS;
        private DataHandler()
        {

            oJS = new JavaScriptSerializer();
            database db = database.GetInstance();

            Users = new ConcurrentDictionary<string, User>();
            //upload users
            uploadUsers(db);

            Stores = new ConcurrentDictionary<string, Store>();
            //upload stores
            uploadStores(db);

            //fresh list
            Guests = new ConcurrentDictionary<long, Guest>();

            Reviews = new List<Review>();
            Categories = new ConcurrentDictionary<string, Category>();
            Offers = new List<PurchaseOffer>();
            InefficientLock = new object();
        }

        private void uploadUsers(database db)
        {
            if (db != null && db.getAllUsers() != null)
            {
                db.getAllUsers().ToList().ForEach((user) =>
                {
                    if (user != null)
                        Users.TryAdd(user.UserName, getUserFromUserDb(user));
                    //Users.TryAdd(user.UserName, new User(user.UserName,user.Password));

                });
            }
        }

        private void uploadStores(database db)
        {
            if (db != null && db.getAllStores() != null)
            {
                db.getAllStores().ToList().ForEach((store) =>
                {
                    if (store != null)
                        Stores.TryAdd(store.storeName, getStoreFromStoreDb(store));
                    //Users.TryAdd(user.UserName, new User(user.UserName,user.Password));
                });
            }
        }

       

        private Store getStoreFromStoreDb(StoreDB s)
        {
            Store store = new Store(s.storeOwner, s.storeName);

            if(s.paymentInfo != null)
            {
                store.paymentInfo = oJS.Deserialize<List<string>>(s.paymentInfo);
            }
            if (s.notifications != null)
            {
                store.notifications = oJS.Deserialize<List<string>>(s.notifications);
            }
            if (s.purchasePolicies != null)
            {
                store.purchasePolicies = s.purchasePolicies.ToList();
            }

            if (s.history != null)
            {
                s.history.ToList().ForEach((p) =>
                {
                    if (p != null)
                        store.history.Add(getPurchaseFromPurchaseDB(p));
                });
            }

            //upload inventory hashmap
            store.inventory = new ConcurrentDictionary<Product, int>();
            if(s.inventory != null)
            {
                List<int> values = oJS.Deserialize<List<int>>(s.inventory.values);
                List<Product> keys = new List<Product>();
                foreach (ProductDB p in s.inventory.keys.ToList())
                {
                    keys.Add(getProductFromProductDB(p));
                }

                if (keys.Count == values.Count)
                {
                    for (int i = 0; i < keys.Count; i++)
                    {
                        store.inventory.TryAdd(keys.ElementAt(i), values.ElementAt(i));
                    }
                }
                else
                {
                    throw new Exception("keys.Count != values.Count");
                }
            }
            if(s.staff != null)
            {   
                store.staff = getNode(s.staff);
            }
            

            /*store.discounts = new List<Discount>();
            foreach (DiscountDB dis in s.discounts)
            {
                store.discounts.Add(getDiscountFromDiscountDB(dis));
            }*/

            return store;
        }
        private Node<string, int> getNode(NodeDB n)
        {
            Node<string, int> node = new Node<string, int>(n.key,n.value);
            node.Children = new List<Node<string, int>>();
            n.Children.ToList().ForEach((child) => node.Children.Add(getNode(child)));
            return node;
        }

        /*private Discount getDiscountFromDiscountDB(DiscountDB dis)
        {
            Discount discount = new Discount(dis.)
        }*/

  
        private User getUserFromUserDb(UserDB u)
        {
            User user = new User(u.UserName, u.Password);
            
            user.notifications = oJS.Deserialize<List<string>>(u.notifications);

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

            List<int> values = oJS.Deserialize<List<int>>(p.items.values);
            List<Product> keys = new List<Product>();

            foreach(ProductDB productdb in p.items.keys)
            {
                keys.Add(getProductFromProductDB(productdb));
            }
            //here I have got all the keys and the values.


            purchase.items = new List<KeyValuePair<Product, int>>();

            if(keys.Count == values.Count)
            {
                for(int i = 0; i < keys.Count; i++)
                {
                    purchase.items.Add(new KeyValuePair<Product, int>(keys.ElementAt(i), values.ElementAt(i)));
                }
            }
            else
            {
                throw new Exception("keys.Count != values.Count");
            }
            
            return purchase;
        }

        private Product getProductFromProductDB(ProductDB productdb)
        {
            return new Product(productdb.barcode, productdb.productName, productdb.description, productdb.price, oJS.Deserialize<List<string>>(productdb.categories));
        }

        private ShoppingCart getShoppingCartFromshoppingCartDB(ShoppingCartDB sh)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            if(sh!= null)
            {
                shoppingCart.shoppingBaskets = new Dictionary<string, ShoppingBasket>();
                if (sh.shoppingBaskets != null && sh.shoppingBaskets.keys != null)
                {
                    List<string> keys = oJS.Deserialize<List<string>>(sh.shoppingBaskets.keys);
                    List<ShoppingBasket> values = shopingBasketsFormShopingBasketsDb(sh.shoppingBaskets.values.ToList());
                    if (keys.Count == values.Count)
                    {
                        for (int i = 0; i < keys.Count; i++)
                        {
                            shoppingCart.shoppingBaskets.Add(keys.ElementAt(i), values.ElementAt(i));
                        }
                    }
                    else
                    {
                        throw new Exception("keys.Count != values.Count");
                    }
                }
            }
 
            return shoppingCart;
            //shoppingCart.id = sh.ShoppingCartId;

            /*List<ShoppingBasketDB> ShoppingBasketHash = new List<ShoppingBasketDB>(sh.shoppingBaskets.values);
            List<string> hashStrings = oJS.Deserialize<List<string>>(sh.shoppingBaskets.keys);

            for(int i = 0; i < ShoppingBasketHash.Count; i++)
            {
                ShoppingBasket temp = getShopingBasketFromShopingBasketDB(ShoppingBasketHash[i]);
                shoppingCart.shoppingBaskets.Add(hashStrings[i], temp);
            }*/
        }

        private List<ShoppingBasket> shopingBasketsFormShopingBasketsDb(List<ShoppingBasketDB> shoppingBasketDBs)
        {
            List<ShoppingBasket> shBaskets = new List<ShoppingBasket>();
            foreach(ShoppingBasketDB sh in shoppingBasketDBs)
            {
                shBaskets.Add(getShopingBasketFromShopingBasketDB(sh));
            }
            return shBaskets;
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


        public Product GetProduct(string barcode, string storeName)
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
                products.Add(store.GetName(), storeProducts.Keys.ToList());
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

        public void Reset()
        {
            _instance = null;
        }


        //-------------------------------------------------
        public PurchaseOffer GetPurchaseOffer(Product pr, User us, Store st, double price, int amount)
        {

            PurchaseOffer curr = null;
            for (int i = 0; i < Offers.Count; i++)
            {
                curr = Offers[i];
                if (curr != null)
                {
                    if (curr.checkequals(pr, us, st, price, amount))
                        return curr;
                }
            }
            return null;
        }
    }
}