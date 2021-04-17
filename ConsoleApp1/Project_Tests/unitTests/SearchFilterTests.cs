using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using NUnit.Framework;

namespace Project_tests.unitTests
{
    public class SearchFilterTests : ATProject
    {
        private User guest;
        private Product product1;
        private Product product2;
        private Product product3;
        private Product product4;

        [SetUp]
        public void Setup()
        {
            var member = new User("member", "member");
            var store = OpenStore(member, "policy", "test store");
            product1 = new Product("tomato", "vegetables&fruit", 20, null);
            product2 = new Product("tomato sauce", "canned", 100, null);
            product3 = new Product("salt", "kosher salt", 111, null);
            product4 = new Product("tea", "black tea", 222, null);
            const int product1Amount = 1;
            const int product2Amount = 2;
            const int product3Amount = 3;
            const int product4Amount = 4;
            AddProductToStore(member, store, product1, product1Amount);
            AddProductToStore(member, store, product2, product2Amount);
            AddProductToStore(member, store, product3, product3Amount);
            AddProductToStore(member, store, product4, product4Amount);
        //    guest = GuestLogin("guest", "guest");
        }

        [Test]
        public void Happy()
        {
            var filters = new List<string> {"name : tea"};
            var result = SearchFilter(guest, null, filters);
            Assert.NotNull(result);
            Assert.True(result.Count == 1);
            var resultProduct = result[0];
            Assert.Equals(resultProduct.Name, product4.Name);
            Assert.Equals(resultProduct.Barcode, product4.Barcode);
            Assert.Equals(resultProduct.Description, product4.Description);
            Assert.Equals(resultProduct.Categories, product4.Categories);
        }

        [Test]
        public void Sad()
        {
            // the user searched for an existing item but he got a wrong result
            var filters = new List<string> {"name : salt"};
            var result = SearchFilter(guest, null, filters);
            Assert.IsNotEmpty(result);
            

        }

        [Test]
        public void Bad()
        {
            // product should not appear twice if it exists in more than one store
            var filters = new List<string> {"name : salt"};
            var result = SearchFilter(guest, null, filters);
            Assert.True(result.Count == 1);
            
        }

        [Test]
        public void ShouldFail()
        {
            
        }
    }
}