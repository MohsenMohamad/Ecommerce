using System;
using Version1.LogicLayer;
using System.Collections;
using Version1.domainLayer;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.UnitTests
{
    public class StoreTests : ATProject
    {

        private Hashtable storeProducts;
        private const string StoreName = "test";
        private const string TestOwnerName = "member";
        private const string TestOwnerPassword = "member";
        private const string TestStorePolicy = "policy";
        private User user = new User("Admin", "Admin");
        [SetUp]
        public void Setup()
        {
            Register(TestOwnerName, TestOwnerPassword);
            UserLogin(TestOwnerName, TestOwnerPassword);
            OpenStore(TestOwnerName, TestStorePolicy, StoreName);
            var product1 = new Product("salt", "kosher salt", "111", 5, null);
            var product2 = new Product("tea", "black tea", "222", 6, null);
            const int product1Amount = 2;
            const int product2Amount = 4;
            storeProducts = new Hashtable();
            storeProducts.Add(product1, product1Amount);
            storeProducts.Add(product2, product2Amount);
            AddProductToStore(TestOwnerName, StoreName, product1.Barcode, product1Amount);
            AddProductToStore(TestOwnerName, StoreName, product2.Barcode, product2Amount);
            UserLogout(TestOwnerName);

            GuestLogin();

        }


        public void Open_Store()
        {
            if (!UserLogin("Admin", "Admin"))
            {
                Assert.Fail("fail to login");
            }
            if (!OpenStore(TestOwnerName, TestStorePolicy, StoreName))
            {
                Assert.Fail("fail to open store");
            }
            Assert.IsTrue(true);
        }

    }
}
