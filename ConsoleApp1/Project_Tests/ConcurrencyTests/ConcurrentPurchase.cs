using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Version1;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentPurchase : ATProject
    {
        
        private const string OwnerName = "adnan";
        private const string StoreName = "AdnanStore";
        private static Category electronics = new Category("Electronics");
        private Product product1 = new Product("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
            800,
            new[] {electronics.Name}.ToList());

        [OneTimeSetUp]
        public void SetUp()
        {
            AdminInitiateSystem();
            
        }

        [SetUp]
        public void ResetUsers()
        {
            Register("User1", "Password1");
            Register("User2", "Password2");
            Register("User3", "Password3");
        }

        [Test]
        public void Happy()
        {
            // both purchases should be completed and the amount in inventory should be correct
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 3);
            
            
            AddProductToCart("User1", "AdnanStore", "1", 1, product1.price);
            var result1 = false;
            var task1 = Task.Factory.StartNew(() => result1 = Purchase("User1","Credit"));

            AddProductToCart("User2", "AdnanStore", "1", 1, product1.price);
            var result2 = false;
            var task2 = Task.Factory.StartNew(() => result2 = Purchase("User2","Credit"));

            Task.WaitAll(task1, task2);

            var newInventory = GetStoreInventory("adnan","AdnanStore");
            var result3 = newInventory != null && newInventory.ContainsKey("1") && newInventory["1"] == 1;
            Assert.True(result1 & result2 & result3);
            
        }

        [Test]
        public void Sad()
        {
            
            // only one of the purchases should be completed
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 1);
            
            
            AddProductToCart("User1", "AdnanStore", "1", 1, product1.price);
            var result1 = false;
            var task1 = Task.Factory.StartNew(() => result1 = Purchase("User1","Credit"));

            AddProductToCart("User2", "AdnanStore", "1", 1, product1.price);
            var result2 = false;
            var task2 = Task.Factory.StartNew(() => result2 = Purchase("User2","Credit"));

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2);
            
        }
        
        
        [Test]
        public void ShouldFail()
        {
            // adding an amount to a product with 0 current amount and buying at the same time (sometimes fails sometimes works)
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            AddProductToCart("User1", "AdnanStore", "1", 2, product1.price);
            UpdateProductAmountInStore("adnan", "AdnanStore", "1", 1);
            
            var result1 = false;
            var task1 = Task.Factory.StartNew(() => result1 = Purchase("User1","Credit"));
            
            var result2 = false;
            var task2 = Task.Factory.StartNew(() => result2 = AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 1));

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 & result2);
        }


        [TearDown]
        public void ResetProductInStore()
        {
            var real = new RealProject();
            
            real.DeleteUser("User1");
            real.DeleteUser("User2");
            real.DeleteUser("User3");
            RemoveProductFromStore("adnan", "AdnanStore", "1");
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var real = new RealProject();
            real.ResetMemory();
        }
        
    }
}