using System.Collections.Generic;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.UnitTests.DiscountsTests
{
    public class conditionalShopDiscount : ATProject
    {

        private const string UserName = "User1";
        private const string Password = "123";
        private const string StoreName = "test";
        private const string OwnerName = "adnan";
        private static string electronics = "Electronics";
        private static List<string> catigories= new List<string>();
        
        private Product product1 ;

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
            catigories.Add(electronics);
            product1 = new Product("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
                800,
                catigories);
        }


        [Test]
        public void testShopConditionalDiscount()
        {
            int ShopPercentage = 50;
            
            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);
            var result1 = AddProductToCart(UserName, StoreName, product1.Barcode, 1, 800);
            double prieBeforeDiscount = GetTotalCart(UserName);
            Assert.True(addConditionalDiscount(StoreName, ShopPercentage,"(T[]))") == 1);
            
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