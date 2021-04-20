using ConsoleApp1.domainLayer;
using ConsoleApp1.presentationLayer;
using ConsoleApp1.domainLayer.UserRoles;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class Uc45AddNewManger:ATProject
    {
        private static SystemAdmin admin;
        private static User user;
        private static Store store;
        string storeName;
        
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            initSystem(admin);
            
            //user = new User("user0", "userPass");
            Register("user0","userPass");
            user = loginGuest("user0", "userPass");
            Register("user1","user1");
            Register("user2","user2");
            Register("user3", "user3");

            storeName = "<myStoreName";
           
            
            OpenStore(user.UserName,"sellPolicy", storeName);
            store = getUsersStore(user,storeName);
        }

        [Test]
        public void Test()
        {
            //happy
            string newOwnerName = "user1";
            
            Assert.True(AddNewManger(user, store, newOwnerName));
            Assert.True(IsManger(store, newOwnerName));
            
            //bad
            User userNewOwner = loginGuest(newOwnerName, "user1");
            Assert.False(AddNewManger(userNewOwner, store, "user0"));
            
        }
       
    }
}