using System.Linq;
using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class Uc45AddNewManger:ATProject
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
            OpenStore(OwnerName, StoreName, "policy");
        }
        
        [Test]
        public void TestAdd()
        {
            //happy
            Assert.True(MakeNewManger(StoreName,OwnerName,UserName,1));
            //todo
            //Assert.True(IsManger(StoreName, UserName));
            Assert.True(IsManger(StoreName, OwnerName));
            //bad
            Assert.False(MakeNewManger(StoreName, UserName, OwnerName,1));
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