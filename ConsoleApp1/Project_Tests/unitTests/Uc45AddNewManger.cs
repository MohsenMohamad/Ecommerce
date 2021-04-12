using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;
using Tests;

namespace Project_Tests.unitTests
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
            
            user = new User("user0", "userPass");
            
            signUpGuest("user1","user1");
            signUpGuest("user2","user2");
            signUpGuest("user3", "user3");

            storeName = "storeName";
           
            
            OpenStore(user,"sellPolicy", storeName);
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