using NUnit.Framework;
using Project_tests;
using Version1;
using Version1.domainLayer.StorePolicies;
using Version1.ExternalServices;

namespace Project_Tests.AcceptanceTests
{
    public class PurchaseByCreditTests : ATProject
    {
        private const string TestUserName = "User1";
        private const string TestUserPassword = "123";
        private const string TestProductBarcode = "1";
        private const string TestStoreName = "test";

        [OneTimeSetUp]
        public void SetUpSystem()
        {
            AdminInitiateSystem();
        }
        [SetUp]
        public void SetUp()
        {
            Register(TestUserName, TestUserPassword);
            OpenStore(TestUserName, TestStoreName, "policy");
            UpdatePurchasePolicy(TestStoreName,new MaxAmountPolicy(4));

        }

        [Test]
        public void Happy()
        {
            var financeLogCount = ExternalFinanceService.log.Count;
            var supplyLogCount = ExternalSupplyService.log.Count;
            
            AddProductToStore(TestUserName, TestStoreName, TestProductBarcode, 2);
            var result1 = AddProductToCart(TestUserName, TestStoreName, TestProductBarcode, 1);
            var result2 = Purchase(TestUserName, "Credit");

            Assert.True(result1 & result2);
            Assert.True(getStorePurchaseHistory(TestUserName,TestStoreName)?.Count == 1);
            Assert.False(GetCartByStore(TestUserName,TestStoreName).ContainsKey(TestProductBarcode));
            Assert.AreEqual(ExternalFinanceService.log.Count, financeLogCount + 1); // a connection has been established
            Assert.AreEqual(ExternalSupplyService.log.Count, supplyLogCount + 1);  // a connection has been established
        }

        [Test]
        public void Amount()
        {
            // The requested amount is not available
            
            var financeLogCount = ExternalFinanceService.log.Count;
            var supplyLogCount = ExternalSupplyService.log.Count;
            
            AddProductToStore(TestUserName, TestStoreName, TestProductBarcode, 2);
            var result1 = AddProductToCart(TestUserName, TestStoreName, TestProductBarcode, 2);
            UpdateProductAmountInStore(TestUserName, TestStoreName, TestProductBarcode, 1);
            var result2 = Purchase(TestUserName, "Credit");
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(TestUserName,TestStoreName));
            Assert.True(GetCartByStore(TestUserName, TestStoreName)[TestProductBarcode] == 2); // cart still the same
            Assert.AreEqual(ExternalFinanceService.log.Count, financeLogCount); // only connection is from the setup
            Assert.AreEqual(ExternalSupplyService.log.Count, supplyLogCount);  // only connection is from the setup
            
        }

        [Test]
        public void Policy()
        {
            // The requested amount is above the allowed amount

            var financeLogCount = ExternalFinanceService.log.Count;
            var supplyLogCount = ExternalSupplyService.log.Count;
            
            AddProductToStore(TestUserName, TestStoreName, TestProductBarcode, 6);
            var result1 = AddProductToCart(TestUserName, TestStoreName, TestProductBarcode, 5);
            var result2 = Purchase(TestUserName, "Credit");
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(TestUserName,TestStoreName));
            Assert.True(GetCartByStore(TestUserName, TestStoreName)[TestProductBarcode] == 5); // cart still the same
            Assert.AreEqual(ExternalFinanceService.log.Count, financeLogCount); // only connection is from the setup
            Assert.AreEqual(ExternalSupplyService.log.Count, supplyLogCount);  // only connection is from the setup
        }
        
        
        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser(TestUserName);
            real.DeleteStore(TestStoreName);
            
        }
        
    }
}