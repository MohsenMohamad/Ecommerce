using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp1
{
    public class ModelDB : DbContext
    {
        // Your context has been configured to use a 'ModelDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ConsoleApp1.ModelDB' database on your LocalDb instance. 
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
    }

    public class ProductDB {
        [Key]
        [Required]
        public int barcode { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Basket
    {
        [Key]
        [Required]
        public int barcode { get; set; }
        public string Storename  { get; set; }
    }

    internal class database {
        public void Insertproduct(Product pr)
        {
            ProductDB p = new ProductDB();
            p.barcode = pr.Barcode;
            p.name = pr.Name;
            p.description = pr.Description;
            ModelDB eo = new ModelDB();
            eo.Products.Add(p);
            eo.SaveChanges();
            Console.WriteLine("insert product");
            Console.ReadLine();

        }

        public void Removeproduct(Product pr)
        {
            ModelDB eo = new ModelDB();
            ProductDB pdb=eo.Products.Find(pr.Barcode);
            eo.Products.Remove(pdb);
            eo.SaveChanges();
            Console.WriteLine("remove product");
            Console.ReadLine();

        }


    }


}