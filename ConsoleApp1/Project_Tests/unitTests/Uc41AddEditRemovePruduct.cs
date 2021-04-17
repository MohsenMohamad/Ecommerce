using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;
using Tests;

namespace Project_Tests.unitTests
{
    public class Uc41AddEditRemovePruduct:ATProject
    {
        private static User user;

        private static Store store;
        private static SystemAdmin admin;
        private string productName;
        private Product product;
        private Product product2;
        private int amount;
        private string storeName;
        
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            initSystem(admin);
            
            //user = new User("user", "userPass");
            storeName = "helloWorldMarket";
            signUpGuest("user","userPass");
            user = loginGuest("user","userPass");
            OpenStore(user,"", storeName);
            productName = "shampoo";
            product = new Product("shampoo",productName,1,new List<Category>());
            product2 = new Product("pringles",productName,1,new List<Category>());
            amount = 100;
        }

        [Test]
        public void TestAdd()
        {
            addProductsToShop(user, storeName, product, amount);
            
            //happy
            Assert.True(getProductsFromShop(user,storeName).ContainsKey(product));
            //bad
            Assert.True(addProductsToShop(user, storeName, product, 50));
        }
        [Test]
        public void TestUpdate()
        {
            //happy
            updateProductsInShop(user, storeName, product, amount - 1);
            Assert.True(getProductsFromShop(user,storeName).GetValueOrDefault(product) == amount -1);
            //bad
            Assert.True(updateProductsInShop(user, storeName, product2, amount - 1));
        }
        [Test]
        public void TestRemove()
        {
            removeProductsInShop(user, storeName, product);
            //happy
            Assert.False(getProductsFromShop(user,storeName).ContainsKey(product));
            //bad
            Assert.False(removeProductsInShop(user, storeName, product2));
        }
    }
}