using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Configuration;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.DataAccessLayer.DB;
using ServiceLogic.domainLayer;
using ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies;
using ServiceLogic.Service_Layer;

namespace ServiceLogic.DataAccessLayer
{
    public class DataHandler
    {
        public object InefficientLock { get; }
        private static readonly object Padlock = new object();

        private static DataHandler _instance = null;
        public ConcurrentDictionary<string, User> Users { get; }
        internal ConcurrentDictionary<string, Store> Stores { get; }



        public ConcurrentDictionary<long, Guest> Guests { get; }
        public ConcurrentDictionary<string, Category> Categories;
        public List<PurchaseOffer> Offers { get; set; }
        
        public string mock = ConfigurationManager.AppSettings["mock"];
    
    
        public bool ismock { get; set; }
        private List<Review> Reviews { get; }
        public JavaScriptSerializer oJS;
        public IDataBase db;
        public DataHandler()
        {
            
            Users = new ConcurrentDictionary<string, User>();
            Stores = new ConcurrentDictionary<string, Store>();
            Guests = new ConcurrentDictionary<long, Guest>();
            Reviews = new List<Review>();
            Categories = new ConcurrentDictionary<string, Category>();
            Offers = new List<PurchaseOffer>();
            InefficientLock = new object();
            if (mock!=null&&mock.CompareTo("true") == 0)
            {
                ismock = true;
            }
            else
            {
                ismock = false;
            }

            if (ismock)
            {
                db = new MockDB();
            }
            else
            {
                oJS = new JavaScriptSerializer();
                 db = database.GetInstance();

                //upload users
                uploadUsers((database)db);

                //upload stores
                uploadStores((database)db);
            }

        }


        internal void updatedb()
        {
            if (mock != null && mock.CompareTo("true") == 0)
            {
                ismock = true;
                db = new MockDB();
            }
            else
            {
                ismock = false;
                oJS = new JavaScriptSerializer();
                db = database.GetInstance();
            }
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
/*                store.purchasePolicies = s.purchasePolicies.ToList();
*/          }

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

            if (s.products != null)
            {
                
                foreach (ProductDBANDAMOUNT productAndAmount in s.products)
                {
                    Product temp = getProductFromProductDB(productAndAmount.product);
                    int amount = productAndAmount.amount;
                    store.inventory[temp] = amount;
                }
            }
            if(s.staff != null)
            {   
                store.staff = getNode(s.staff);
            }


            store.discountPolicies = new List<DtoPolicy>();
            foreach(var policy in s.discountPolicies)
            {
                DtoPolicy spDB = getDiscountPolicyFromDiscountPolicyDB(policy);
                store.discountPolicies.Add(spDB);
            }
            

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
            user.notificationsoffer = oJS.Deserialize<List<string>>(u.notificationsoffer);
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
            List<int> values;
            if (p.items == null || p.items.values == null)
            {
                values = new List<int>();
            }
            else
            {
                values = oJS.Deserialize<List<int>>(p.items.values);
            }
            
            List<Product> keys = new List<Product>();
            if (p.items != null && p.items.keys != null)
            {
                foreach (ProductDB productdb in p.items.keys)
                {
                    keys.Add(getProductFromProductDB(productdb));
                }
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
            Product product =  new Product(productdb.barcode, productdb.productName, productdb.description, productdb.price, oJS.Deserialize<List<string>>(productdb.categories));
            product.DiscountPolicy = getDiscountPolicyFromDiscountPolicyDB(productdb.discountPolicy);
            return product;
        }

        private DtoPolicy getDiscountPolicyFromDiscountPolicyDB(DTO_PoliciesDB dp)
        {
            DtoPolicy discountPolicy = new DtoPolicy();
            if(dp != null)
            {
                discountPolicy.TypeOfPolicy = dp.Type;
                discountPolicy.Percentage = dp.percentage;
                discountPolicy.DiscountDescription = dp.discount_description;
                discountPolicy.ConditoinPercentage = dp.conditoin_percentage;
                discountPolicy.Conditoin = dp.conditoin;
            }

            return discountPolicy;
        }

        private ShoppingCart getShoppingCartFromshoppingCartDB(ShoppingCartDB sh)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            if(sh!= null)
            {
                shoppingCart.shoppingBaskets = new Dictionary<string, ShoppingBasket>();
                if (sh.baskets != null)
                {
                    //List<string> keys = oJS.Deserialize<List<string>>(sh.shoppingBaskets.keys); ;
                    
                    //List<ShoppingBasket> values = shopingBasketsFormShopingBasketsDb(sh.shoppingBaskets.values.ToList());

                        for (int i = 0; i < sh.baskets.Count; i++)
                        {
                            ShoppingBasketDB temp1 = sh.baskets.ElementAt(i).basket;
                            ShoppingBasket temp2 = getShopingBasketFromShopingBasketDB(temp1);
                            shoppingCart.shoppingBaskets.Add(sh.baskets.ElementAt(i).StoreName, temp2);
                        }

                }
            }
 
            return shoppingCart;
            
        }


       /* private List<ShoppingBasket> shopingBasketsFormShopingBasketsDb(List<ShoppingBasketDB> shoppingBasketDBs)
        {
            List<ShoppingBasket> shBaskets = new List<ShoppingBasket>();

            foreach(ShoppingBasketDB sh in shoppingBasketDBs)
            {
                shBaskets.Add(getShopingBasketFromShopingBasketDB(sh));
            }
            return shBaskets;
        }*/

        private ShoppingBasket getShopingBasketFromShopingBasketDB(ShoppingBasketDB sh)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket(sh.StoreName);
            shoppingBasket.id = sh.id;
            shoppingBasket.Products = oJS.Deserialize<Dictionary<string, int>>(sh.Products);
            shoppingBasket.priceperproduct = oJS.Deserialize<Dictionary<string, double>>(sh.priceperproduct);
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
            set
            {
                _instance = new DataHandler();
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
                if (!ismock) // changeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
                {
                    database realDb = database.GetInstance();
                    if (realDb.db.UsersTable.Any(o => o.UserName == user.UserName))
                    {
                        //alreadyExist
                        return false;
                    }
                    else
                    {
                        //db.db.UsersTable.ToList().ForEach((u) => Console.WriteLine(u.UserName));
                        return realDb.InsertUser(user);
                        //return db.InsertUser(new User(user.UserName,user.Password));
                    }   
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