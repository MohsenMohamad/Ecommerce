using System.Linq;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.UnitTests.DiscountsTests
{
    public class SpendAtLeastYConditionalDiscount : ATProject
    {

        private const string UserName = "User1";
        private const string Password = "123";
        private const string StoreName = "test";
        private const string OwnerName = "adnan";
        private static Category electronics = new Category("Electronics");
        private Product product1 = new Product("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
            800,
            new[] {electronics.Name}.ToList());
        private Product product2 = new Product("2", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
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
        public void testShopConditionalDiscount()
        {
            int ShopPercentage = 50;
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            AddProductToStore(OwnerName, StoreName, product2.Barcode,product2.Name,product2.Description,product2.Price,product2.Categories.ToString(), 2);
            AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);
            AddProductToCart(UserName, StoreName, product2.Barcode, 1, 800);
            
            double prieBeforeDiscount = GetTotalCart(UserName);
            //spend more or equal to 800 from other items in the shop to get the percentage discount
            Assert.True(addConditionalDiscount(StoreName, ShopPercentage,"(B[800])") == 1);
            
            double prieAfterDiscount = GetTotalCart(UserName);
            Assert.True( ((1 - prieAfterDiscount/prieBeforeDiscount) * 100) == ShopPercentage);
        }

        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();

            real.DeleteUser(UserName);
            RemoveProductFromStore(OwnerName, StoreName, product1.Barcode);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var real = new RealProject();
            real.ResetMemory();
        }

    }
}