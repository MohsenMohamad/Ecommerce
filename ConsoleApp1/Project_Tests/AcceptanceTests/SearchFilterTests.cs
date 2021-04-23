using System.Collections.Generic;
using Version1.domainLayer;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class SearchFilterTests : ATProject
    {
        
        private Product product1;
        private Product product2;
        private Product product3;
        private Product product4;

        [SetUp]
        public void Setup()
        {
            Register("member", "member");
            UserLogin("member", "member");
            
            OpenStore("member", "policy", "test store");
            product1 = new Product("tomato", "vegetables&fruit", "20", null);
            product2 = new Product("tomato sauce", "canned", "100", null);
            product3 = new Product("salt", "kosher salt", "111", null);
            product4 = new Product("tea", "black tea", "222", null);
            const int product1Amount = 1;
            const int product2Amount = 2;
            const int product3Amount = 3;
            const int product4Amount = 4;
            AddProductToStore("member", "test store", product1.Barcode, product1Amount);
            AddProductToStore("member", "test store", product2.Barcode, product2Amount);
            AddProductToStore("member", "test store", product3.Barcode, product3Amount);
            AddProductToStore("member", "test store", product4.Barcode, product4Amount);

            UserLogout("member");
            GuestLogin();
        }

        [Test]
        public void Happy()
        {
            var filters = new List<string> {"name : tea"};
            var result = SearchFilter(null, null, filters);
            Assert.NotNull(result);
            Assert.True(result.Count == 1);
            var resultProductCode = result[0];
            Assert.Equals(resultProductCode, product4.Barcode);

        }

        [Test]
        public void Sad()
        {
            // the user searched for an existing item but he got a wrong result
            var filters = new List<string> {"name : salt"};
            var result = SearchFilter(null, null, filters);
            Assert.IsNotEmpty(result);
            

        }

        [Test]
        public void Bad()
        {
            // product should not appear twice if it exists in more than one store
            var filters = new List<string> {"name : salt"};
            var result = SearchFilter(null, null, filters);
            Assert.True(result.Count == 1);
            
        }

        [Test]
        public void ShouldFail()
        {
            
        }
    }
}