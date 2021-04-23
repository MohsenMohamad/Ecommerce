using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using Version1.domainLayer;

namespace Version1.DataAccessLayer
{
    public class ModelDB : DbContext
    {
        // Your context has been configured to use a 'ModelDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Version1.ModelDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelDB' 
        // connection string in the application configuration file.
        public ModelDB()
            : base("ModelDB")
        {
        }
      

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ProductDB> Products { get; set; }
        public virtual DbSet<CategoryDB> Categorys { get; set; }
        public virtual DbSet<BasketDB> Baskets { get; set; }
        public virtual DbSet<DiscountDB> Discounts { get; set; }
        public virtual DbSet<PurchaseDB> Purchases { get; set; }
        public virtual DbSet<ShoppingCartDB> ShoppingCarts { get; set; }
        public virtual DbSet<StoreDB> Stores { get; set; }
        public virtual DbSet<UserDB> Users { get; set; }



    }

    public class ProductDB {
        [Key]
        [Required]
        public int ID { get; set; }
        public string barcode { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<CategoryDB> Category {get ; set; }
    }

     public class PurchaseDB {
        [Key]
        [Required]
        public int ID { get; set; }
        public List<ProductDB>  products{ get; set; }
        public string time { get; set; }
        public int Quantity {get; set; }

       
    }

    public class UserDB
    {
        [Key]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<ShoppingCartDB> cart { get; set; }
        public List<Purchase> history { get; set; }
        public List<StoreDB> store { get; set; }
    }

     public class StoreDB
    {
        [Key]
        public int ID { get; set; }
        public  string name { get; set; }
        public User owner { get; set; }
        public List<UserDB> managers { get; set; }
        public List<UserDB> co_owners { get; set; }
      //  public Hashtable inventory;
        public List<DiscountDB> discounts { get; set; }
        public String sellingpolicy { get; set; }
        public List<PurchaseDB> history { get; set; }
    }


    public class BasketDB
    {
        [Key]
        public int ID { get; set; }
        public string Storename  { get; set; }
        public List<ProductDB>  products{ get; set; }
        public int Quantity {get; set; }
    }

    public class CategoryDB { 
        [Key]
         public int ID { get ; set ;} 
         public string name { get; set; }
    }

    public class DiscountDB { 
         [Key]
         public int ID { get ; set ;} 
         public List<ProductDB> products { get; set;}
         public int discount { get;set;}
    }

    public class ShoppingCartDB { 
         [Key]
         public int ID { get ; set ;} 
         public string username { get; set;}
         public List<BasketDB> Baskets { get; set;}
    }


    internal class database {
        public void Insertproduct(Product pr)
        {
            ProductDB p = new ProductDB();
            p.barcode = pr.Barcode;
            p.name = pr.Name;
            p.description = pr.Description;
            p.Category = new List<CategoryDB>();
            for(int i=0; i<pr.Categories.Count() ; i++) { 
                p.Category.Add(new CategoryDB { name = pr.Categories.ElementAt(i).Name });
            }

            ModelDB eo = new ModelDB();
            eo.Products.Add(p);
            eo.SaveChanges();
            Console.WriteLine("insert product");

        }
        public void InsertBasket(ShoppingBasket pr)
        {
            BasketDB p = new BasketDB();
            p.Storename = pr.StoreName;
            p.products= new List<ProductDB>();

            for(int i=0; i<pr.Products.Count() ; i++) { 
            ProductDB p1 = new ProductDB();
            p1.barcode = pr.Products.ElementAt(i).Key.Barcode;
            p1.name = pr.Products.ElementAt(i).Key.Name;
            p1.description = pr.Products.ElementAt(i).Key.Description;
            p1.Category = new List<CategoryDB>();
            for(int j=0; j<pr.Products.ElementAt(i).Key.Categories.Count() ; j++) { 
                p1.Category.Add(new CategoryDB { name = pr.Products.ElementAt(i).Key.Categories.ElementAt(j).Name });
            }
                p.products.Add(p1);
                p.Quantity = pr.Products.ElementAt(i).Value;
            }

            ModelDB eo = new ModelDB();
            eo.Baskets.Add(p);
            eo.SaveChanges();
            Console.WriteLine("insert Basket");

        }

        public void InsertCategory(Category ca)
        {
            CategoryDB p = new CategoryDB();
            p.name = ca.Name;
            ModelDB eo = new ModelDB();
            eo.Categorys.Add(p);
            eo.SaveChanges();
            Console.WriteLine("insert Category");

        }

        public void Removeproduct(Product pr)
        {
            ModelDB eo = new ModelDB();
            ProductDB pdb=eo.Products.Find(pr.Barcode);
            eo.Products.Remove(pdb);
            eo.SaveChanges();
            Console.WriteLine("remove product");

        }

    }


}