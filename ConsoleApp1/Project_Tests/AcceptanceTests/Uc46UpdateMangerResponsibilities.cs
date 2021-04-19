using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class Uc46UpdateMangerResponsibilities:ATProject
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
            signUpGuest("user3", "user3");

            storeName = "ebay";
           
            
            OpenStore(user,"sellPolicy", storeName);
            store = getUsersStore(user,storeName);
            
                
        }

        [Test]
        public void Test()
        {
            //happy
            string newMangerName = "user1";
            string newRespon = "newResp";
            Assert.True(AddNewManger(user, store, newMangerName));
            Assert.True(IsManger(store, newMangerName));
            List<string> responsibilities = getMangerResponsibilities(user, store,newMangerName);
            responsibilities.Add(newRespon);

            Assert.True(updateMangerResponsibilities(user, storeName, responsibilities));
            Assert.Equals(responsibilities, getMangerResponsibilities(user, store, newMangerName));
            
            
            
            //bad
            responsibilities.Remove(newRespon);
            Assert.AreNotEqual(responsibilities, getMangerResponsibilities(user, store, newMangerName));
            
        }
       
    }
}