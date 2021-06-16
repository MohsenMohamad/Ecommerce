using System.Linq;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.StorePolicies;
using Version1.ExternalServices;
using Version1.Service_Layer;

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
            var financeLogCount = MockUpFinanceService.log.Count;
            var supplyLogCount = MockUpSupplyService.log.Count;
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);
            var result2 = Purchase(UserName, "Credit");

            Assert.True(result1 & result2);
    /*        Assert.True(getStorePurchaseHistory(UserName,StoreName)?.Count == 1);
            Assert.False(GetCartByStore(UserName,StoreName).ContainsKey(product1.Barcode));
            Assert.AreEqual(ExternalFinanceService.log.Count, financeLogCount + 1); // a connection has been established
            Assert.AreEqual(MockUpSupplyService.log.Count, supplyLogCount + 1);  // a connection has been established
            */
        }

        [Test]
        public void Amount()
        {
            // The requested amount is not available
            
            var financeLogCount = MockUpFinanceService.log.Count;
            var supplyLogCount = MockUpSupplyService.log.Count;
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 2, 800);
            UpdateProductAmountInStore(UserName, StoreName, product1.Barcode, 1);
            var result2 = Purchase(UserName, "Credit");
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(UserName,StoreName));
            Assert.True(GetCartByStore(UserName, StoreName)[product1.Barcode] == 2); // cart still the same
            Assert.AreEqual(MockUpFinanceService.log.Count, financeLogCount); // only connection is from the setup
            Assert.AreEqual(MockUpSupplyService.log.Count, supplyLogCount);  // only connection is from the setup
            
        }

        [Test]
        public void Policy()
        {
            // The requested amount is above the allowed amount

            var financeLogCount = MockUpFinanceService.log.Count;
            var supplyLogCount = MockUpSupplyService.log.Count;
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 6);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 5, 800);
            var result2 = Purchase(UserName, "Credit");
            
            Assert.True(result1); // added to cart
            Assert.False(result2); // could not purchase
            Assert.IsEmpty(getStorePurchaseHistory(UserName,StoreName));
            Assert.True(GetCartByStore(UserName, StoreName)[product1.Barcode] == 5); // cart still the same
            Assert.AreEqual(MockUpFinanceService.log.Count, financeLogCount); // only connection is from the setup
            Assert.AreEqual(MockUpSupplyService.log.Count, supplyLogCount);  // only connection is from the setup
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