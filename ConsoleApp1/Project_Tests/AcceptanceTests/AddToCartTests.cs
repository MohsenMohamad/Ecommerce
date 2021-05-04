using NUnit.Framework;
using Project_tests;
using Version1;

namespace Project_Tests.AcceptanceTests
{
    public class AddToCartTests : ATProject
    {
        private const string TestUserName = "User1";
        private const string TestUserPassword = "123";
        private const string TestStoreName = "AdnanStore";
        private const string TestStoreOwner = "adnan";
        private const string TestProductBarcode = "1";


        [OneTimeSetUp]
        public void SetUpSystem()
        {
            AdminInitiateSystem();
        }

        [SetUp]
        public void SetUp()
        {
            Register(TestUserName, TestUserPassword);
        }

        [Test]
        public void Happy()
        {
            // the product is added to the cart and the amount should not change in the store

            AddProductToStore(TestStoreOwner, TestStoreName, TestProductBarcode, 2);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, TestProductBarcode, 1));
            Assert.True(getProductsFromShop(TestStoreOwner, TestStoreName)[TestProductBarcode] == 2);
            GuestLogout(id);
        }

        [Test]
        public void Sad()
        {
            // the product has 0 amount in the store but we should still be able to add it


            AddProductToStore(TestStoreOwner, TestStoreName, TestProductBarcode, 0);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, TestProductBarcode, 0));
            GuestLogout(id);
        }

        [Test]
        public void Bad()
        {
            // by adding the same product from the same store twice the amount should be added .

            AddProductToStore(TestStoreOwner, TestStoreName, TestProductBarcode, 3);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, TestProductBarcode, 1));
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, TestProductBarcode, 1));
            Assert.True(GetCartByStore(id.ToString(), TestStoreName)[TestProductBarcode] == 2);
            GuestLogout(id);
        }

        [Test]
        public void ShouldFail()
        {
            // as a guest , add to cart , then logout , then login as guest again , check if the product still exists

            AddProductToStore(TestStoreOwner, TestStoreName, TestProductBarcode, 3);

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, TestProductBarcode, 2));
            GuestLogout(id);

            id = GuestLogin();
            var cart = GetCartByStore(id.ToString(), TestStoreName);
            Assert.True(cart == null || !cart.ContainsKey(TestProductBarcode));
            GuestLogout(id);
        }

        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();

            real.DeleteUser(TestUserName);
            RemoveProductFromStore(TestStoreOwner, TestStoreName, TestProductBarcode);
        }
    }
}