using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;

namespace Tests
{
    public class uc_4_1_addEditRemovePruduct
    {
        private static User user;
        private static Guest guest;
        private static Store store;
        private static SystemAdminImpl admin;
        
        [SetUp]
        public void Setup()
        {
            user = new User("user", "userPass");
            guest = new Guest();
            //store = new Store(user,"","happyMarket");
            admin = new SystemAdmin();
            admin.initSystem();
            user.OpenStore("", "helloMarket");
        }

        [Test]
        public void TestAddEditRemovePruduct()
        {
            string productName = "shampoo";
            Product product = new Product("",productName,1,new List<Category>());
            int amount = 100;
            //check add
            Assert.True(user.addProductsToShop("helloMarket",product,amount));
            Assert.True(user.editStoreProduct("helloMarket",productName,amount-1));
            Assert.True(user.removeStoreProduct("helloMarket",productName));
        }
    }
}