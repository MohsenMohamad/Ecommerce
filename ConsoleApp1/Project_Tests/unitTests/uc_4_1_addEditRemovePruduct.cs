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
        private string productName;
        private Product product;
        private Product product2;
        private int amount;
        
        [SetUp]
        public void Setup()
        {
            user = new User("user", "userPass");
            guest = new Guest();
            admin = new SystemAdmin();
            initSystem(admin);
            OpenStore(user,"", "helloMarket");
            productName = "shampoo";
            product = new Product("shampoo",productName,1,new List<Category>());
            product2 = new Product("pringles",productName,1,new List<Category>());
            amount = 100;
        }

        [Test]
        public void TestAdd()
        {
            addProductsToShop(user, "helloMarket", product, amount);
            
            //happy
            Assert.True(getProductsFromShop(user,"helloMarket").ContainsKey(product));
            //bad
            Assert.True(addProductsToShop(user, "helloMarket", product, 50));
        }
        [Test]
        public void TestUpdate()
        {
            //happy
            updateProductsInShop(user, "helloMarket", product, amount - 1);
            Assert.True(getProductsFromShop(user,"helloMarket").GetValueOrDefault(product) == amount -1);
            //bad
            Assert.True(updateProductsInShop(user, "helloMarket", product2, amount - 1));
        }
        [Test]
        public void TestRemove()
        {
            removeProductsInShop(user, "helloMarket", product);
            //happy
            Assert.False(getProductsFromShop(user,"helloMarket").ContainsKey(product));
            //bad
            Assert.False(removeProductsInShop(user, "helloMarket", product2));
        }
    }
}