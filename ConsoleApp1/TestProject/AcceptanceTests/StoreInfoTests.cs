/*using System.Collections;
using Version1.domainLayer;
using NUnit.Framework;
using Project_tests;
using Version1.domainLayer.DataStructures;

namespace Project_Tests.AcceptanceTests
{
    public class StoreInfoTests : ATProject
    {
        
        private Hashtable storeProducts;
        private const string StoreName = "test";
        private const string TestOwnerName = "member";
        private const string TestOwnerPassword = "member";
        private const string TestStorePolicy = "policy";

        [SetUp]
        public void Setup()
        {
            Register(TestOwnerName, TestOwnerPassword);
            UserLogin(TestOwnerName, TestOwnerPassword);
            OpenStore(TestOwnerName, TestStorePolicy, StoreName);
            var product1 = new Product("salt", "kosher salt", "111", null);
            var product2 = new Product("tea", "black tea", "222", null);
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

        [Test]
        public void Happy()
        {
            var testInfo = GetStoreInfo(null, StoreName);
            Assert.NotNull(testInfo);
            Assert.Equals(testInfo.Name, StoreName);
            Assert.Equals(testInfo.Owner, TestOwnerName);
            Assert.Equals(testInfo.SellingPolicy, TestStorePolicy);
            Assert.True(CheckStoreInventory(testInfo.Name, storeProducts));
        }

        [Test]
        public void Sad()
        {
            //
        }

        [Test]
        public void Bad()
        {
        }

        [Test]
        public void ShouldFail()
        {
            var info = GetStoreInfo(null, "non-existing_store");
            Assert.IsNull(info);
        }
    }
}*/

namespace TestProject.AcceptanceTests
{
}