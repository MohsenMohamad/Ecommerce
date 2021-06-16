using System.Collections;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;

namespace TestProject.UnitTests
{
    public class StoreTests : ATProject
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
            var product1 = new Product("salt", "kosher salt", "111", 5, null);
            var product2 = new Product("tea", "black tea", "222", 6, null);
            const int product1Amount = 2;
            const int product2Amount = 4;
            storeProducts = new Hashtable();
            storeProducts.Add(product1, product1Amount);
            storeProducts.Add(product2, product2Amount);
            AddProductToStore(TestOwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,"salts", product1Amount);
            AddProductToStore(TestOwnerName, StoreName, product2.Barcode,product2.Name,product2.Description,product2.Price,"herbal drinks", product2Amount);
            UserLogout(TestOwnerName);

            GuestLogin();

        }

        [Test]
        public void Open_Store()
        {
            if (!UserLogin("member", "member"))
            {
                Assert.Fail("fail to login");
            }
            if (!OpenStore(TestOwnerName, StoreName, TestStorePolicy))
            {
                Assert.Fail("fail to open store");
            }
            Assert.IsTrue(true);
        }

    }
}
