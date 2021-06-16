using System.Linq;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class Uc411getStorePurchaseHistory:ATProject
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
        }

        [Test]
        public void PurchaseHistoryUpdatetest()
        {
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);
            var result2 =Purchase(UserName, "12341234", 11, 2030, "holder", 512, 208764533, "name", "address", "city",
                "country", 11);
            Assert.True(result1 & result2);
            var result3 = getStorePurchaseHistory(UserName, StoreName);
            Assert.NotNull(result3);

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