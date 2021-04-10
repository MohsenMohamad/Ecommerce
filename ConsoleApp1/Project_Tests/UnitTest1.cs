using NUnit.Framework;

using System;
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
            
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(2, 3);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(shady.Cart.username, "shady");
        }
    }
}