using Version1.domainLayer;
using Version1.Service_Layer;
using Version1.domainLayer.UserRoles;
using NUnit.Framework;
using Project_tests;
using Version1.domainLayer.DataStructures;

namespace Project_Tests.AcceptanceTests
{
    public class Uc49getInfo:ATProject
    {
        private static SystemAdmin admin;
        private string ownerUser;
        string storeName;
        
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            admin.InitSystem();
            //ownerUser = new User("user0", "userPass");
            Register("user0","userPass");
            ownerUser = "user0";
            UserLogin("user0", "userPass");
            
            Register("user1","user1");
            storeName = "ToysRus";
            OpenStore(ownerUser, storeName,"sellPolicy");
        }

        [Test]
        public void Test()
        {
            //happy
            Assert.NotNull(getInfo(ownerUser, storeName));
        }
       
    }
}