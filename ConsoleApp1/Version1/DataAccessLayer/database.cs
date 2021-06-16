using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.DiscountPolicies;

namespace Version1.DataAccessLayer
{
    public class database : IDataBase
    {
        public ModelDB db;

        public JavaScriptSerializer oJS;

        private static database _mySingleton = null;
        private static object syncRoot = new object();
        private database()
        {
            db = new ModelDB();
            oJS = new JavaScriptSerializer();

            //db.ProductDBANDAMOUNTTable.Include(b => b.product).ToList();
            // Load all Storess, adn all related productList, and all related prodoucts in each element in the list.
            db.StoresTable.Include(b => b.products.Select(p => p.product)).ToList();
            db.StoresTable.Include(b => b.staff).ToList();
            db.StoresTable.Include(b => b.history).ToList();
            db.StoresTable.Include(b => b.discountPolicies).ToList();
            db.UsersTable.Include(b => b.shoppingCart.shoppingBaskets).ToList();
            db.shoppingBasketsDictionariesDB.Include(b => b.values).ToList();
            db.ProductsTable.Include(b => b.discountPolicy).ToList();

            //db.StoresTable.Include(b => b.purchasePolicies).ToList();
        }


        public static database GetInstance()
        {
            if (_mySingleton is null) // The first check
            {
                lock (syncRoot)
                {
                    if (_mySingleton is null) // The second (double) check
                    {
                        _mySingleton = new database();
                    }
                }
            }

            return _mySingleton;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////// Users ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        public bool InsertUser(User u)
        {
            UserDB user = getUserDB(u);

            try
            {
                db.UsersTable.Add(user);
                db.SaveChanges();
                Console.WriteLine("insert user");
                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }
        }

        public bool InsertDTO_PoliciesDB(DtoPolicy dp)
        {
            DTO_PoliciesDB discountPolicy = getDTO_PoliciesDB(dp);

            try
            {
                db.DiscountsTable.Add(discountPolicy);
                db.SaveChanges();
                Console.WriteLine("insert Discount");
                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }
        }

        public bool deleteBasket(string userName, string storeName)
        {
            var result = db.UsersTable.SingleOrDefault(b => b.UserName == userName);

            if (result != null)
            {
                List<string> keys = oJS.Deserialize<List<string>>(result.shoppingCart.shoppingBaskets.keys);
                int indexOfStore = keys.IndexOf(storeName);
                if (indexOfStore != -1)
                {
                    result.shoppingCart.shoppingBaskets.values.Remove(result.shoppingCart.shoppingBaskets.values.ElementAt(indexOfStore));
                    keys.RemoveAt(indexOfStore);
                    result.shoppingCart.shoppingBaskets.keys = oJS.Serialize(keys);
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
            return false;
        }

        public DbSet<UserDB> getAllUsers()
        {
            return db.UsersTable;
        }

        public bool UpdateUser(User u)
        {
            var result = db.UsersTable.SingleOrDefault(b => b.UserName == u.UserName);
            UserDB user = getUserDB(u);
            if (result != null)
            {
                result.history = user.history;
                result.notifications = user.notifications;
                result.shoppingCart = user.shoppingCart;
                result.Password = user.Password;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUser(string userName)
        {
            var result = db.UsersTable.SingleOrDefault(b => b.UserName == userName);

            if (result != null)
            {
                /*if(result.history != null)
                {
                    foreach (PurchaseDB p in result.history.ToList())
                    {
                        DeletePurchase(p.purchaseId);
                    }
                }*/


                db.UsersTable.Remove(result);
                db.SaveChanges();
                Console.WriteLine("delete user");
                return true;
            }
            return false;
        }


        private UserDB getUserDB(User u)
        {
            UserDB user = new UserDB();
            user.Password = u.Password;
            user.UserName = u.UserName;

            user.notifications = oJS.Serialize(u.GetNotifications());
            user.notificationsoffer = oJS.Serialize(u.GetNotificationsoffer());

            user.history = new List<PurchaseDB>();
            foreach (Purchase p in u.history)
            {
                PurchaseDB pdb = getPurchaseDb(p);
                user.history.Add(pdb);
            }

            user.shoppingCart = getShoppingCartDB(u.shoppingCart);
            return user;
        }

        private DTO_PoliciesDB getDTO_PoliciesDB(DtoPolicy dp)
        {
            DTO_PoliciesDB discountPolicy = new DTO_PoliciesDB();
            discountPolicy.Type = dp.TypeOfPolicy;
            discountPolicy.percentage = dp.Percentage;
            discountPolicy.discount_description = dp.DiscountDescription;
            discountPolicy.conditoin_percentage = dp.ConditoinPercentage;
            discountPolicy.conditoin = dp.Conditoin;

            return discountPolicy;
        }

        public void updateNotification(string userName, List<string> list)
        {
            var result = db.UsersTable.SingleOrDefault(b => b.UserName == userName);

            if (result != null)
            {
                result.notifications = oJS.Serialize(list);
                db.SaveChanges();
            }

        }
        public void updateNotificationsoffer(string userName, List<string> list)
        {
            var result = db.UsersTable.SingleOrDefault(b => b.UserName == userName);

            if (result != null)
            {
                result.notificationsoffer = oJS.Serialize(list);
                db.SaveChanges();
            }
        }

        public void UpdateProductDiscountDiscreption(string barcode, string discount_description)
        {
            var product = db.ProductsTable.SingleOrDefault(b => b.barcode == barcode);
            if (product != null)
            {
                product.discountPolicy.discount_description = discount_description;
                db.SaveChanges();

            }
        }

        public void updateStoreStaff(string storeName, Node<string, int> node)
        {
            var store = db.StoresTable.SingleOrDefault(b => b.storeName == storeName);
            if (store != null)
            {

                List<NodeDB> nodesDB = db.nodesTable.Select(x => (x.storeName == storeName) ? x : null).ToList();
                foreach (NodeDB n in nodesDB)
                {
                    if (n != null)
                    {
                        db.nodesTable.Remove(n);
                        db.SaveChanges();
                    }

                }

                store.staff = getNodeDb(node, storeName);
                db.SaveChanges();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////// Discounts ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////// Stores ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        public bool InsertStore(Store s)
        {
            try
            {
                StoreDB store = getStoreDB(s);
                db.StoresTable.Add(store);
                db.SaveChanges();
                Console.WriteLine("insert store");
                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }


        }



        //todo
        public bool DeleteStore(Store store)
        {
            throw new NotImplementedException();
        }

        public DbSet<StoreDB> getAllStores()
        {

            return db.StoresTable;
        }

        public bool UpdateStore(Store s)
        {
            /*var result = db.StoresTable.SingleOrDefault(b => b.storeName == s.name);
            StoreDB store = getStoreDB(s);
            
            if (result != null)
            {
                foreach(var dp in s.discountPolicies)
                {
                    getDTO_PoliciesDB(dp);
                }

                result.discountPolicies = 

                db.SaveChanges();
                
                return true;
            }
            return false;*/
            return false;
        }
        public bool AddDiscountToStore(string storeName, DtoPolicy dp)
        {
            var result = db.StoresTable.SingleOrDefault(b => b.storeName == storeName);

            if (result != null)
            {
                if (result.discountPolicies == null)
                {
                    result.discountPolicies = new List<DTO_PoliciesDB>();
                }
                //adding discount
                result.discountPolicies.Add(getDTO_PoliciesDB(dp));
                db.SaveChanges();

                return true;
            }
            return false;
        }


        private StoreDB getStoreDB(Store s)
        {
            StoreDB store = new StoreDB();

            store.storeName = s.name;
            store.storeOwner = s.staff.Key;


            store.paymentInfo = oJS.Serialize(s.paymentInfo);
            store.notifications = oJS.Serialize(s.GetNotifications());

            /*            store.purchasePolicies = s.purchasePolicies;
            */
            store.history = new List<PurchaseDB>();
            foreach (Purchase p in s.history)
            {
                store.history.Add(getPurchaseDb(p));
            }


            List<int> valueList = new List<int>();

            store.products = new List<ProductDBANDAMOUNT>();

            foreach (KeyValuePair<Product, int> p in s.inventory)
            {
                ProductDBANDAMOUNT tempPro = new ProductDBANDAMOUNT();
                tempPro.storeName = s.name;
                tempPro.amount = p.Value;
                tempPro.barcode = p.Key.barcode;
                tempPro.product = getProductDb(p.Key);

                store.products.Add(tempPro);
            }

            //store.discountPolicies = getD
            store.staff = getNodeDb(s.staff, s.name);


            store.discountPolicies = new List<DTO_PoliciesDB>();

            foreach (var dp in s.discountPolicies)
            {
                store.discountPolicies.Add(getDTO_PoliciesDB(dp));
            }

            return store;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////// Purchases ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////



        public bool InsertPurchaseToUser(string userName, Purchase p)
        {

            var result = db.UsersTable.SingleOrDefault(b => b.UserName == userName);
            if (result != null)
            {

                if (result.history == null)
                {
                    result.history = new List<PurchaseDB>();
                }
                //adding discount to the usere's history
                result.history.Add(getPurchaseDb(p));

                db.SaveChanges();

                return true;
            }
            return false;



        }
        public bool InsertPurchaseToStore(string storeName, Purchase p)
        {
            try
            {
                var result = db.StoresTable.SingleOrDefault(b => b.storeName == storeName);
                if (result != null)
                {

                    if (result.history == null)
                    {
                        result.history = new List<PurchaseDB>();
                    }
                    //adding discount to the store's history
                    result.history.Add(getPurchaseDb(p));
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }


        public bool UpdatePurchase(Purchase p)
        {
            var result = db.PurchasesTable.SingleOrDefault(b => b.purchaseId == p.purchaseId);
            PurchaseDB purchase = getPurchaseDb(p);
            if (result != null)
            {
                result.UserName = purchase.UserName;
                result.storeName = purchase.storeName;
                result.purchaseType = purchase.purchaseType;
                result.items = purchase.items;
                result.date = purchase.date;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public DbSet<PurchaseDB> getAllPurchases()
        {
            return db.PurchasesTable;
        }


        /*
        public bool InsertPurchase(Purchase p)
        {
            PurchaseDB purchase = getPurchaseDb(p);

            try
            {
                db.PurchasesTable.Add(purchase);
                db.SaveChanges();
                Console.WriteLine("insert purchase");
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool UpdatePurchase(Purchase p)
        {
            var result = db.PurchasesTable.SingleOrDefault(b => b.purchaseId == p.purchaseId);
            PurchaseDB purchase = getPurchaseDb(p);
            if (result != null)
            {
                result.UserName = purchase.UserName;
                result.StoreName = purchase.StoreName;
                result.purchaseType = purchase.purchaseType;
                result.items = purchase.items;
                result.date = purchase.date;

                db.SaveChanges();
                return true;
            }
            return false;
        }*/

        public bool DeletePurchase(long pid)
        {
            var result = db.PurchasesTable.SingleOrDefault(b => b.purchaseId == pid);

            if (result != null)
            {
                db.PurchasesTable.Remove(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }



        private PurchaseDB getPurchaseDb(Purchase pr)
        {
            PurchaseDB p = new PurchaseDB();
            if (pr.date != null)
            {
                p.date = pr.date;
            }
            else
            {
                p.date = DateTime.Now;
            }
            p.purchaseId = pr.purchaseId;
            p.storeName = pr.store;
            p.UserName = pr.user;
            p.purchaseType = oJS.Serialize(pr.purchaseType);

            p.items = new itemsHasmapforPurchaseDB();

            //orm does not save list<int> to save in json string
            List<int> listOfItemsValues = new List<int>();
            foreach (KeyValuePair<Product, int> pair in pr.items)
            {
                ProductDB pdb = db.ProductsTable.SingleOrDefault(b => b.barcode == pair.Key.barcode);
                if (p.items.keys == null)
                {
                    p.items.keys = new List<ProductDB>();
                }
                p.items.keys.Add(pdb);
                listOfItemsValues.Add(pair.Value);
            }
            //orm does not save list<int> to save in json string
            p.items.values = oJS.Serialize(listOfItemsValues);
            p.UserName = pr.user;
            return p;
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////// ShoppingCarts ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////



        public bool InsertShoppingCart(ShoppingCart sh)
        {
            ShoppingCartDB shoppingCart = getShoppingCartDB(sh);


            try
            {
                db.ShoppingCartsTable.Add(shoppingCart);
                db.SaveChanges();
                Console.WriteLine("insert product");
                return true;
            }
            catch
            {
                return false;
            }

        }

        /*public bool UpdateShoppingCart(ShoppingCart sh)
        {
            var result = db.ShoppingCartsTable.SingleOrDefault(b => b.ShoppingCartId == sh.id);
            ShoppingCartDB shoppingCart = getShoppingCartDB(sh);
            if (result != null)
            {
                result.shoppingBaskets = shoppingCart.shoppingBaskets;
                db.SaveChanges();
                return true;
            }
            return false;
        }*/
        /*public bool DeleteShoppingCart(ShoppingCart sh)
        {
            var result = db.ShoppingCartsTable.SingleOrDefault(b => b.ShoppingCartId == sh.id);
            
            if (result != null)
            {
                result.shoppingBaskets = shoppingCart.shoppingBaskets;
                db.SaveChanges();
                return true;
            }
            return false;
        }*/

        public DbSet<ShoppingCartDB> getAllShoppingCart()
        {
            return db.ShoppingCartsTable;
        }


        private ShoppingCartDB getShoppingCartDB(ShoppingCart pr)
        {
            ShoppingCartDB p = new ShoppingCartDB();

            p.shoppingBaskets = new shoppingBasketsDictionaryDB();//new Dictionary<string, ShoppingBasketDB>();

            List<string> list = new List<string>();
            foreach (KeyValuePair<string, ShoppingBasket> pair in pr.shoppingBaskets)
            {

                list.Add(pair.Key);
                p.shoppingBaskets.values.Add(getShoppingBasketDB(pair.Value));
            }
            //todo make sure that this is updated
            p.shoppingBaskets.keys = oJS.Serialize(list);

            return p;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////  ShoppingBaskets ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        public bool InsertShoppingBasket(ShoppingBasket pr)
        {
            ShoppingBasketDB p = getShoppingBasketDB(pr);

            try
            {
                db.ShoppingBasketsTable.Add(p);
                db.SaveChanges();
                Console.WriteLine("insert ShoppingBasket");
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateShoppingBasket(ShoppingBasket sh)
        {
            var result = db.ShoppingBasketsTable.SingleOrDefault(b => b.id == sh.id);
            ShoppingBasketDB shoppingBasket = getShoppingBasketDB(sh);

            if (result != null)
            {
                result.StoreName = shoppingBasket.StoreName;

                result.Products = shoppingBasket.Products;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public DbSet<ShoppingBasketDB> getAllShoppingBaskets()
        {
            return db.ShoppingBasketsTable;
        }


        private ShoppingBasketDB getShoppingBasketDB(ShoppingBasket pr)
        {
            ShoppingBasketDB p = new ShoppingBasketDB();
            p.id = pr.id;
            p.StoreName = pr.StoreName;

            string ProductsString = oJS.Serialize(pr.Products);
            p.Products = ProductsString;

            string priceperproductString = oJS.Serialize(pr.priceperproduct);
            p.priceperproduct = priceperproductString;

            return p;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////   Products ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool InsertProduct(Product p)
        {
            ProductDB product = getProductDb(p);

            try
            {
                db.ProductsTable.Add(product);
                db.SaveChanges();
                Console.WriteLine("insert product");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertProductToStore(string storeName, Product p, int amount)
        {
            var result = db.StoresTable.SingleOrDefault(b => b.storeName == storeName);

            if (result != null)
            {
                if (result.products == null)
                {
                    result.products = new List<ProductDBANDAMOUNT>();
                }
                ProductDBANDAMOUNT newPro = new ProductDBANDAMOUNT();
                newPro.product = getProductDb(p);
                newPro.amount = amount;
                newPro.barcode = p.barcode;
                newPro.storeName = storeName;
                result.products.Add(newPro);
                db.SaveChanges();

                return true;
            }
            return false;
        }

        public bool UpdateProductPolicy(Product p)
        {
            var result = db.ProductsTable.SingleOrDefault(b => b.barcode == p.barcode);
            ProductDB product = getProductDb(p);
            if (result != null)
            {
                result.categories = product.categories;
                result.description = product.description;
                result.price = product.price;
                result.productName = product.productName;
                if (result.discountPolicy == null)
                {
                    result.discountPolicy = getDTO_PoliciesDB(p.DiscountPolicy);
                }
                else
                {
                    //already exist
                    result.discountPolicy.conditoin = p.DiscountPolicy.Conditoin;
                    result.discountPolicy.Type = p.DiscountPolicy.TypeOfPolicy;
                    result.discountPolicy.percentage = p.DiscountPolicy.Percentage;
                    result.discountPolicy.conditoin_percentage = p.DiscountPolicy.ConditoinPercentage;
                    result.discountPolicy.discount_description = p.DiscountPolicy.DiscountDescription;
                }


                db.SaveChanges();
                return true;
            }
            return false;
        }

        public DbSet<ProductDB> getAllProducts()
        {
            return db.ProductsTable;
        }


        private ProductDB getProductDb(Product pr)
        {
            ProductDB p = new ProductDB();

            p.barcode = pr.Barcode;
            p.price = pr.price;
            p.productName = pr.Name;
            p.description = pr.Description;
            p.categories = oJS.Serialize(pr.categories);
            p.discountPolicy = getDTO_PoliciesDB(pr.DiscountPolicy);
            return p;
        }




        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////  Reviews   ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool InsertReview(Review r)
        {
            ReviewDB review = getReviewtDB(r);

            try
            {
                db.ReviewsTable.Add(review);
                db.SaveChanges();
                Console.WriteLine("insert Review");
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*public bool UpdateReview(Review r)
        {
            var result = db.ReviewsTable.SingleOrDefault(b => b.Reviews == d.id);
            DiscountDB discount = getDiscountDB(d);
            if (result != null)
            {
                result.items = result.items;

                db.SaveChanges();
                return true;
            }
            return false;
        }*/
        public DbSet<ReviewDB> getAllReviews()
        {
            return db.ReviewsTable;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////  Categories   ////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool InsertCategory(Category c)
        {
            CategoryDB catagory = getCatagoryDb(c);
            try
            {
                db.CategoriesTable.Add(catagory);
                db.SaveChanges();
                Console.WriteLine("insert Category");
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*public bool UpdateCategory(Category c)
        {
            var result = db.CategoriesTable.SingleOrDefault(b => b.na == p.barcode);
            ProductDB product = getProductDb(p);
            if (result != null)
            {
                result.categories = product.categories;
                result.description = product.description;
                result.price = product.price;
                result.productName = product.productName;

                db.SaveChanges();
                return true;
            }
            return false;
        }*/
        public DbSet<CategoryDB> getAllCategories()
        {
            return db.CategoriesTable;
        }

        private CategoryDB getCatagoryDb(Category c)
        {
            CategoryDB catagory = new CategoryDB();
            catagory.categorieName = c.name;
            return catagory;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////  nodes     ////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        public bool InsertNode(Node<string, int> n, string storeName)
        {
            NodeDB node = getNodeDb(n, storeName);
            try
            {
                db.nodesTable.Add(node);
                db.SaveChanges();
                Console.WriteLine("insert Node");
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool UpdateNode(Node<string, int> n, string storeName)
        {
            var result = db.nodesTable.SingleOrDefault(b => b.key == n.Key);
            NodeDB node = getNodeDb(n, storeName);
            if (result != null)
            {
                result.value = node.value;
                result.Children = node.Children;

                db.SaveChanges();
                return true;
            }
            return false;
        }


        public DbSet<NodeDB> getAllNodes()
        {
            return db.nodesTable;
        }


        private ReviewDB getReviewtDB(Review r)
        {
            ReviewDB review = new ReviewDB();
            review.Username = r.Username;
            review.Reviews = r.Reviews;
            return review;
        }

        private NodeDB getNodeDb(Node<string, int> n, string storeName)
        {
            NodeDB node = new NodeDB();
            node.key = n.Key;
            node.storeName = storeName;
            node.value = n.Value;
            node.Children = new List<NodeDB>();
            n.Children.ForEach((child) => node.Children.Add(getNodeDb(child, storeName)));
            return node;
        }

        public bool AddProductToBasket(string userName, string storeName, string productCode, int amount, double priceofone)
        {
            var user = db.UsersTable.SingleOrDefault(b => b.UserName == userName);

            if (user != null)
            {
                if (user.shoppingCart == null)
                {
                    user.shoppingCart = new ShoppingCartDB();

                }
                if (user.shoppingCart.shoppingBaskets == null)
                {
                    user.shoppingCart.shoppingBaskets = new shoppingBasketsDictionaryDB();
                }
                List<string> keys;
                if ("\"[]\"" != user.shoppingCart.shoppingBaskets.keys)
                {
                    keys = oJS.Deserialize<List<string>>(user.shoppingCart.shoppingBaskets.keys);
                }
                else
                {
                    keys = new List<string>();
                }

                int indexOfStore;

                if (!keys.Contains(storeName))
                {
                    keys.Add(storeName);
                    indexOfStore = -1;
                }
                else
                {
                    indexOfStore = keys.IndexOf(storeName);
                }

                //adding the store name
                user.shoppingCart.shoppingBaskets.keys = oJS.Serialize(keys);

                if (user.shoppingCart.shoppingBaskets.values == null)
                {
                    user.shoppingCart.shoppingBaskets.values = new List<ShoppingBasketDB>();
                }

                ShoppingBasketDB shbasket;
                //there are no basket of the shop
                if (indexOfStore != -1)
                {
                    shbasket = user.shoppingCart.shoppingBaskets.values.ElementAt(indexOfStore);
                    shbasket.StoreName = storeName;

                    //adding the item to the dictionary and return it to string
                    Dictionary<string, int> products = oJS.Deserialize<Dictionary<string, int>>(shbasket.Products);
                    if (!products.ContainsKey(productCode))
                    {
                        products.Add(productCode, amount);
                    }
                    else
                    {
                        //if exist update the amount
                        products[productCode] = amount;
                    }
                    shbasket.Products = oJS.Serialize(products);

                }//there are basket of the shop
                else
                {
                    shbasket = new ShoppingBasketDB();
                    shbasket.StoreName = storeName;
                    Dictionary<string, int> products = new Dictionary<string, int>();
                    if (!products.ContainsKey(productCode))
                    {
                        products.Add(productCode, amount);
                    }
                    else
                    {
                        //if exist update the amount
                        products[productCode] = amount;
                    }

                    shbasket.Products = oJS.Serialize(products);
                    //add new basket in the users cart
                    user.shoppingCart.shoppingBaskets.values.Add(shbasket);
                }

                //adding the item to the dictionary of prices if does not exist or update the price if product does exist
                Dictionary<string, double> priceperproduct;
                if (shbasket.priceperproduct == null)
                {
                    priceperproduct = new Dictionary<string, double>();
                }
                else
                {
                    priceperproduct = oJS.Deserialize<Dictionary<string, double>>(shbasket.priceperproduct);
                }

                //add the price if does not exist
                if (!priceperproduct.ContainsKey(productCode))
                {
                    priceperproduct.Add(productCode, priceofone);
                }
                //update the price if product exist
                else
                {   //update the price of the product
                    priceperproduct[productCode] = priceofone;
                }
                shbasket.priceperproduct = oJS.Serialize(priceperproduct);

                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateCartProductAmountInBasket(string userName, string storeName, string productBarcode, int newAmount)
        {

            var user = db.UsersTable.SingleOrDefault(b => b.UserName == userName);

            if (user != null)

            {
                List<string> keys = oJS.Deserialize<List<string>>(user.shoppingCart.shoppingBaskets.keys);

                int indexOfStore;

                if (!keys.Contains(storeName))
                {
                    return false;
                }
                else
                {
                    indexOfStore = keys.IndexOf(storeName);
                }


                ShoppingBasketDB shbasket;
                if (indexOfStore != -1)
                {
                    shbasket = user.shoppingCart.shoppingBaskets.values.ElementAt(indexOfStore);
                }
                else
                {
                    return false;
                }

                Dictionary<string, double> Products = oJS.Deserialize<Dictionary<string, double>>(shbasket.Products);
                //update item's amount
                Products[productBarcode] = newAmount;
                shbasket.Products = oJS.Serialize(Products);

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveProductFromCart(string userName, string storeName, string productBarcode, int amount)
        {
            var user = db.UsersTable.SingleOrDefault(b => b.UserName == userName);

            if (user != null)

            {
                List<string> keys = oJS.Deserialize<List<string>>(user.shoppingCart.shoppingBaskets.keys);

                int indexOfStore;

                if (!keys.Contains(storeName))
                {
                    return false;
                }
                else
                {
                    indexOfStore = keys.IndexOf(storeName);
                }


                ShoppingBasketDB shbasket;
                if (indexOfStore != -1)
                {
                    shbasket = user.shoppingCart.shoppingBaskets.values.ElementAt(indexOfStore);
                }
                else
                {
                    return false;
                }

                Dictionary<string, int> Products = oJS.Deserialize<Dictionary<string, int>>(shbasket.Products);
                //remove item from products
                Products.Remove(productBarcode);
                shbasket.Products = oJS.Serialize(Products);

                Dictionary<string, double> priceperproduct = oJS.Deserialize<Dictionary<string, double>>(shbasket.priceperproduct);
                //remove item from priceperproduct
                priceperproduct.Remove(productBarcode);
                shbasket.priceperproduct = oJS.Serialize(priceperproduct);

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool TakeFromStoreInventory(string StoreName, string productBarcode, int amount)
        {
            var store = db.StoresTable.SingleOrDefault(b => b.storeName == StoreName);

            var product = db.ProductsTable.SingleOrDefault(b => b.barcode == productBarcode);

            if (store == null || product == null || store.products == null)
            {
                return false;
            }
            else
            {
                bool found = false;
                int i;
                for (i = 0; !found && i < store.products.Count;)
                {
                    if (store.products.ElementAt(i).barcode == productBarcode)
                    {
                        found = true;
                    }
                    else
                    {
                        i++;
                    }
                }
                if (!found)
                {
                    return false;
                }
                else if (store.products.ElementAt(i).amount < amount)
                {
                    return false;
                }
                else
                {
                    store.products.ElementAt(i).amount -= amount;
                    db.SaveChanges();
                    return true;
                }
            }


        }

        public bool makePurchaseTransaction(ShoppingBasket basket, string userName)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    bool isGuest = db.UsersTable.SingleOrDefault(b => b.UserName == userName) == null;
                    //1
                    foreach (var productBarcode in basket.Products.Keys.ToList())
                    {
                        int amount = basket.Products[productBarcode];
                        if (!TakeFromStoreInventory(basket.StoreName, productBarcode, amount))
                        {
                            throw new Exception();
                        }
                    }

                    //2
                    if (!isGuest)
                    {
                        if (!deleteBasket(userName, basket.StoreName))
                        {
                            throw new Exception();
                        }
                    }
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback(); //Required according to MSDN article 
                    return false;
                }
            }

        }


    }
}
