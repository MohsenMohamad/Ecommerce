using System.Linq;
using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class EditCartTests : ATProject
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
            AdminInitiateSystem();
        }

        [SetUp]
        public void Setup()
        {
            Register(UserName, Password);
            OpenStore(OwnerName, StoreName, "policy");
            AddProductToStore(OwnerName, StoreName, product1.barcode, product1.name, product1.description,
                product1.price, product1.Categories.ToString(), 3);
        }

        [Test]
        public void Happy()
        {
            // successfully delete
            const int amount = 3;
            AddProductToCart(UserName, StoreName, product1.barcode, amount, product1.Price);
            var basket = GetCartByStore(UserName, StoreName);
            Assert.AreEqual(basket[product1.barcode],amount);
            var removed = remove_item_from_cart(UserName,StoreName,product1.Barcode,amount);
            Assert.True(removed);
            var newBasket = GetCartByStore(UserName, StoreName);
            Assert.False(newBasket.ContainsKey(product1.barcode) && newBasket[product1.barcode]!=0);
        }
        
        [Test]
        public void ShouldFail()
        {
            // trying to remove amount x from basket which has only amount y , where y<x 
            
            const int amount = 3;
            AddProductToCart(UserName, StoreName, product1.barcode, amount, product1.Price);
            var removed = remove_item_from_cart(UserName,StoreName,product1.Barcode,amount+1);
            Assert.False(removed);
            Assert.AreEqual(GetCartByStore(UserName,StoreName)[product1.barcode],amount);
        }
        
        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteStore(StoreName);
            real.DeleteUser(UserName);
            
        }
        
        
    }
}