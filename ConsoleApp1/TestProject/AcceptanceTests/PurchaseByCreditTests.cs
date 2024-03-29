﻿using System.Linq;
using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.DomainLayer.StoreFeatures.StorePolicies;
using ServiceLogic.ExternalServices;
using ServiceLogic.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class PurchaseByCreditTests : ATProject
    {
        private const string UserName = "User1";
        private const string Password = "123";
        private const string StoreName = "test";
        private const string OwnerName = "adnan";
        private static Category electronics = new Category("Electronics");
        private Product product1 = new Product("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
            800,
            new[] {electronics.Name}.ToList());

        [OneTimeSetUp]
        public void SetUpSystem()
        {
             AdminInitiateSystem();
        }
        [SetUp]
        public void SetUp()
        {
            Register(UserName, Password);
            OpenStore(UserName, StoreName, "policy");
            UpdatePurchasePolicy(StoreName,new MaxAmountPolicy(product1.Barcode,4));

        }

        [Test]
        public void Happy()
        {

            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);
            var prevNotifications = GetUserNotifications(UserName).Count;
            var result2 = Purchase(UserName, "12341234", 11, 2030, "holder", 512, 208764533, "name", "address", "city",
                "country", 11);

            Assert.True(result1 & result2);
            Assert.True(getStorePurchaseHistory(UserName,StoreName)?.Count == 1);
            Assert.IsNull(GetCartByStore(UserName,StoreName));
            Assert.AreEqual(GetUserNotifications(UserName).Count,prevNotifications+1);
 
        }

        [Test]
        public void Amount()
        {
            // The requested amount is not available

            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 2, 800);
            UpdateProductAmountInStore(UserName, StoreName, product1.Barcode, 1);
            var prevNotifications = GetUserNotifications(UserName).Count;
            var result2 = Purchase(UserName, "12341234", 11, 2030, "holder", 512, 208764533, "name", "address", "city",
                "country", 11);
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(UserName,StoreName));
            Assert.True(GetCartByStore(UserName, StoreName)[product1.Barcode] == 2); // cart still the same
            Assert.AreEqual(GetUserNotifications(UserName).Count,prevNotifications);

            
        }

        [Test]
        public void Policy()
        {
            // The requested amount is above the allowed amount
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 6);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 5, 800);
            var prevNotifications = GetUserNotifications(UserName).Count;
            var result2 = Purchase(UserName, "12341234", 11, 2030, "holder", 512, 208764533, "name", "address", "city",
                "country", 11);
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(UserName,StoreName));
            Assert.True(GetCartByStore(UserName, StoreName)[product1.Barcode] == 5); // cart still the same
            Assert.AreEqual(GetUserNotifications(UserName).Count,prevNotifications);

        }
        
        
        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser(UserName);
            real.DeleteStore(StoreName);
            
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            var real = new RealProject();
            real.ResetMemory();
        }
        
    }
}