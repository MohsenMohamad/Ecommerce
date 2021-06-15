using System;
using System.Linq;
using NUnit.Framework;
using Project_tests;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.DiscountPolicies;
using Version1.Service_Layer;

namespace Project_Tests.UnitTests
{
    public class BuyFromCategoryDiscount : ATProject
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
            
            AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);
            
            double prieBeforeDiscount = GetTotalCart(UserName);
            
            //take the discount if you buy from category Electronics
            Assert.True(addConditionalDiscount(StoreName, ShopPercentage,string.Format("(C[{0}])", "Electronics"))  == 1);
            
            double priceAfterDiscount = GetTotalCart(UserName);
            Assert.True( ((1 - priceAfterDiscount/prieBeforeDiscount) * 100) == ShopPercentage);
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
