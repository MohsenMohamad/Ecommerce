using System.Linq;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class AddToCartTests : ATProject
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
        public void Happy()
        {
            // the product is added to the cart and the amount should not change in the store

            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), StoreName, product1.Barcode, 1, 800));
            Assert.True(GetStoreInventory(OwnerName, StoreName)[product1.Barcode] == 2);
            GuestLogout(id);
        }

        [Test]
        public void Sad()
        {
            // the product has 0 amount in the store but we should still be able to add it


            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 0);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), StoreName, product1.Barcode, 0, 800));
            GuestLogout(id);
        }

        [Test]
        public void Bad()
        {
            // by adding the same product from the same store twice the amount should be added .

            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 3);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), StoreName, product1.Barcode, 1, 800));
            Assert.True(AddProductToCart(id.ToString(), StoreName, product1.Barcode, 1, 800));
            Assert.True(GetCartByStore(id.ToString(), StoreName)[product1.Barcode] == 2);
            GuestLogout(id);
        }

        [Test]
        public void ShouldFail()
        {
            // as a guest , add to cart , then logout , then login as guest again , check if the product still exists

            AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 3);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), StoreName, product1.Barcode, 2, 800));
            GuestLogout(id);

            id = GuestLogin();
            var cart = GetCartByStore(id.ToString(), StoreName);
            Assert.True(cart == null || !cart.ContainsKey(product1.Barcode));
            GuestLogout(id);
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