using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;

namespace Tests
{
    public class uc_4_1_addEditRemovePruduct:ATProject
    {
        private static User user;
        private static Guest guest;
        private static Store store;
        private static SystemAdmin admin;
        
        [SetUp]
        public void Setup()
        {
            user = new User("user", "userPass");
            guest = new Guest();
            admin = new SystemAdmin();
            initSystem(admin);
            OpenStore(user,"", "helloMarket");
        }

        [Test]
        public void Test()
        {
            string productName = "shampoo";
            Product product = new Product("",productName,1,new List<Category>());
            int amount = 100;
            //check add
            Assert.True(addProductsToShop(user,"helloMarket",product,amount));
            Assert.True(updateProductsInShop(user,"helloMarket",product,amount-1));
            Assert.True(removeProductsInShop(user,"helloMarket",product));
        }
    }
}