using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class SearchTests : ATProject
    {
      
        private readonly Product product1 = new Product("452456","tomato", "Red Organic Tomatoes", 10, new List<string>{"vegetables&fruit"});
        private readonly Product product2 = new Product("452457","tomato sauce", "italic sauce", 15, new List<string>{"canned"});
        private readonly Product product3 = new Product("452458","salt", "kosher salt", 5, new List<string>{"Seasoning"});
        private const string StoreName = "Test Store";
        private const string UserName = "Test User";
        private const string UserPassword = "123";

        [OneTimeSetUp]
        public void Setup()
        {
            Register(UserName, UserPassword);
            OpenStore(UserName, StoreName,"policy");
            AddProductToStore(UserName, StoreName, product1.Barcode, product1.Name,product1.Description,product1.price,product1.Categories.First(),1);
            AddProductToStore(UserName, StoreName, product2.Barcode, product2.Name,product2.Description,product2.price,product2.Categories.First(),2);
            AddProductToStore(UserName, StoreName, product3.Barcode, product3.Name,product3.Description,product3.price,product3.Categories.First(),0);
        }

        [Test]
        [Order(1)]
        public void SearchByName()
        {

            var searchResult = SearchByProductNameDictionary("tomato");
            Assert.NotNull(searchResult);
            Assert.True(searchResult.Count == 1);
            Assert.True(searchResult[StoreName].Count == 2);
            Assert.True(searchResult[StoreName].Contains(product1.barcode));
            Assert.True(searchResult[StoreName].Contains(product2.barcode));


        }

        [Test]
        [Order(2)]
        public void SearchByKeyword()
        {
            // "sauce" exists in both the name of product 2 and its description , it should appear only once in the result
            
            var searchResult = SearchByKeywordDictionary("sauce");
            Assert.NotNull(searchResult);
            Assert.True(searchResult.Count == 1);
            Assert.True(searchResult[StoreName].Count == 1);
            Assert.AreEqual(searchResult[StoreName].First(),product2.barcode);
        }
        
        [Test]
        [Order(3)]
        public void SearchByCategory()
        {
            // product should appear twice if it exists in more than one store

            const string badTestStoreName = "Bad Test Store";
            OpenStore(UserName, badTestStoreName, "Bad Policy");
            AddProductToStore(UserName, badTestStoreName, product2.Barcode, product2.Name,product2.Description,product2.price,product2.Categories.First(),2);
            var searchResult = SearchByCategoryDictionary("canned");
            Assert.NotNull(searchResult);
            Assert.True(searchResult.Count == 2);
            Assert.True(searchResult[StoreName].Count == 1);
            Assert.True(searchResult[badTestStoreName].Count == 1);
            Assert.AreEqual(searchResult[StoreName].First(),product2.barcode);
            Assert.AreEqual(searchResult[badTestStoreName].First(),product2.barcode);


        }
        
        [Test]
        [Order(4)]
        public void ShouldFail()
        {
            // even though the amount of product 3 is 0 , it should still appear

            var searchResult = SearchByProductNameDictionary(product3.name);
            Assert.IsNotNull(searchResult);
            Assert.True(searchResult.Count == 1);
            Assert.AreEqual(searchResult[StoreName].First(),product3.Barcode);

        }


        [OneTimeTearDown]
        public void TearDown()
        {
            new RealProject().ResetMemory();
        }
        
    }
    
}