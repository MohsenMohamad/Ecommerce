using System.Linq;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class PurchasesHistoryTests : ATProject
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
        public void OneTimeSetup()
        {
            Register(UserName, Password);

        }
        
        [SetUp]
        public void SetUp()
        {
            AdminInitiateSystem();
            OpenStore(OwnerName, StoreName, "policy");
            UserLogin(UserName, Password);
        AddProductToStore(OwnerName, StoreName, product1.barcode, product1.name, product1.description,
                product1.price, product1.Categories.ToString(), 1);
        AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);

        }

        [Test]
        [Order(1)]
        public void Happy()
        {
            var count = GetUserPurchaseHistoryList(UserName).Count;
            // purchase
            var d =Purchase(UserName, "12341234", 11, 2030, "holder", 512, 208764533, "name", "address", "city",
                "country", 11);
            var newHistory = GetUserPurchaseHistoryList(UserName);
            // check if the history changed
            Assert.True(newHistory.Count == count + 1);
            // check also the purchase details from the history
            var purchaseReceipt = newHistory.Last();
            Assert.AreEqual(purchaseReceipt.store,StoreName);
            Assert.AreEqual(purchaseReceipt.user,UserName);
            Assert.AreEqual(purchaseReceipt.items.Count,1); // Bought 1 type of products 
            Assert.AreEqual(purchaseReceipt.items.First().Key.barcode,product1.barcode);
            Assert.AreEqual(purchaseReceipt.items.First().Value,1); // Bought amount 1 from this product
        }

        [Test]
        [Order(2)]
        public void Sad()
        {
            var count = GetUserPurchaseHistoryList(UserName).Count;
            // purchase
            Purchase(UserName, "12341234", 11, 2030, "holder", 512, 208764533, "name", "address", "city",
                "country", 11);
            // Delete Product from store
            RemoveProductFromStore(OwnerName, StoreName, product1.barcode);
            var newHistory = GetUserPurchaseHistoryList(UserName);
            // check if the receipt was added
            Assert.True(newHistory.Count == count + 1);
            // check if the product barcode is still there
            Assert.AreEqual(product1.barcode,newHistory.Last().items.First().Key.barcode);
        }
        
        
        [Test]
        [Order(3)]
        public void Bad()
        {
            // this history should have at least two purchases , if the previous tests passed ...
            var history = GetUserPurchaseHistoryList(UserName);
            // first purchase date
            var prevPurchaseDate = history.First().date;
            foreach (var purchaseDate in history.Select(p=> p.date))
            {
                //compare the dates of purchases , it should be in order

                Assert.True(prevPurchaseDate.CompareTo(purchaseDate) <= 0);
                prevPurchaseDate = purchaseDate;
            }
        }

        [Test]
        public void ShouldFail()
        {
            var count = GetUserPurchaseHistoryList(UserName).Count;
            // purchase Did not work
            const int failCcv = 986;
            var purchase =Purchase(UserName, "12341234", 11, 2030, "holder", failCcv, 208764533, "name", "address", "city",
                "country", 11);
            Assert.False(purchase);
            // check the history
            Assert.AreEqual(GetUserPurchaseHistoryList(UserName).Count,count);
        }
        
        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
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