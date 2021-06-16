using System.Linq;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;

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

        
        
        [SetUp]
        public void SetUp()
        {
            UserLogin(UserName, Password);
            AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);

        }

        [Test]
        public void Happy()
        {
            var count = GetUserPurchaseHistoryList(UserName).Count;
            // purchase
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
        public void Sad()
        {
            var count = GetUserPurchaseHistoryList(UserName).Count;
            // purchase
            // Delete Product from store
            RemoveProductFromStore(OwnerName, StoreName, product1.barcode);
            var newHistory = GetUserPurchaseHistoryList(UserName);
            // check if the receipt was added
            Assert.True(newHistory.Count == count + 1);
            // check if the product barcode is still there
            Assert.AreEqual(product1.barcode,newHistory.Last().items.First().Key.barcode);
        }
        
        [Test]
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

        public void ShouldFail()
        {
            var count = GetUserPurchaseHistoryList(UserName).Count;
            // purchase Did not work
            //Assert.False(Purchase());
            // check the history
            Assert.AreEqual(GetUserPurchaseHistoryList(UserName),count);
        }
    }
}