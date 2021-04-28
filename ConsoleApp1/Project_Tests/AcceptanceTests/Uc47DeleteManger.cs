using Version1.domainLayer;
using Version1.Service_Layer;
using Version1.domainLayer.UserRoles;
using NUnit.Framework;
using Project_tests;
using Version1.domainLayer.DataStructures;

namespace Project_Tests.AcceptanceTests
{
    public class Uc47DeleteManger:ATProject
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
            Register("user0","userPass");
            ownerUser = loginGuest("user0", "userPass");
            
            Register("user1","user1");
            Register("user2","user2");
            Register("user3", "user3");

            storeName = "ebay2";
           
            
            OpenStore(ownerUser.UserName,"sellPolicy", storeName);
            store = getUsersStore(ownerUser,storeName);
        }

        [Test]
        public void Test()
        {
            //happy
            string newMangerName = "user1";
            
            Assert.True(AddNewManger(ownerUser, store, newMangerName));
            Assert.True(IsManger(store, newMangerName));
            //successful delete
            Assert.True(deleteManger(ownerUser, storeName, newMangerName));
            
            //bad
            Assert.False(IsManger(store,newMangerName));
        }
       
    }
}