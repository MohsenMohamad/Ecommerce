
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

    }

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
        [Key, Column(Order = 0)]
        public string key { get; set; }

        [Key, Column(Order = 1)]
        public string storeName { get; set; }

        [Key, Column(Order = 2)]
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
        
        public string productName { get; set; }

        
        public double price { get; set; }

        
        public string description { get; set; }

        
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
        //List<string>
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
        public string storeName { get; set; }
        public string UserName { get; set; }        
        public string purchaseType { get; set; }
        [Required]
        public DateTime date { get; set; }

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


   

}





