using System;
using System.Collections.Generic;
using System.Linq;
using Version1.domainLayer;
using Version1.Service_Layer;
using Version1.domainLayer.UserRoles;
using NUnit.Framework;
using Project_tests;
using Version1.domainLayer.DataStructures;

namespace Project_Tests.AcceptanceTests
{
    public class Uc41AddEditRemovePruduct:ATProject
    {

        private static SystemAdmin admin;
        private string productName;
        private Product product;
        private Product product2;
        private int amount;
        private string storeName;
        private string UserName;
        
        
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            admin.InitSystem();
            UserName = "user";
            //user = new User("user", "userPass");
            storeName = "helloWorldMarket";
            Register("user","userPass");
            UserLogin("user","userPass");
            OpenStore("user",storeName,"" );
            productName = "shampoo";
            product = new Product("shampoo",productName,"1",65,new List<string>());
            product2 = new Product("pringles",productName,"1",99,new List<string>());
            amount = 100;
            Assert.True(addNewProductToTheSystemAndAddItToShop(storeName, product.Barcode, amount, 9.99, product.Name, "",
                new[] {"fashio","work"}));
        }

        [Test]
        public void TestAdd()
        {
           
            //addProductsToShop("user", storeName, product.Barcode, amount);
            
            //happy
            Assert.True(getProductsFromShop("user", storeName)[0].Contains(productName));
            //bad
            Assert.True(addProductsToShop("user", storeName, product.Barcode, 50));
        }
        [Test]
        public void TestUpdate()
        {
            //happy
            updateProductsInShop("user", storeName, product.Barcode, amount - 1);
            string newAmount = (amount - 1) + "";
            Assert.True(getProductsFromShop("user",storeName)[0].Contains(newAmount)) ;
            //bad
            newAmount = (amount - 5)+ "";
            updateProductsInShop("user", storeName, product2.Barcode,amount - 5 );
            foreach (var VARIABLE in getProductsFromShop("user",storeName))
            {
                Assert.False(VARIABLE.Contains(newAmount));
            }
            
        }
        [Test]
        public void TestRemove()
        {
            
            //happy
            Assert.True(removeProductsInShop( UserName, storeName, product.Barcode));
            
            //bad
            Assert.False(removeProductsInShop( UserName, storeName, product2.Barcode));
        }
    }
}