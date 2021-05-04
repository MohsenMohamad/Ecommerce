using NUnit.Framework;
using Project_tests;
using Version1;
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
        }

        [Test]
        public void Happy()
        {
            AddProductToStore(TestUserName, TestStoreName, TestProductBarcode, 2);
            var result1 = AddProductToCart(TestUserName, TestStoreName, TestProductBarcode, 1);
            var result2 = Purchase(TestUserName, "Credit");

            Assert.True(result1 & result2);
            Assert.True(getStorePurchaseHistory(TestUserName,TestStoreName)?.Count == 1);
            Assert.False(GetCartByStore(TestUserName,TestStoreName).ContainsKey(TestProductBarcode));
        }

        [Test]
        public void Amount()
        {
            // The requested amount is not available
            
            AddProductToStore(TestUserName, TestStoreName, TestProductBarcode, 2);
            var result1 = AddProductToCart(TestUserName, TestStoreName, TestProductBarcode, 2);
            UpdateProductAmountInStore(TestUserName, TestStoreName, TestProductBarcode, 1);
            var result2 = Purchase(TestUserName, "Credit");
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(TestUserName,TestStoreName));
            Assert.True(GetCartByStore(TestUserName, TestStoreName)[TestProductBarcode] == 2); // cart still the same
            Assert.True(ExternalFinanceService.log.Count == 1); // only connection is from the setup
            Assert.True(ExternalFinanceService.log[0].Equals("connected"));
            Assert.True(ExternalSupplyService.log.Count == 1);  // only connection is from the setup
            Assert.True(ExternalSupplyService.log[0].Equals("connected"));
            
        }

        [Test]
        public void Policy()
        {
            // The requested amount is above the allowed amount
            
            AddProductToStore(TestUserName, TestStoreName, TestProductBarcode, 2);
            var result1 = AddProductToCart(TestUserName, TestStoreName, TestProductBarcode, 2);
            UpdateProductAmountInStore(TestUserName, TestStoreName, TestProductBarcode, 1);
            var result2 = Purchase(TestUserName, "Credit");
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(TestUserName,TestStoreName));
            Assert.True(GetCartByStore(TestUserName, TestStoreName)[TestProductBarcode] == 2); // cart still the same
            Assert.True(ExternalFinanceService.log.Count == 1); // only connection is from the setup
            Assert.True(ExternalFinanceService.log[0].Equals("connected"));
            Assert.True(ExternalSupplyService.log.Count == 1);  // only connection is from the setup
            Assert.True(ExternalSupplyService.log[0].Equals("connected"));
        }

        [Test]
        public void ShouldFail()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser(TestUserName);
            real.DeleteStore(TestStoreName);
            ExternalFinanceService.CreateConnection();
            ExternalSupplyService.CreateConnection();


        }
        
    }
}