using NUnit.Framework;
using Project_tests;
using Version1.domainLayer.DataStructures;

namespace Project_Tests.AcceptanceTests
{
    /*
    public class AddToCartTests : ATProject
    {
        private const string TestUserName = "AddToCartTester";
        private const string TestUserPassword = "AddToCartTester";
        private const string TestStoreName = "AddToCartStoreTest";
        private Product bread,tea;
        

        [SetUp]
        public void Setup()
        {
            Register(TestUserName, TestUserPassword);
            UserLogin(TestUserName, TestUserPassword);
            
            OpenStore(TestUserName, "policy", TestStoreName);
            bread = new Product("Bread", "Whole wat bread", "133", null);
            tea = new Product("tea", "black tea", "222", null);
            const int product1Amount = 0;
            const int product2Amount = 4;
            AddProductToStore(TestUserName, TestStoreName, bread.Barcode, product1Amount);
            AddProductToStore(TestUserName, TestStoreName, tea.Barcode, product2Amount);

            UserLogout(TestUserName);

        }

        [Test]
        public void Happy()
        {
            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, tea.Barcode,1));
            GuestLogout();
        }

        [Test]
        public void Sad()
        {
            // bread has 0 amount in the store but we should still be able to add it

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, bread.Barcode,0));
            GuestLogout();
        }

        [Test]
        public void Bad()
        {
            // the user should not be able to add to the cart the same product from the same store twice

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, tea.Barcode,1));
            Assert.False(AddProductToCart(id.ToString(), TestStoreName, tea.Barcode,1));
            GuestLogout();
        }

        [Test]
        public void ShouldFail()
        {
            // add to cart , then logout , then login as guest again , check if the product still exists

            var id = GuestLogin();
            Assert.True(AddProductToCart(id.ToString(), TestStoreName, tea.Barcode,1));
            GuestLogout();

            id = GuestLogin();
            Assert.False(GetCartByStore(id.ToString(), TestStoreName).Contains(tea));
            GuestLogout();
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
    */
}