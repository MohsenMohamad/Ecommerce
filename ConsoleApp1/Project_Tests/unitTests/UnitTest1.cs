using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using NUnit.Framework;
using Tests;
using Basket = ConsoleApp1.domainLayer.Business_Layer.Basket;
using Store = ConsoleApp1.domainLayer.Business_Layer.Store;
using SystemAdmin = ConsoleApp1.domainLayer.DataAccessLayer.SystemAdmin;
using User = ConsoleApp1.domainLayer.Business_Layer.User;

namespace Project_Tests.unitTests
{
     
    public class Tests:ATProject
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
            Purchase purchase = new Purchase();
            Store store1 = new Store(shady,"","");
            //UserSystemHandler ush = new UserSystemHandler(shady);
            SystemAdmin sa = new SystemAdmin();
            //StoreAdministration sadmin = new StoreAdministration();
            //ShoppingHandler shhand = new ShoppingHandler();
            Person ppe = new Guest();
            
            /*DataHandler dataHandler = DataHandler.Instance;
            ModelDB modelDb = new ModelDB();*/
            
        }

        [Test]
        public void Test()
        {
            //have to pass anyway
            Assert.AreEqual(shady.Cart.username, "shady");
        }
    }
}


/*
1.GenInterface
2.proxyImpl
3.ATP
4.add new classTestFile
*/