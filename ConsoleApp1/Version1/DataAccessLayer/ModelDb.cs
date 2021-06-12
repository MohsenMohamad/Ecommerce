
using Version1.domainLayer.DataStructures;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using Version1.domainLayer;
using Version1.domainLayer.StorePolicies;
//using System.Web.Script.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Web.Script.Serialization;
using System.Data.Entity.Migrations;
using Version1.domainLayer.DiscountPolicies;

namespace Version1.DataAccessLayer
{
    public class ModelDB : DbContext
    {
        public ModelDB()
            : base("ModelDB")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer<ModelDB>(new DropCreateDatabaseIfModelChanges<ModelDB>());
            Configuration.AutoDetectChangesEnabled = true;
        }





        //how to get values https://stackoverflow.com/questions/2946089/entity-framework-4-poco-with-dictionary
        //string text = (from sv in q.SelectableValues where sv.Code == "MyKey" select sv.Text).First();

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.


        //update an entity
        //https://stackoverflow.com/questions/11709266/what-exactly-does-attach-do-in-entity-framework

        public virtual DbSet<UserDB> UsersTable { get; set; }
        public virtual DbSet<PurchaseDB> PurchasesTable { get; set; }
        public virtual DbSet<ShoppingCartDB> ShoppingCartsTable { get; set; }
        public virtual DbSet<ShoppingBasketDB> ShoppingBasketsTable { get; set; }
        public virtual DbSet<ReviewDB> ReviewsTable { get; set; }
        public virtual DbSet<CategoryDB> CategoriesTable { get; set; }
        public virtual DbSet<NodeDB> nodesTable { get; set; }
        public virtual DbSet<DTO_PoliciesDB> DiscountsTable { get; set; }
        public virtual DbSet<ProductDB> ProductsTable { get; set; }

        public virtual DbSet<StoreDB> StoresTable { get; set; }
        public virtual DbSet<ProductDBANDAMOUNT> ProductDBANDAMOUNTTable { get; set; }

        //helping dictionaries objects
        public virtual DbSet<shoppingBasketsDictionaryDB> shoppingBasketsDictionariesDB { get; set; }

        public virtual DbSet<itemsHasmapforPurchaseDB> itemsFromPurchaseDBDictionariesDB { get; set; }

        //public virtual DbSet<stringmapint> basketProducts { get; set; }

    }

/*

    public class inventoryDictionaryDBForStore
    {
        [Key]
        [Required]
        public string storeName { get; set; }
        public ICollection<ProductDB> keys { get; set; }
        //string json for ICollection<int>
        public string values { get; set; }
        public 
        public inventoryDictionaryDBForStore()
        {
            this.keys = new List<ProductDB>();
        }

    }*/
    public class inventoryDictionaryDBForStore
    {
        [Key]
        [Required]
   
        public string storeName { get; set; }
        public List<ProductDB> keys { get; set; }
        //string json for ICollection<int>
        public string values { get; set; }

    }


    //will change waiting for mohsen
    public class ReviewDB
    {
        [Key, Column(Order = 0)]
        public string Username { get; set; }
        [Key, Column(Order = 1)]
        public string Reviews { get; set; }
    }


    public class DTO_PoliciesDB
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long discountId { get; set; }
        public int Type { get; set; }
        public int percentage { get; set; }
        public string conditoin { get; set; }
        public int conditoin_percentage { get; set; }
        public string discount_description { get; set; }
    }


    public class NodeDB
    {
        [Key]
        [Required]
        public string key { get; set; }

        public int value { get; set; }

        public virtual ICollection<NodeDB> Children { get; set; }

    }

    //to ckeck in the end
    public class itemsHasmapforPurchaseDB
    {
        [Key]
        [Required]
        public int purchaseId { get; set; }
        public ICollection<ProductDB> keys { get; set; }
        public string values { get; set; }
    }
    //done
    public class CategoryDB
    {
        [Key]
        [Required]
        public string categorieName { get; set; }
    }
    //done
    public class ProductDB
    {

        [Key]
        [Required]
        public string barcode { get; set; }
        //[Required]
        public string productName { get; set; }

        //[Required]
        public double price { get; set; }

        //[Required]
        public string description { get; set; }

        //[Required]
        public string categories { get; set; }

        public DTO_PoliciesDB discountPolicy { get; set; }


    }


    //done
    public class ShoppingCartDB
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int ShoppingCartId { get; set; }

        public shoppingBasketsDictionaryDB shoppingBaskets { get; set; }
    }
    //done
    public class shoppingBasketsDictionaryDB
    {
        [Key]
        public int ShoppingCartId { get; set; }
        //here
        public string keys { get; set; }
        public ICollection<ShoppingBasketDB> values { get; set; }

    }

    //done
    public class ShoppingBasketDB
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public long id { get; set; }
        //[Required]
        public string StoreName { get; set; }
        //json string describe Dictionary<string, int>
        public string Products { get; set; }
        //json string describe Dictionary<string, double>
        public string priceperproduct { get; set; }
        

    }
    //done
    public class UserDB
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }


        public ICollection<PurchaseDB> history { get; set; }

        //List<String> as json string
        public string notifications { get; set; }
        //List<String> as json string
        public string notificationsoffer { get; set; }

        public ShoppingCartDB shoppingCart { get; set; }
    }
    //to ckeck in the end
    public class PurchaseDB
    {
        [Key]
        [Required]
        public long purchaseId { get; set; }
        //[Required]
        public string storeName { get; set; }

        public string UserName { get; set; }


        //[Required]
        public string purchaseType { get; set; }
        [Required]
        public DateTime date { get; set; }


        //[Required]
        //todo  List<KeyValuePair<ProductDB, int>> 
        public itemsHasmapforPurchaseDB items { get; set; }
    }
    public class ProductDBANDAMOUNT
    {
        [Key, Column(Order = 0)]
        public string storeName { get; set; }
        [Key, Column(Order = 1)]
        public string barcode { get; set; }
        public ProductDB product { get; set; }
        public int amount { get; set; }
    }
    
    public class StoreDB
    {
        [Key]
        [Required]
        public string storeName { get; set; }
        public string storeOwner { get; set; }

        // string json as List<string>
        public string notifications { get; set; }
        
        // string json as List<string>
        public string paymentInfo { get; set; }

        public ICollection<DTO_PoliciesDB> discountPolicies { get; set; }

        public ICollection<PurchaseDB> history { get; set; }

        public ICollection<ProductDBANDAMOUNT> products { get; set; }

        public NodeDB staff { get; set; }
        //todo change
        public ICollection<IPurchasePolicy> purchasePolicies { get; set; }

        
    }


    public class database
    {
        public ModelDB db;

        public JavaScriptSerializer oJS;

        private static database _mySingleton = null;
        private static object syncRoot = new object();
        private database()
        {
            db = new ModelDB();
            oJS = new JavaScriptSerializer();
            db.ProductDBANDAMOUNTTable.Include(b => b.product).ToList();
            db.StoresTable.Include(b => b.products).ToList();
            db.StoresTable.Include(b => b.staff).ToList();
            db.StoresTable.Include(b => b.history).ToList();
            db.StoresTable.Include(b => b.discountPolicies).ToList();
            
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

        public bool InsertDTO_PoliciesDB(DTO_Policies dp)
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

        private DTO_PoliciesDB getDTO_PoliciesDB(DTO_Policies dp)
        {
            DTO_PoliciesDB discountPolicy = new DTO_PoliciesDB();
            discountPolicy.Type = dp.Type;
            discountPolicy.percentage = dp.percentage;
            discountPolicy.discount_description = dp.discount_description;
            discountPolicy.conditoin_percentage = dp.conditoin_percentage;
            discountPolicy.conditoin = dp.conditoin;

            return discountPolicy;           
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
            var result = db.StoresTable.SingleOrDefault(b => true);
            return db.StoresTable;
        }

        public bool UpdateStore(Store s)
        {
            var result = db.StoresTable.SingleOrDefault(b => b.storeName == s.name);
            StoreDB store = getStoreDB(s);
            /*//change inventory
            
            //save changes
            db.SaveChanges();
            Console.WriteLine("added element" + result.keys.ToList().ElementAt(0));*/

            
            if (result != null)
            {
                db.Entry(result).CurrentValues.SetValues(store);

                db.SaveChanges();
                try
                {
                    result = db.StoresTable.SingleOrDefault(b => b.storeName == s.name);
                    //Console.WriteLine("added element" + result.inventory.keys.ToList().ElementAt(0));
                }
                catch
                {
                    Console.WriteLine("ex");
                }

                var result2 = db.ProductsTable;
                foreach (ProductDB pa in result2)
                {
                    Console.WriteLine("barcode updated " + pa.barcode);
                }
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
            store.staff = getNodeDb(s.staff);


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
                ProductDB pdb = getProductDb(pair.Key);

                p.items.keys.Add(pdb);
                listOfItemsValues.Add(pair.Value);
            }
            //orm does not save list<int> to save in json string
            p.items.values = oJS.Serialize(listOfItemsValues);


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
        public bool InsertProductToStore(string storeName,Product p, int amount)
        {
            var result = db.StoresTable.SingleOrDefault(b => b.storeName == storeName);
            
            if (result != null)
            {
                if(result.products == null)
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

        public bool UpdateProduct(Product p)
        {
            var result = db.ProductsTable.SingleOrDefault(b => b.barcode == p.barcode);
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
            p.discountPolicy = getDTO_PoliciesDB(pr.discountPolicy);
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

        public bool InsertNode(Node<string, int> n)
        {
            NodeDB node = getNodeDb(n);
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
        public bool UpdateNode(Node<string, int> n)
        {
            var result = db.nodesTable.SingleOrDefault(b => b.key == n.Key);
            NodeDB node = getNodeDb(n);
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

        private NodeDB getNodeDb(Node<string, int> n)
        {
            NodeDB node = new NodeDB();
            node.key = n.Key;
            node.value = n.Value;
            node.Children = new List<NodeDB>();
            n.Children.ForEach((child) => node.Children.Add(getNodeDb(child)));
            return node;
        }


    }

}





