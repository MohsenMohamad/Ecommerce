using System.Collections.Concurrent;
using System.Linq;
using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class Uc41AddEditRemovePruduct:ATProject
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
        public void SetUpSystem()
        {
            AdminInitiateSystem();
        }
        [SetUp]
        public void SetUp()
        {
            Register(UserName, Password);
            OpenStore(UserName, StoreName, "policy");
        }
        
        [Test]
        public void TestAdd()
        {
           
            Assert.True(AddProductToStore(OwnerName, StoreName, product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(), 2));
            
            //happy
            Assert.True(GetStoreInventory(OwnerName, StoreName).ContainsKey(product1.Barcode));
            //bad
            Assert.False(AddProductToStore(OwnerName, "noStore", product1.Barcode,product1.name,product1.description,product1.price,product1.categories.ToString(), 2));
        }
        [Test]
        public void TestUpdate()
        {
            AddProductToStore(OwnerName, StoreName, product1.Barcode, product1.Name, product1.Description,
                product1.Price, product1.Categories.ToString(), 2);
            int newAmount = 5;
            //happy
            UpdateProductAmountInStore(OwnerName, StoreName, product1.Barcode, newAmount);
            ConcurrentDictionary<string,int> inventory =  GetStoreInventory(OwnerName, StoreName);
            Assert.True( inventory[product1.Barcode] == newAmount) ;
            
            //bad
            UpdateProductAmountInStore(OwnerName, StoreName, product1.Barcode,0 );
            foreach (var VARIABLE in GetStoreInventory(OwnerName,StoreName))
            {
                Assert.False(VARIABLE.Value == (newAmount));
            }
            
        }
        
        [Test]
        public void TestRemove()
        {
            AddProductToStore(OwnerName, StoreName, product1.Barcode, product1.Name, product1.Description,
                product1.Price, product1.Categories.ToString(), 2);
            //happy
            Assert.True(RemoveProductFromStore( UserName, StoreName, product1.Barcode));
            
            //bad
            Assert.False(RemoveProductFromStore( UserName, StoreName, product1.Barcode));
        }
        
        
        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser(UserName);
            real.DeleteStore(StoreName);
            
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            var real = new RealProject();
            real.ResetMemory();
        }
        
    }
}