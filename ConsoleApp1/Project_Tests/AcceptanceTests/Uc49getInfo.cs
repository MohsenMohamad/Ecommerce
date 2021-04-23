using Version1.domainLayer;
using Version1.presentationLayer;
using Version1.domainLayer.UserRoles;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class Uc49getInfo:ATProject
    {
        private static SystemAdmin admin;
        private static User ownerUser;
        private static Store store;
        string storeName;
        
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            initSystem(admin);
            //ownerUser = new User("user0", "userPass");
            Register("user0","userPass");zz
            ownerUser = loginGuest("user0", "userPass");
            
            Register("user1","user1");
            storeName = "ToysRus";
            OpenStore(ownerUser.UserName,"sellPolicy", storeName);
            store = getUsersStore(ownerUser,storeName);
        }

        [Test]
        public void Test()
        {
            //happy
            Assert.NotNull(getInfo(ownerUser, store));
        }
       
    }
}