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
            Assert.True(AddProductToStore("user",storeName, product.Barcode, productName,product.Description,product.Price,"fashion#work",amount));
        }

        [Test]
        public void TestAdd()
        {
           
            //addProductsToShop("user", storeName, product.Barcode, amount);
            
            //happy
            Assert.True(GetStoreInventory("user", storeName).ContainsKey(product.Barcode));
            //bad
            Assert.True(AddProductToStore("user", storeName, product.Barcode,product.Name,product.Description,product.Price,product.Categories.ToString(), 50));
        }
        [Test]
        public void TestUpdate()
        {
            //happy
            UpdateProductAmountInStore("user", storeName, product.Barcode, amount - 1);
            int newAmount = (amount - 1);
            Assert.True(GetStoreInventory("user",storeName).ContainsKey(product.Barcode) && GetStoreInventory("user",storeName)[product.Barcode] == newAmount) ;
            //bad
            newAmount = (amount - 5);
            UpdateProductAmountInStore("user", storeName, product2.Barcode,amount - 5 );
            foreach (var VARIABLE in GetStoreInventory("user",storeName))
            {
                Assert.False(VARIABLE.Value == (newAmount));
            }
            
        }
        [Test]
        public void TestRemove()
        {
            
            //happy
            Assert.True(RemoveProductFromStore( UserName, storeName, product.Barcode));
            
            //bad
            Assert.False(RemoveProductFromStore( UserName, storeName, product2.Barcode));
        }
    }
}