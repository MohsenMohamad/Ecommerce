
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

namespace Version1.DataAccessLayer
{
    public class ModelDB : DbContext
    {
        public ModelDB()
            : base("ModelDB")
        {
            Database.CreateIfNotExists();
            Configuration.AutoDetectChangesEnabled = true;
            Database.SetInitializer<ModelDB>(null);

        }

        //how to get values https://stackoverflow.com/questions/2946089/entity-framework-4-poco-with-dictionary
        //string text = (from sv in q.SelectableValues where sv.Code == "MyKey" select sv.Text).First();

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.


        //update an entity
        //https://stackoverflow.com/questions/11709266/what-exactly-does-attach-do-in-entity-framework

        public virtual DbSet<UserDB> UsersTable { get; set; }
        public virtual DbSet<DiscountDB> DiscountsTable { get; set; }
        public virtual DbSet<StoreDB> StoresTable { get; set; }
        public virtual DbSet<PurchaseDB> PurchasesTable { get; set; }
        public virtual DbSet<ShoppingCartDB> ShoppingCartsTable { get; set; }
        public virtual DbSet<ShoppingBasketDB> ShoppingBasketsTable { get; set; }
        public virtual DbSet<ProductDB> ProductsTable { get; set; }
        public virtual DbSet<ReviewDB> ReviewsTable { get; set; }
        public virtual DbSet<CategoryDB> CategoriesTable { get; set; }
        public virtual DbSet<NodeDB> nodesTable { get; set; }


        //helping dictionaries objects
        public virtual DbSet<shoppingBasketsDictionaryDB> shoppingBasketsDictionariesDB { get; set; }
        public virtual DbSet<itemsHasmapforPurchaseDB> itemsFromPurchaseDBDictionariesDB { get; set; }
        public virtual DbSet<itemsHasmapforDiscountDB> itemsFromDiscountsDBDictionariesDB { get; set; }
        public virtual DbSet<stringmapint> basketProducts { get; set; }

    }

    public class stringmapint
    {
        [Key]
        [Required]
        public long id { get; set; }
        [Required]
        public string[] keys { get; set; }
        [Required]
        public int[] values { get; set; }
        public stringmapint(long id, string[] keys, int[] values)
        {
            this.id = id;
            this.keys = keys;
            this.values = values;
        }
    }






    public class inventoryDictionaryDBForStore
    {
        [Key]
        [Required]
        public string storeName { get; set; }
        public ICollection<ProductDB> keys { get; set; }
        public ICollection<int> values { get; set; }

    }


    //will change waiting for mohsen
    public class ReviewDB
    {
        [Key, Column(Order = 0)]
        public string Username { get; set; }
        //[Key, Column(Order = 1)]
        public string Reviews { get; set; }
    }
    public class DiscountDB
    {
        [Key]
        public long discountId { get; set; }

        [Required]
        public itemsHasmapforDiscountDB items { get; set; }
    }
    //will change waiting for mohsen
    public class itemsHasmapforDiscountDB
    {
        [Key]
        [Required]
        public int discountId { get; set; }
        public ProductDB key { get; set; }
        public ICollection<double> values { get; set; }
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
        public ICollection<int> values { get; set; }
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

    }


    //done
    public class ShoppingCartDB
    {
        [Key]
        [Required]
        public int ShoppingCartId { get; set; }

        public shoppingBasketsDictionaryDB shoppingBaskets { get; set; }
    }
    //done
    public class shoppingBasketsDictionaryDB
    {
        [Key]
        [Required]
        public int ShoppingCartId { get; set; }
        public ICollection<string> keys { get; set; }
        public ICollection<ShoppingBasketDB> values { get; set; }

    }

    //done
    public class ShoppingBasketDB
    {
        [Key]
        public long id { get; set; }
        //[Required]
        public string StoreName { get; set; }
        //[Required]
        public string Products { get; set; }
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


        public string notifications { get; set; }

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
    public class StoreDB
    {
        [Key]
        [Required]
        public string storeName { get; set; }

        //to do make sure of that
        public ICollection<IPurchasePolicy> purchasePolicies { get; set; }
        public string notifications { get; set; }


        public string paymentInfo { get; set; }

        public ICollection<DiscountDB> discounts { get; set; }

        public ICollection<PurchaseDB> history { get; set; }

        public inventoryDictionaryDBForStore inventory { get; set; }

        public NodeDB staff { get; set; }

    }



    internal class database
    {
        public ModelDB db = new ModelDB();
        public JavaScriptSerializer oJS = new JavaScriptSerializer();


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
                throw;
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
            var result = db.StoresTable.SingleOrDefault(b => b.storeName == s.name);
            StoreDB store = getStoreDB(s);
            if (result != null)
            {
                result.inventory = store.inventory;
                result.paymentInfo = store.paymentInfo;
                result.history = store.history;
                result.notifications = store.notifications;
                result.purchasePolicies = store.purchasePolicies;
                result.staff = store.staff;
                result.storeName = store.storeName;
                result.discounts = store.discounts;

                db.SaveChanges();
                return true;
            }
            return false;
        }


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
                throw;
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
                return true;
            }
            return false;
        }

        public bool InsertDiscount(Discount d)
        {
            DiscountDB discount = getDiscountDB(d);


            try
            {
                db.DiscountsTable.Add(discount);
                db.SaveChanges();
                Console.WriteLine("insert Discount");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDiscount(Discount d)
        {
            var result = db.DiscountsTable.SingleOrDefault(b => b.discountId == d.id);
            DiscountDB discount = getDiscountDB(d);
            if (result != null)
            {
                result.items = result.items;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public DbSet<DiscountDB> getAllDiscounts()
        {
            return db.DiscountsTable;
        }

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

        public bool UpdateShoppingCart(ShoppingCart sh)
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
        }
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

        private DiscountDB getDiscountDB(Discount pr)
        {
            DiscountDB ddb = new DiscountDB();
            ddb.discountId = pr.id;
            ddb.items = new itemsHasmapforDiscountDB();

            return ddb;
        }

        private PurchaseDB getPurchaseDb(Purchase pr)
        {
            PurchaseDB p = new PurchaseDB();
            p.date = pr.date;
            p.purchaseId = pr.purchaseId;
            p.storeName = pr.store;
            p.UserName = pr.user;
            p.purchaseType = pr.purchaseType.ToString();

            p.items = new itemsHasmapforPurchaseDB();//new List<KeyValuePair<ProductDB, int>>();

            foreach (KeyValuePair<Product, int> pair in pr.items)
            {
                ProductDB pdb = new ProductDB();
                pdb.barcode = pair.Key.barcode;
                pdb.productName = pair.Key.name;
                pdb.price = pair.Key.price;
                pdb.description = pair.Key.description;
                pdb.categories = oJS.Serialize(pair.Key.categories);
                p.items.keys.Add(pdb);
                p.items.values.Add(pair.Value);
            }
            p.purchaseId = pr.purchaseId;
            return p;
        }

        private ReviewDB getReviewtDB(Review r)
        {
            ReviewDB review = new ReviewDB();
            review.Username = r.Username;
            review.Reviews = r.Reviews;
            return review;
        }

        private StoreDB getStoreDB(Store s)
        {
            StoreDB store = new StoreDB();

            store.storeName = s.name;
            store.purchasePolicies = s.purchasePolicies;
            store.paymentInfo = oJS.Serialize(s.paymentInfo);

            store.notifications = oJS.Serialize(s.GetNotifications());


            store.discounts = new List<DiscountDB>();
            foreach (Discount dis in s.discounts)
            {
                store.discounts.Add(getDiscountDB(dis));
            }

            store.history = new List<PurchaseDB>();
            foreach (Purchase p in s.history)
            {
                store.history.Add(getPurchaseDb(p));
            }

            store.inventory = new inventoryDictionaryDBForStore();
            foreach (KeyValuePair<Product, int> p in s.inventory)
            {
                store.inventory.keys.Add(getProductDb(p.Key));
                store.inventory.values.Add(p.Value);
            }
            store.inventory.storeName = s.name;


            store.staff = getNodeDb(s.staff);


            return store;
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
        private ShoppingCartDB getShoppingCartDB(ShoppingCart pr)
        {
            ShoppingCartDB p = new ShoppingCartDB();
            p.ShoppingCartId = pr.id;
            p.shoppingBaskets = new shoppingBasketsDictionaryDB();//new Dictionary<string, ShoppingBasketDB>();

            foreach (KeyValuePair<string, ShoppingBasket> pair in pr.shoppingBaskets)
            {
                p.shoppingBaskets.keys.Add(pair.Key);
                p.shoppingBaskets.values.Add(getShoppingBasketDB(pair.Value));
            }
            p.shoppingBaskets.ShoppingCartId = pr.id;
            return p;
        }



        private ProductDB getProductDb(Product pr)
        {
            ProductDB p = new ProductDB();

            p.barcode = pr.Barcode;
            p.price = pr.price;
            p.productName = pr.Name;
            p.description = pr.Description;
            p.categories = oJS.Serialize(pr.categories);
            return p;
        }


        private ShoppingBasketDB getShoppingBasketDB(ShoppingBasket pr)
        {
            ShoppingBasketDB p = new ShoppingBasketDB();
            p.id = pr.id;
            p.StoreName = pr.StoreName;

            string jsonString = oJS.Serialize(pr.Products);
            p.Products = jsonString;

            return p;
        }
        private UserDB getUserDB(User u)
        {
            UserDB user = new UserDB();
            user.Password = u.Password;
            user.UserName = u.UserName;
            user.notifications = oJS.Serialize(u.GetNotifications());

            user.history = new List<PurchaseDB>();
            foreach (Purchase p in u.history)
            {
                PurchaseDB pdb = getPurchaseDb(p);
                user.history.Add(pdb);
            }

            user.shoppingCart = getShoppingCartDB(u.shoppingCart);
            return user;
        }



        private CategoryDB getCatagoryDb(Category c)
        {
            CategoryDB catagory = new CategoryDB();
            catagory.categorieName = c.name;
            return catagory;
        }


    }

}



