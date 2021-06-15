using System;
using System.Linq;
using NUnit.Framework;
using Project_tests;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.DiscountPolicies;
using Version1.Service_Layer;

namespace Project_Tests.UnitTests
{
    public class DiscountsTests : ATProject
    {

         private const string UserName = "User1";
        private const string Password = "123";
        private const string OwnerName = "adnan";
        private const string StoreName = "AdnanStore";
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
        }

        [Test]
        public void testStorePublicDiscount()
        {
            int percentage = 50;
            // the product is added to the cart and the amount should not change in the store
            UserLogin(UserName,Password);
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            
            AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);
            double prieBeforeDiscount = GetTotalCart(UserName);
            Assert.True(addPublicStoreDiscount(StoreName, percentage) == 1);
            double prieAfterDiscount = GetTotalCart(UserName);
            
            Assert.True( ((prieAfterDiscount/prieBeforeDiscount) * 100) == percentage);
            
            UserLogout(UserName);
        }
        [Test]
        public void testItemPublicDiscount()
        {
            int percentage = 50;
            int PriceOfOne = 800;
            // the product is added to the cart and the amount should not change in the store
            UserLogin(UserName,Password);
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            
            AddProductToCart(UserName, StoreName, product1.Barcode, 1, PriceOfOne);
            double prieBeforeDiscount = GetTotalCart(UserName);
            Assert.True(addPublicDiscountToItem(StoreName,product1.Barcode, 50) == 1);
            double prieAfterDiscount = GetTotalCart(UserName);
            
            Assert.True( prieBeforeDiscount - prieAfterDiscount == PriceOfOne / 2);
            
            UserLogout(UserName);
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
