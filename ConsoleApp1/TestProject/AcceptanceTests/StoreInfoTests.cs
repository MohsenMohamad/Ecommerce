using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class StoreInfoTests : ATProject
    {
        private const string StoreName = "Test Store";
        private const string UserName = "Test User";
        private const string UserPassword = "123";
        private readonly Product product1 = new Product("452456", "tomato", "Red Organic Tomatoes", 10,
            new List<string>{"vegetables&fruit"});


        [OneTimeSetUp]
        public void Setup()
        {

            Register(UserName, UserPassword);
            OpenStore(UserName, StoreName, "policy");
            AddProductToStore(UserName, StoreName, product1.Barcode, product1.Name,product1.Description,product1.price,product1.Categories.First(),1);
        }

        [Test]
        public void Happy()
        {
            Assert.True(IsOwner(StoreName, UserName));
            var inventory = GetStoreInventory(UserName,StoreName);
            Assert.NotNull(inventory);
            Assert.True(inventory.Count ==1);
            Assert.AreEqual(inventory[product1.barcode],1);
        }
        
        [Test]
        public void ShouldFail()
        {
            var info = GetStoreInfo(UserName, "non-existing_store");
            Assert.IsNull(info);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            new RealProject().ResetMemory();
            
        }
    }
}