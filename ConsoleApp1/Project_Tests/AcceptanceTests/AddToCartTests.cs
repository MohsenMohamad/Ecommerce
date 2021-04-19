using ConsoleApp1.domainLayer.Business_Layer;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class AddToCartTests : ATProject
    {
        private User guest;
        private Store store;
        private Product bread,tea;
        

        [SetUp]
        public void Setup()
        {
            var member = new User("member", "member");
            //    member.Login();
            store = OpenStore(member, "policy", "test");
            bread = new Product("Bread", "Whole wat bread", 133, null);
            tea = new Product("tea", "black tea", 222, null);
            const int product1Amount = 0;
            const int product2Amount = 4;
            AddProductToStore(member, store, bread, product1Amount);
            AddProductToStore(member, store, tea, product2Amount);
            //        member.logout();
            
        }

        [Test]
        public void Happy()
        {
            // Guest()
            Assert.True(AddProductToCart(guest, store, tea));
            // Logout()
        }

        [Test]
        public void Sad()
        {
            // bread has 0 amount in the store but we should still be able to add it
            
            // Guest()
            Assert.True(AddProductToCart(guest, store, bread));
            // Logout()
        }

        [Test]
        public void Bad()
        {
            // the user should not be able to add to the cart the same product from the same store twice
            
            // Guest()
            Assert.True(AddProductToCart(guest, store, tea));
            Assert.False(AddProductToCart(guest, store, tea));
            // Logout()
        }

        [Test]
        public void ShouldFail()
        {
            // add to cart , then logout , then login as guest again , check if the product still exists
            
            // Guest()
            Assert.True(AddProductToCart(guest, store, tea));
            // Logout()
            
            // Guest()
            Assert.False(GetCartByStore(guest, store).Contains(tea));
        }
    }
}