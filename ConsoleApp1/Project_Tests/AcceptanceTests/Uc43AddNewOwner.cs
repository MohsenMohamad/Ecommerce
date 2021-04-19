using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.presentationLayer;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class Uc43AddNewOwner:ATProject
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
            signUpGuest("user0","userPass");
            user = loginGuest("user0", "userPass");
            
            signUpGuest("user1","user1");
            signUpGuest("user2","user2");
            signUpGuest("user3","user3");
            signUpGuest("user4","user4");

            storeName = "storeName";
           
            
            OpenStore(user,"sellPolicy", storeName);
            store = getUsersStore(user,storeName);
            }

        [Test]
        public void Test()
        {
            //happy
            string newOwnerName = "user1";
            
            Assert.True(AddNewOwner(user, store, newOwnerName));
            Assert.True(IsOwner(store, newOwnerName));
            
            //bad
            User userNewOwner = loginGuest(newOwnerName, "user1");
            Assert.False(AddNewOwner(userNewOwner, store, "user0"));
        }
       
    }
}