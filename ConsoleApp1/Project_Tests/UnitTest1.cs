using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ConsoleApp1.Service_Layer;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using ConsoleApp1.Service_Layer;

namespace Tests
{
    public class Tests
    {
        private ShoppingCart shch;
        
        User shady;
        
        
        //shady.;
        //Store store  = new Store("");
        //ShoppingHandler sh = new ConsoleApp1.Service_Layer.ShoppingHandler();
        
        //UserSystemHandler ush = new UserSystemHandler();
        //SystemAdmin sa = new SystemAdmin();
        //StoreAdministration sad = new StoreAdministration();
        [SetUp]
        public void Setup()
        {
            ShoppingCart shch = new ShoppingCart("shady");
            Basket basket = new Basket("ebay");
            shch.AddBasket(basket);
            shady = new User("shady","pass");
            shady.setShoppingchart(shch);
            Category cat = new Category("catgory1");
            Guest guest1 = new Guest();
            guest1.setShoppingCart(shch);
            Discount dis = new Discount();
            Product p1 = new Product("","",5,new List<Category>());
            Purchase purchase = new Purchase(new List<KeyValuePair<Product, int>>());
            Store store1 = new Store(shady,"","");
            UserSystemHandler ush = new UserSystemHandler(shady);
            SystemAdmin sa = new SystemAdmin();
            StoreAdministration sadmin = new StoreAdministration();
            ShoppingHandler shhand = new ShoppingHandler();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(2, 2);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(shady.Cart.username, "shady");
        }
    }
}